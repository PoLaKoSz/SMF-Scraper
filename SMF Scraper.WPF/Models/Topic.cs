using System.Collections.Generic;

namespace SMF_Scraper.WPF.Models
{
    public class Topic : IForumNode
    {
        public string Name { get; private set; }
        public List<IForumNode> Messages { get; set; }
        


        public Topic(string topicName)
        {
            Name     = topicName;
            Messages = new List<IForumNode>();
        }
    }
}
