using HtmlAgilityPack;

namespace PoLaKoSz.SMF.Scraper.Converters
{
    public class BoldStyleConverter : BBConverterBase
    {
        public override ICoinverter Clone()
        {
            return new BoldStyleConverter();
        }


        public override string BBCode(HtmlNode htmlNode)
        {
            return $"[b]{htmlNode.InnerHtml}[/b]";
        }

        public override string HtmlTag()
        {
            return "strong";
        }
    }
}
