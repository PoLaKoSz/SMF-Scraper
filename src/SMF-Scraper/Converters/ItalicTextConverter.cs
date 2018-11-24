using HtmlAgilityPack;

namespace PoLaKoSz.SMF.Scraper.Converters
{
    public class ItalicTextConverter : BBConverterBase
    {
        public override ICoinverter Clone()
        {
            return new ItalicTextConverter();
        }


        public override string BBCode(HtmlNode htmlNode)
        {
            return $"[i]{htmlNode.InnerHtml}[/i]";
        }

        public override string HtmlTag()
        {
            return "em";
        }
    }
}
