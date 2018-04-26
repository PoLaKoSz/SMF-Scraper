using M2H_Crawler.Converters;

namespace M2H_Crawler.Workers
{
    public class HtmlCleaner
    {
        /// <summary>
        /// Remove font color, emojis from the string
        /// </summary>
        /// <param name="sourceCode"></param>
        /// <returns>cleaned string</returns>
        public string Remove(string sourceCode)
        {
            return new TextColorConverter(
                new EmojiConverter(sourceCode)
                    .RemoveEmojiImages())
                .RemoveTextColor();
        }
    }
}
