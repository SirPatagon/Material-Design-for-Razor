using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialDesignForRazor.TagHelpers.Cards
{
    [HtmlTargetElement("icons", ParentTag = "actions")]
    [RestrictChildren("icon-button")]
    public class Icons : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext aContext, TagHelperOutput aOutput)
        {
            aContext.Items.Add("Parent", "Card");
            aOutput.TagName = "div";
            aOutput.AddCssClass("mdc-card__action-icons");
            await base.ProcessAsync(aContext, aOutput);
        }
    }
}
