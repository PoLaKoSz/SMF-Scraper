using System.Collections.Generic;

namespace SMF_Scraper.Models
{
	public class Forum
	{
		public List<Category> Categories { get; set; }



		public Forum()
		{
			Categories = new List<Category>();
		}
	}
}
