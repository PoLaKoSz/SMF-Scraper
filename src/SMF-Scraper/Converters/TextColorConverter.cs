using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace SMF_Scraper.Converters
{
    public class TextColorConverter : BBConverter
    {
        public TextColorConverter(string sourceCode)
            : base(sourceCode) { }



        /// <summary>
        /// Remove every HTML <span> tag with the bbc_color className from the
        /// source code and replace it with [color=xx] span content [/color] BB code
        /// </summary>
        /// <returns></returns>
        public string RemoveTextColor()
        {
            base.ReplaceThisTag("//span[@class='bbc_color']");

            return base.SaveChanges();
        }

        /// <summary>
        /// Implementation what should the code do on the found XPath elements
        /// </summary>
        /// <param name="htmlNode"></param>
        /// <returns>This string will replace the found XPath element</returns>
        protected override string ReplaceToThis(HtmlNode htmlNode)
        {
            // For example     color: red;
            string fontColor = htmlNode.Attributes["style"].Value;

            return string.Format("[color={0}]{1}[/color]", Regex.Match(fontColor, @"(?<=color: )\w+"), htmlNode.InnerHtml);
        }
    }
}
