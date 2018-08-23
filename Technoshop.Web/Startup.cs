using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technoshop.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.AspNetCore.Identity.UI.Services;
using Technoshop.Web.Areas.Identity.Services;
using Technoshop.Models;
using Technoshop.Web.Common;
using AutoMapper;
using Technoshop.Services.Admin.Interfaces;
using Technoshop.Services.Admin;
using Technoshop.Services.Moderator.Interfaces;
using Technoshop.Services.Moderator;
using Microsoft.AspNetCore.Mvc.Razor;
using Technoshop.Common.Resources;
using Technoshop.Services.Buyer;
using Technoshop.Services.Buyer.Interface;

namespace Technoshop.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCaching();
            services.AddResponseCompression();

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.AddSupportedCultures("en", "bg");
                options.AddSupportedUICultures("en", "bg");
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<TechnoshopContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("TechnoShopDb")));

            services.AddAuthentication().
                AddFacebook(options =>
                {
                    options.AppId = this.Configuration.GetSection("ExternalAuthetication:Facebook:AppId").Value;
                    options.AppSecret = this.Configuration.GetSection("ExternalAuthetication:Facebook:AppSecret").Value;
                })
                .AddGoogle(options =>
                {
                    options.ClientId = this.Configuration.GetSection("ExternalAuthetication:Google:ClientId").Value;
                    options.ClientSecret = this.Configuration.GetSection("ExternalAuthetication:Google:ClientSecret").Value; ;
                });

            services.AddIdentity<User, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<TechnoshopContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions()
                {
                    RequireDigit = true,
                    RequiredLength = 6,
                    RequiredUniqueChars = 2,
                    RequireLowercase = true,
                    RequireNonAlphanumeric = true,
                    RequireUppercase = true
                };

                options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20.00);
                options.Lockout.MaxFailedAccessAttempts = 3;
               
            });

            services.AddDistributedMemoryCache();

            services.AddSession();

            services.AddSingleton<IEmailSender, SendGridEmailSender>();

            services.Configure<SendGridOptions>(this.Configuration.GetSection("EmailSettings"));

            services.AddAutoMapper();

            services.AddSignalR();

            RegisterServiceLayer(services);

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(ValidationResources));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSession();

            app.UseRequestLocalization();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            if(env.IsDevelopment())
            {
                app.SeedDatabase();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "area",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void RegisterServiceLayer(IServiceCollection services)
        {
            services.AddScoped<IAdminCategoryService, AdminCategoryService>();
            services.AddScoped<IAdminProductService, AdminProductService>();
            services.AddScoped<IAdminHomeService, AdminHomeService>();
            services.AddScoped<IAdminUserService, AdminUserService>();

            services.AddScoped<IModeratorCategoryService, ModeratorCategoryService>();
            services.AddScoped<IModeratorProductsService, ModeratorProductsService>();
            services.AddScoped<IModeratorHomeService, ModeratorHomeService>();

            services.AddScoped<IBuyerCategoryService, BuyerCategoryService>();
            services.AddScoped<IBuyerProductsService, BuyerProductsService>();
            services.AddScoped<IBuyerHomeService, BuyerHomeService>();
            services.AddScoped<IBuyerOrdersService, BuyerOrdersService>();
        }
    }
}
