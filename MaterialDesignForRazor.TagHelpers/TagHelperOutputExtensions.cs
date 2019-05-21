using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignForRazor.TagHelpers
{
    public static class TagHelperOutputExtensions
    {
        /// <summary>
        /// Adds a CSS class to the list of CSS classes in the tag. If there are already
        /// CSS classes on the tag then a space character and the new class will be appended
        /// to the existing list.
        /// </summary>
        /// <param name="value"></param>
        public static void AddCssClass(this TagHelperOutput aOutput, string value)
        {
            var classList = aOutput.Attributes.Where(a => a.Name == "class");
            if (classList.Any())
            {
                StringBuilder classes = new StringBuilder();
                classes.Append(classList.First().Value.ToString());
                classes.Append(" " + value);
                aOutput.Attributes.RemoveAll("class");
                aOutput.Attributes.Add("class", classes.ToString());
            }
            else
            {
                aOutput.Attributes.Add("class", value);
            }
        }
    }
}
