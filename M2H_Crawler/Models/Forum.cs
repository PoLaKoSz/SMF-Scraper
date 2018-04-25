using System.Collections.Generic;

namespace M2H_Crawler.Models
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
