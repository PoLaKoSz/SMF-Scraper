using HtmlAgilityPack;

namespace PoLaKoSz.SMF.Scraper.Converters
{
    public class UnderlineTextConverter : BBConverterBase
    {
        public override ICoinverter Clone()
        {
            return new UnderlineTextConverter();
        }


        public override string BBCode(HtmlNode htmlNode)
        {
            return $"[u]{htmlNode.InnerHtml}[/u]";
        }

        public override string HtmlTag()
        {
            return "span[@class='bbc_u']";
        }
    }
}
