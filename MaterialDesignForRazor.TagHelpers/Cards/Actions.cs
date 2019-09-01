using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialDesignForRazor.TagHelpers.Cards
{
    [HtmlTargetElement("actions", ParentTag = "card")]
    [RestrictChildren("buttons", "icons")]
    public class Actions : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext aContext, TagHelperOutput aOutput)
        {
            aOutput.TagName = "div";
            aOutput.AddCssClass("mdc-card__actions");
            await base.ProcessAsync(aContext, aOutput);
        }
    }
}
