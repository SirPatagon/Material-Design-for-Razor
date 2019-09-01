using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialDesignForRazor.TagHelpers.Cards
{
    [HtmlTargetElement("media-content", ParentTag = "media")]
    public class MediaContent : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext aContext, TagHelperOutput aOutput)
        {
            aOutput.TagName = "div";
            aOutput.AddCssClass("mdc-card__media-content");
            await base.ProcessAsync(aContext, aOutput);
        }
    }
}
