using System.Collections.Generic;
using System.Linq;

namespace PoLaKoSz.SMF.Scraper.Models
{
	public class Board
	{
		public int ID { get; }

		public Board ParentBoard { get; }
		public List<Board> ChildBoards { get; internal set; }

		public string Name { get; }
		public string Description { get; internal set; }

        public List<Topic> Topics { get; internal set; }



        public Board(int id, string name)
            : this(id, name, "") { }

        public Board(int boardID, string boardName, string boardDescription)
            : this(boardID, boardName, boardDescription, new List<Board>()) { }

		public Board(int boardID, string boardName, string boardDescription,  List<Board> childBoards)
		{
            ID          = boardID;
			Name		= boardName;
			Description = boardDescription;
            ChildBoards = childBoards;
		}



        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var board = (Board)obj;

            if (ID != board.ID)
                return false;

            if (ParentBoard != board.ParentBoard)
                return false;

            if (!ChildBoards.SequenceEqual(board.ChildBoards))
                return false;

            if (!Name.Equals(board.Name))
                return false;

            if (!Description.Equals(Description))
                return false;

            return true;
        }
    }
}
