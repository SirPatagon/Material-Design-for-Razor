using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialDesignForRazor.TagHelpers.Cards
{
    [HtmlTargetElement("buttons", ParentTag = "actions")]
    [RestrictChildren("button")]
    public class Buttons : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext aContext, TagHelperOutput aOutput)
        {
            aContext.Items.Add("Parent", "Card");
            aOutput.TagName = "div";
            aOutput.AddCssClass("mdc-card__action-buttons");
            await base.ProcessAsync(aContext, aOutput);
        }
    }
}
