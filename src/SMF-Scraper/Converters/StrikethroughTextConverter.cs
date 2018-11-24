using HtmlAgilityPack;

namespace PoLaKoSz.SMF.Scraper.Converters
{
    public class StrikethroughTextConverter : BBConverterBase
    {
        public override ICoinverter Clone()
        {
            return new StrikethroughTextConverter();
        }


        public override string BBCode(HtmlNode htmlNode)
        {
            return $"[s]{htmlNode.InnerHtml}[/s]";
        }

        public override string HtmlTag()
        {
            return "del";
        }
    }
}
