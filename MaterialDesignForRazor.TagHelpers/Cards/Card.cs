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
}
