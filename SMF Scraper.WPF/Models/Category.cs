using System.Collections.Generic;

namespace SMF_Scraper.WPF.Models
{
    public class Category : ForumNode, IForumNode
    {
        public string Name { get; private set; }
        public List<IForumNode> Boards { get; set; }



        public Category(string categoryName)
        {
            Name   = categoryName;
            Boards = new List<IForumNode>();
        }
    }
}
