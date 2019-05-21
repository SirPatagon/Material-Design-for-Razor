using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialDesignForRazor.TagHelpers.Cards
{
    [RestrictChildren("primary-content")]
    public class Card : TagHelper
    {
        public CardType CardType { get; set; } = CardType.Standard;

        public override async Task ProcessAsync(TagHelperContext aContext, TagHelperOutput aOutput)
        {
            aOutput.TagName = "div";
            aOutput.AddCssClass("mdc-card");

            switch (CardType)
            {
                case CardType.Outlined:
                    aOutput.AddCssClass("mdc-card--outlined");
                    break;
                case CardType.Standard:
                default:
                    break;
            }

            await base.ProcessAsync(aContext, aOutput);
        }
    }

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

    [HtmlTargetElement("media", ParentTag = "primary-content")]
    public class Media : TagHelper
    {
        public CardMediaAspectRatio AspectRatio { get; set; } = CardMediaAspectRatio.Standard;
        public string Image { get; set; }

        public override async Task ProcessAsync(TagHelperContext aContext, TagHelperOutput aOutput)
        {
            aOutput.TagName = "div";
            aOutput.AddCssClass("mdc-card__media");

            switch (AspectRatio)
            {
                case CardMediaAspectRatio.SixteenToNine:
                    aOutput.AddCssClass("mdc-card__media--16-9");
                    break;
                case CardMediaAspectRatio.Square:
                    aOutput.AddCssClass("mdc-card__media--square");
                    break;
                case CardMediaAspectRatio.Standard:
                default:
                    break;
            }

            aOutput.Attributes.Add("style", $"background-image: url('{Image}');");

            await base.ProcessAsync(aContext, aOutput);
        }
    }
}
