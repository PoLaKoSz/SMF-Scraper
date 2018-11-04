using System.Collections.Generic;
using System.Linq;

namespace PoLaKoSz.SMF.Scraper.Models
{
	public class Board
	{
		public int ID { get; private set; }
		public int CategoryID { get; set; }
		public int Order { get; set; }

		public Board ParentBoard { get; set; }
		public List<Board> ChildBoards { get; set; }


		public string Name { get; set; }
		public string Description { get; set; }



        public Board(int boardID, int categoryID, string boardName, int boardOrder)
            : this(boardID, categoryID, boardName, "", boardOrder, new List<Board>()) { }

        public Board(int boardID, int categoryID, string boardName, int boardOrder, List<Board> childBoards)
            : this(boardID, categoryID, boardName, "", boardOrder, childBoards) { }

        public Board(int boardID, int categoryID, string boardName, string boardDescription, int boardOrder)
            : this(boardID, categoryID, boardName, boardDescription, boardOrder, new List<Board>()) { }

		public Board(int boardID, int categoryID, string boardName, string boardDescription, int boardOrder, List<Board> childBoards)
		{
            ID          = boardID;
			CategoryID  = categoryID;
			Order       = boardOrder;
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

            if (CategoryID != board.CategoryID)
                return false;

            if (Order != board.Order)
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
