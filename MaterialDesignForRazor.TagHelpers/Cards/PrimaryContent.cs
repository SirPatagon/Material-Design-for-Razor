using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialDesignForRazor.TagHelpers.Cards
{
    [HtmlTargetElement("primary-content", ParentTag = "card")]
    public class PrimaryContent : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext aContext, TagHelperOutput aOutput)
        {
            aOutput.TagName = "div";
            aOutput.AddCssClass("mdc-card__primary-action");
            aOutput.Attributes.Add("tabindex", "0");
            await base.ProcessAsync(aContext, aOutput);
        }
    }
}
