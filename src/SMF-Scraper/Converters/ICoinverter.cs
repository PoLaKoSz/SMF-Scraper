using HtmlAgilityPack;

namespace PoLaKoSz.SMF.Scraper.Converters
{
    public interface ICoinverter
    {
        int Deepness { get; set; }
        string XPath { get; set; }

        ICoinverter Clone();

        string BBCode(HtmlNode node);
    }
}
