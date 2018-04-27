using System.Collections.Generic;

namespace SMF_Scraper.WPF.Models
{
    public class Board : IForumNode
    {
        public int Key { get; set; }
        public string Name { get; set; }

        public IList<IForumNode> ChildBoards { get; set; }
        public IList<IForumNode> Topics { get; set; }

        public List<IForumNode> AllNodes
        {
            get
            {
                var childNodes = new List<IForumNode>();

                childNodes.AddRange(ChildBoards);
                childNodes.AddRange(Topics);

                return childNodes;
            }
        }
    }
}
