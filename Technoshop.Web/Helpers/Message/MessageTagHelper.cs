using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technoshop.Web.Helpers.Message
{
    public class MessageTagHelper : TagHelper
    {
        public MessageType Type { get; set; }

        public string Message { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var result = new StringBuilder();
            result
                .Append($"<div class=\"alert alert-{this.Type.ToString().ToLower()}\">")
                .Append("<a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>")
                .Append(this.Message)
                .Append("</div>");

            output.Content.SetHtmlContent(result.ToString());
        }
    }
}
