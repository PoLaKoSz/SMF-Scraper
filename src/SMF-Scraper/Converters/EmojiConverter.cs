using HtmlAgilityPack;

namespace PoLaKoSz.SMF.Scraper.Converters
{
    public class EmojiConverter : BBConverter
    {
        public EmojiConverter(string sourceCode)
            : base(sourceCode) { }



        /// <summary>
        /// Remove every HTML <img> tag with the smiley className from the
        /// source code and replace it with the <img> tag's alt attribute value
        /// </summary>
        /// <returns></returns>
        public string RemoveEmojiImages()
        {
            base.ReplaceThisTag("//img[@class='smiley']");

            return base.SaveChanges();
        }

        /// <summary>
        /// Implementation what should the code do on the found XPath elements
        /// </summary>
        /// <param name="htmlNode"></param>
        /// <returns>This string will replace the found XPath element</returns>
        protected override string ReplaceToThis(HtmlNode htmlNode)
        {
            return htmlNode.Attributes["alt"].Value;
        }
    }
}
