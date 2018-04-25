using System;

namespace M2H_Crawler.Models
{
	public class Topic
	{
		public int ID { get; private set; }
		public Board Board { get; set; }



		public Topic(int topicID)
		{
			ID = topicID;
		}
	}
}
