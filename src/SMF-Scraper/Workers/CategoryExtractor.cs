using HtmlAgilityPack;
using System;
using System.Text.RegularExpressions;

namespace PoLaKoSz.SMF.Scraper.Workers
{
    public class CategoryExtractor
    {
        /// <summary>
        /// This node contains the full webpage
        /// </summary>
        private HtmlNode HtmlNode { get; set; }



        /// <summary>
        /// This constructor should be used only for UnitTest
        /// </summary>
        /// <param name="sourceCode"></param>
        public CategoryExtractor(string sourceCode)
        {
            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(sourceCode);

            HtmlNode = htmlDocument.DocumentNode;
        }

        public CategoryExtractor(HtmlNode htmlNode)
        {
            HtmlNode = htmlNode;
        }



        /// <summary>
        /// Navigation section is usually located over the board and the topic list
        /// for example: Forum >> #1 Category >> AwesomeBoardName
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public int GetIDFromNavigationSection()
        {
            var navigationUrls = HtmlNode.SelectNodes("//div[@class='navigate_section']//ul//li//a");

            foreach (var url in navigationUrls)
            {
                var match = Regex.Match(url.Attributes["href"].Value, @"(?<=&action=forum#c)\d{1,2}");

                if (match.Success)
                    return Convert.ToInt32(match.Value);
            }

            throw new ArgumentException("No Category ID found in the given HtmlDocument!");
        }
    }
}
