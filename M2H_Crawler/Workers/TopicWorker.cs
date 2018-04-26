using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using M2H_Crawler.Models;

namespace M2H_Crawler.Workers
{
    public class TopicWorker : Webpage, IWebpage
    {
        public TopicWorker(string sourceCode, ISmfTheme websiteTheme)
            : base(sourceCode, websiteTheme) { }

        public TopicWorker(Uri webpageURL, ISmfTheme websiteTheme)
            : base(webpageURL, websiteTheme) { }



        protected override List<IWebpage> Parse()
        {
            Console.WriteLine("{0, 50} : Parse Topic content", base.URL);

            var nextWebpages = new List<IWebpage>();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(base.SourceCode);

            var nextPageUrl = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='main_content_section']//div[@class='pagesection']//div[@class='pagelinks floatleft']//strong//following-sibling::a[@class='navPages']").Attributes["href"].Value;

            if (nextPageUrl != null)
                nextWebpages.Add(new TopicWorker(new Uri(nextPageUrl), Theme));

            return new List<IWebpage>();
        }

        private void ExtractMessages(HtmlDocument htmlDoc)
        {
            var messageMainFrame = htmlDoc.DocumentNode.SelectNodes("//div[@id='forumposts']//div[@class='windowbg' or @class='windowbg2']");

            foreach (var message in messageMainFrame)
            {
                string messageURL = message.SelectSingleNode(".//div[@class='postarea']//div[@class='flow_hidden']//a").Attributes["href"].Value;
                int messageID = Convert.ToInt32(messageURL.Substring(messageURL.IndexOf("#")));

                string post = message.SelectSingleNode(".//div[@class='postarea']").InnerText;
            }
        }

        /// <summary>
        /// Get every message from the current Topic's page
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        /// <exception cref="RegexMatchTimeoutException"></exception>
        public List<Message> GetMessages()
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(base.SourceCode);

            var messageNodes = htmlDoc.DocumentNode.SelectNodes(Theme.TopicMessageModel);

            if (messageNodes == null)
                throw new Exception("Could not find any message in this Topic: " + base.URL);

            var messageCollection = new List<Message>();

            foreach (var messageNode in messageNodes)
                ExtractDataFromMessageNode(messageCollection, messageNode);

            return messageCollection;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageCollection"></param>
        /// <param name="messageNode"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        /// <exception cref="RegexMatchTimeoutException"></exception>
        private void ExtractDataFromMessageNode(List<Message> messageCollection, HtmlNode messageNode)
        {
            var msgAnchor     = messageNode.SelectSingleNode(Theme.TopicMessageLink);
            var msgURL        = msgAnchor.Attributes["href"].Value;
            var rawPostedTime = messageNode.SelectSingleNode(Theme.TopicMessagePostedTime).InnerText.Replace("»", "").Trim();


            var msgID      = Convert.ToInt32(Regex.Match(msgURL, @"(?<=#msg)\d+").Value);

            var msgSubject = msgAnchor.InnerText;

            var msgBody = new HtmlCleaner().Remove(messageNode.SelectSingleNode(Theme.TopicMessageBody).InnerHtml);

            var postedTime = DateTime.Parse(rawPostedTime).ToUniversalTime();


            messageCollection.Add(new Message(msgID, msgSubject, msgBody, postedTime));
        }
    }
}
