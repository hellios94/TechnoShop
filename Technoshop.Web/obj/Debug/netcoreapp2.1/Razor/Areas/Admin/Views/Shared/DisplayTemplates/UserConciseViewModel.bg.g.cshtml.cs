#pragma checksum "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e55657538d93341354b49ffe7eb5dcb4a20e8bc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Technoshop.Common.Admin.Shared.DisplayTemplates.Areas_Admin_Views_Shared_DisplayTemplates_UserConciseViewModel_bg), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/DisplayTemplates/UserConciseViewModel.bg.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Shared/DisplayTemplates/UserConciseViewModel.bg.cshtml", typeof(Technoshop.Common.Admin.Shared.DisplayTemplates.Areas_Admin_Views_Shared_DisplayTemplates_UserConciseViewModel_bg))]
namespace Technoshop.Common.Admin.Shared.DisplayTemplates
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Technoshop.Web.Areas.Admin;

#line default
#line hidden
#line 3 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Technoshop.Models;

#line default
#line hidden
#line 4 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Technoshop.Common.Buyer.ViewModels;

#line default
#line hidden
#line 5 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Technoshop.Common.Admin.BindingModels;

#line default
#line hidden
#line 6 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Technoshop.Common.Admin.ViewModels;

#line default
#line hidden
#line 7 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Technoshop.Web.Helpers;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e55657538d93341354b49ffe7eb5dcb4a20e8bc", @"/Areas/Admin/Views/Shared/DisplayTemplates/UserConciseViewModel.bg.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e4e36aa0aaa97c8b6a937f4cf2a9e3a18b7d441", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_DisplayTemplates_UserConciseViewModel_bg : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserConciseViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary fa fa-list"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Ban", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger fa fa-ban"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CancelModerator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning fa fa-user-times"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MakeModerator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success fa fa-user-tie"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(29, 52, true);
            WriteLiteral("\r\n\r\n\r\n<tr>\r\n    <th scope=\"row\" class=\"text-center\">");
            EndContext();
            BeginContext(82, 14, false);
#line 6 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
                                   Write(Model.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(96, 35, true);
            WriteLiteral("</th>\r\n    <td class=\"text-center\">");
            EndContext();
            BeginContext(132, 11, false);
#line 7 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
                       Write(Model.Email);

#line default
#line hidden
            EndContext();
            BeginContext(143, 35, true);
            WriteLiteral("</td>\r\n    <td class=\"text-center\">");
            EndContext();
            BeginContext(179, 39, false);
#line 8 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
                       Write(Html.DisplayFor(model => model.IsAdmin));

#line default
#line hidden
            EndContext();
            BeginContext(218, 35, true);
            WriteLiteral("</td>\r\n    <td class=\"text-center\">");
            EndContext();
            BeginContext(254, 43, false);
#line 9 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
                       Write(Html.DisplayFor(model => model.IsModerator));

#line default
#line hidden
            EndContext();
            BeginContext(297, 35, true);
            WriteLiteral("</td>\r\n    <td class=\"text-center\">");
            EndContext();
            BeginContext(333, 40, false);
#line 10 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
                       Write(Html.DisplayFor(model => model.IsBanned));

#line default
#line hidden
            EndContext();
            BeginContext(373, 39, true);
            WriteLiteral("</td>\r\n\r\n    <td class=\"text-center\">\r\n");
            EndContext();
#line 13 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
         if (Model.IsAdmin == true)
        {

#line default
#line hidden
            BeginContext(460, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(472, 184, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "180c520d430742f6a212a2291460d17e", async() => {
                BeginContext(613, 39, true);
                WriteLiteral("\r\n                Детайли\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 15 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
                                                                             WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(656, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 19 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
        }

#line default
#line hidden
            BeginContext(669, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 20 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
         if (Model.IsAdmin == false)
        {
            

#line default
#line hidden
#line 22 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
             if (Model.IsBanned == true)
            {

#line default
#line hidden
            BeginContext(775, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(791, 196, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "07bcb9133d3d43d59e07b0cd43622b8e", async() => {
                BeginContext(936, 47, true);
                WriteLiteral("\r\n                    Детайли\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 24 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
                                                                                 WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(987, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 28 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"

            }

#line default
#line hidden
#line 30 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
             if (Model.IsBanned == false)
            {

#line default
#line hidden
            BeginContext(1064, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(1080, 193, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86b313b09b744821a75642cf69a04780", async() => {
                BeginContext(1222, 47, true);
                WriteLiteral("\r\n                    Детайли\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 32 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
                                                                                 WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1273, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1291, 181, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "56e8166e8c8148209dc795d86a8a0503", async() => {
                BeginContext(1425, 43, true);
                WriteLiteral("\r\n                    Бан\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 36 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
                                                                             WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1472, 9, true);
            WriteLiteral(" <br />\r\n");
            EndContext();
#line 40 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
                 if (Model.IsModerator == true)
                {

#line default
#line hidden
            BeginContext(1549, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(1569, 223, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1223eeacf00a4b5b9f27a3c2063bcf3e", async() => {
                BeginContext(1727, 61, true);
                WriteLiteral("\r\n                     Отмени Модератор\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 42 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
                                                                                             WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1792, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 46 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
                }

#line default
#line hidden
#line 48 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
                 if (Model.IsModerator == false)
                {

#line default
#line hidden
            BeginContext(1884, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(1904, 223, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "642dee5e29924f36912e0fbd4ec2c720", async() => {
                BeginContext(2058, 65, true);
                WriteLiteral("\r\n                        Направи Модератор\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 50 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
                                                                                           WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2127, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 54 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
                }

#line default
#line hidden
#line 54 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
                 
            }

#line default
#line hidden
#line 55 "C:\Моите Проекти\Web Project\Technoshop\Technoshop.Web\Areas\Admin\Views\Shared\DisplayTemplates\UserConciseViewModel.bg.cshtml"
             
         }

#line default
#line hidden
            BeginContext(2175, 22, true);
            WriteLiteral("\r\n    </td>\r\n</tr>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserConciseViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591