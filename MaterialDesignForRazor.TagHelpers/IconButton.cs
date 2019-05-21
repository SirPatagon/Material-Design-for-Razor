using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialDesignForRazor.TagHelpers
{
    [HtmlTargetElement("icon-button", TagStructure = TagStructure.WithoutEndTag)]
    public class IconButton : TagHelper
    {
        public string Icon { get; set; }
        public string OnIcon { get; set; }
        public bool IsToggled { get; set; } = false;
        public override async Task ProcessAsync(TagHelperContext aContext, TagHelperOutput aOutput)
        {
            aOutput.TagName = "button";
            aOutput.AddCssClass("mdc-icon-button material-icons");
            aOutput.TagMode = TagMode.StartTagAndEndTag;

            if (!String.IsNullOrWhiteSpace(OnIcon))
            {
                aOutput.AddCssClass("mdc-icon-button-toggle");
                var icon = new TagBuilder("i");
                icon.AddCssClass("material-icons mdc-icon-button__icon mdc-icon-button__icon--on");
                icon.InnerHtml.Append(OnIcon);
                aOutput.Content.AppendHtml(icon);
            }
            if (!String.IsNullOrWhiteSpace(Icon))
            {
                var icon = new TagBuilder("i");
                icon.AddCssClass("material-icons mdc-icon-button__icon");
                icon.InnerHtml.Append(Icon);
                aOutput.Content.AppendHtml(icon);
            }
            if (IsToggled)
                aOutput.AddCssClass("mdc-icon-button--on");

            await base.ProcessAsync(aContext, aOutput);
        }
    }
}
