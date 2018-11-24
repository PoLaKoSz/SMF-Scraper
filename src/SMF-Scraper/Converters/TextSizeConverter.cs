using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace PoLaKoSz.SMF.Scraper.Converters
{
    public class TextSizeConverter : BBConverterBase
    {
        public override ICoinverter Clone()
        {
            return new TextSizeConverter();
        }


        public override string BBCode(HtmlNode htmlNode)
        {
            // For example     font-size: 14pt;
            string fontSize = htmlNode.Attributes["style"].Value;

            return string.Format("[size={0}pt]{1}[/size]", Regex.Match(fontSize, @"(?<=font-size: )\d+"), htmlNode.InnerHtml);
        }

        public override string HtmlTag()
        {
            return "span[@class='bbc_size']";
        }
    }
}
