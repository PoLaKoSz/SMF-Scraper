using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace PoLaKoSz.SMF.Scraper.Parsers
{
    internal abstract class Paginator
    {
        protected int? PreviousPage(string sourceCode)
        {
            var match = Regex.Match(PageLinkContent(sourceCode), @"\d+(?= \[)");

            if (match.Success)
                return int.Parse(match.Value);

            return null;
        }

        protected int? NextPage(string sourceCode)
        {
            var match = Regex.Match(PageLinkContent(sourceCode), @"(?<= \[\d+\] )\d+");

            if (match.Success)
                return int.Parse(match.Value);

            return null;
        }


        private string PageLinkContent(string sourceCode)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(sourceCode);

            var pageLinksNode = htmlDoc.DocumentNode
                .SelectSingleNode("//div[@id='bodybg']//div[@class='pagesection']//div[@class='pagelinks floatleft']");

            return pageLinksNode.InnerText;
        }

        private int CurrentPage(string sourceCode)
        {
            var match = Regex.Match(PageLinkContent(sourceCode), @"(?<= \[)\d+");

            if (!match.Success)
                throw new NodeNotFoundException("Could not determinate which page are we!");

            return 0;
        }
    }
}
