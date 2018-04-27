using System.Collections.Generic;

namespace SMF_Scraper.WPF.Models
{
    public class Board : ForumNode, IForumNode
    {
        public IList<IForumNode> ChildBoards { get; protected set; }
        public IList<IForumNode> Topics { get; protected set; }
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



        public Board() { }

        public Board(string boardName, List<IForumNode> childBoards, List<IForumNode> boardTopics)
        {
            Name           = boardName;
            ChildBoards    = childBoards;
            Topics         = boardTopics;
            RemainingCount = ChildBoards.Count + Topics.Count;
        }
    }
}
