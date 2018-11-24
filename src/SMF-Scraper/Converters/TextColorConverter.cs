using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace PoLaKoSz.SMF.Scraper.Converters
{
    public class TextColorConverter : BBConverterBase
    {
        public override ICoinverter Clone()
        {
            return new TextColorConverter();
        }


        public override string BBCode(HtmlNode htmlNode)
        {
            // For example     color: red;
            string fontColor = htmlNode.Attributes["style"].Value;

            return string.Format("[color={0}]{1}[/color]", Regex.Match(fontColor, @"((?<=color: )\w+|(?<=color: )#\w+)"), htmlNode.InnerHtml);
        }

        public override string HtmlTag()
        {
            return "span[@class='bbc_color']";
        }
    }
}
