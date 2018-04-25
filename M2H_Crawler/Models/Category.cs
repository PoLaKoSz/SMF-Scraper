using System.Collections.Generic;
using System.Linq;

namespace M2H_Crawler.Models
{
	public class Category
	{
		public int ID { get; private set; }
		public int Order { get; set; }
		public string Name { get; private set; }
		public List<Board> Boards { get; set; }



        public Category(int categoryID, int categoryOrder, string categoryName)
            : this(categoryID, categoryOrder, categoryName, new List<Board>()) { }

        public Category(int categoryID, int categoryOrder, string categoryName, List<Board> categoryBoards)
        {
            ID     = categoryID;
            Order  = categoryOrder;
            Name   = categoryName;
            Boards = categoryBoards;
        }



        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var categorie = (Category)obj;

            if (ID != categorie.ID)
                return false;

            if (Order != categorie.Order)
                return false;

            if (!Name.Equals(categorie.Name))
                return false;

            if (Boards.Count != categorie.Boards.Count)
                return false;

            if (!Boards.SequenceEqual(categorie.Boards))
                return false;

            return true;
        }
    }
}
