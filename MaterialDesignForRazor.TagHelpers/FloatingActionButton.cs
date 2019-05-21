using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignForRazor.TagHelpers
{
    public class FloatingActionButton : TagHelper
    {
        public string Icon { get; set; }
        public IconPosition IconPosition { get; set; } = IconPosition.Left;
        public Size Size { get; set; } = Size.Standard;

        private void AddIconIfNotEmpty(TagHelperOutput aOutput)
        {
            if (!String.IsNullOrWhiteSpace(Icon))
            {
                aOutput.Attributes.Add("aria-label", Icon);
                var icon = new TagBuilder("i");
                icon.AddCssClass("material-icons mdc-fab__icon");
                icon.InnerHtml.Append(Icon);
                aOutput.Content.AppendHtml(icon);
            }
        }

        private async void AddText(TagHelperOutput aOutput)
        {
            var content = await aOutput.GetChildContentAsync();
            if (!String.IsNullOrWhiteSpace(content.GetContent()))
            {
                aOutput.Attributes.Add("aria-label", Icon);
                aOutput.AddCssClass("mdc-fab--extended");
                var label = new TagBuilder("span");
                label.AddCssClass("mdc-fab__label");
                label.InnerHtml.AppendHtml(content);
                aOutput.Content.AppendHtml(label);
            }
        }

        public override async Task ProcessAsync(TagHelperContext aContext, TagHelperOutput aOutput)
        {
            aOutput.TagName = "button";
            aOutput.Attributes.Add("class", "mdc-fab");
            aOutput.TagMode = TagMode.StartTagAndEndTag;

            switch (Size)
            {
                case Size.Mini:
                    aOutput.AddCssClass("mdc-fab--mini");
                    break;
                case Size.Standard:
                default:
                    break;
            }

            switch (IconPosition)
            {
                case IconPosition.Right:
                    AddText(aOutput);
                    AddIconIfNotEmpty(aOutput);
                    break;

                case IconPosition.Left:
                default:
                    AddIconIfNotEmpty(aOutput);
                    AddText(aOutput);
                    break;
            }

            await base.ProcessAsync(aContext, aOutput);
        }
    }
}
