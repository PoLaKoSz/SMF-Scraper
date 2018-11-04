using System.Collections.Generic;

namespace PoLaKoSz.SMF.Scraper.Models
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
