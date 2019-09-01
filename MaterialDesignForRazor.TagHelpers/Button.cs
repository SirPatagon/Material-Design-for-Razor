using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignForRazor.TagHelpers
{
    public class Button : TagHelper
    {
        public ButtonType ButtonType { get; set; } = ButtonType.Text;
        public string Icon { get; set; }
        public IconPosition IconPosition { get; set; } = IconPosition.Left;

        private void AddIconIfNotEmpty(TagHelperOutput aOutput)
        {
            if (!String.IsNullOrWhiteSpace(Icon))
            {
                var icon = new TagBuilder("i");
                icon.AddCssClass("material-icons mdc-button__icon");
                icon.Attributes.Add("aria-hidden", "true");
                icon.InnerHtml.Append(Icon);
                aOutput.Content.AppendHtml(icon);
            }
        }

        private async void AddText(TagHelperOutput aOutput)
        {
            var label = new TagBuilder("span");
            label.AddCssClass("mdc-button__label");
            label.InnerHtml.AppendHtml(await aOutput.GetChildContentAsync());
            aOutput.Content.AppendHtml(label);
        }

        public override async Task ProcessAsync(TagHelperContext aContext, TagHelperOutput aOutput)
        {
            aOutput.TagName = "button";
            aOutput.AddCssClass("mdc-button");
            if (aContext.Items.ContainsKey("Parent") && aContext.Items["Parent"] == "Card")
            {
                aOutput.AddCssClass("mdc-card__action");
                aOutput.AddCssClass("mdc-card__action--button");
            }

            switch (ButtonType)
            {
                case ButtonType.Outlined:
                    aOutput.AddCssClass("mdc-button--outlined");
                    break;
                case ButtonType.Raised:
                    aOutput.AddCssClass("mdc-button--raised");
                    break;
                case ButtonType.Unelevated:
                    aOutput.AddCssClass("mdc-button--unelevated");
                    break;
                case ButtonType.Text:
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
