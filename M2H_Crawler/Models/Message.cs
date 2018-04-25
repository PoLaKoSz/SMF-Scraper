using System;

namespace M2H_Crawler.Models
{
	public class Message
	{
		public int ID { get; private set; }
		public Topic Topic { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public DateTime PostedTime { get; set; }




		public Message(int messageID, Topic messageTopic, string messageSubject, string messageBody, DateTime postedTime)
		{
			ID         = messageID;
			Topic      = messageTopic;
			Subject    = messageSubject;
			Body       = messageBody;
			PostedTime = postedTime;
		}
	}
}
