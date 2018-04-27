using System.Collections.Generic;

namespace SMF_Scraper.WPF.Models
{
    public class Category : ForumNode, IForumNode
    {
        public List<IForumNode> Boards { get; protected set; }



        public Category(string categoryName, List<IForumNode> categoryBoards)
        {
            Name           = categoryName;
            Boards         = categoryBoards;
            RemainingCount = Boards.Count;
        }
    }
}
