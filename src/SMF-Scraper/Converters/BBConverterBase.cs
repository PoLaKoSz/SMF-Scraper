using HtmlAgilityPack;

namespace PoLaKoSz.SMF.Scraper.Converters
{
    public abstract class BBConverterBase : ICoinverter
    {
        /// <summary>
        /// This number indicates how deep this node
        /// is in the HTML tree.
        /// </summary>
        public int Deepness { get; set; }

        /// <summary>
        /// Node absolute XPath in the <see cref="HtmlDocument"/>.
        /// </summary>
        public string XPath { get; set; }



        public BBConverterBase()
        {
            XPath = "";
        }



        public abstract string BBCode(HtmlNode htmlNode);

        public abstract string HtmlTag();

        public abstract ICoinverter Clone();
    }
}
