using HtmlAgilityPack;
using PoLaKoSz.SMF.Scraper.Models;
using PoLaKoSz.SMF.Scraper.Workers;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PoLaKoSz.SMF.Scraper.Parsers
{
    class TopicParser : Paginator
    {
        public RootObject<Topic> Execute(Topic topic, string sourceCode, ISmfTheme theme, IUrlParser urlParser)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(sourceCode);

            var messageNodes = htmlDoc.DocumentNode.SelectNodes(theme.TopicMessageModel);

            if (messageNodes == null)
                throw new NodeNotFoundException("Could not find any message in this Topic");

            foreach (var messageNode in messageNodes)
                ParseMessage(topic.Messages, messageNode, theme);

            int? prevPage = base.PreviousPage(sourceCode);
            int? nextPage = base.NextPage(sourceCode);

            return new RootObject<Topic>(topic, prevPage, nextPage);
        }


        private void ParseMessage(List<Message> messages, HtmlNode node, ISmfTheme theme)
        {
            var msgAnchor = node.SelectSingleNode(theme.TopicMessageLink);
            var msgURL = msgAnchor.Attributes["href"].Value;
            var rawPostedTime = node.SelectSingleNode(theme.TopicMessagePostedTime).InnerText.Replace("»", "").Trim();


            var msgID = Convert.ToInt32(Regex.Match(msgURL, @"(?<=#msg)\d+").Value);

            var msgSubject = msgAnchor.InnerText;

            var msgBody = new HtmlCleaner().Remove(node.SelectSingleNode(theme.TopicMessageBody).InnerHtml);

            var postedTime = DateTime.Parse(rawPostedTime).ToUniversalTime();

            // TODO : This is good, but what if this run multiple times on the same Topic?
            messages.Add(new Message(msgID, msgSubject, msgBody, postedTime));
        }
    }
}
