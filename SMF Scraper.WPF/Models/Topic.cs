using System.Collections.Generic;

namespace SMF_Scraper.WPF.Models
{
    public class Topic : ForumNode, IForumNode
    {
        public List<IForumNode> Messages { get; protected set; }
        


        public Topic(string topicName, List<IForumNode> topicMessage)
        {
            Name           = topicName;
            Messages       = topicMessage;
            RemainingCount = Messages.Count;
        }
    }
}
