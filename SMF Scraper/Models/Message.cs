using System;

namespace SMF_Scraper.Models
{
	public class Message
	{
		public int ID { get; private set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public DateTime PostedTime { get; set; }
        


		public Message(int messageID, string messageSubject, string messageBody, DateTime postedTime)
		{
			ID         = messageID;
			Subject    = messageSubject;
			Body       = messageBody;
			PostedTime = postedTime;
		}



        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var message = (Message)obj;

            if (ID != message.ID)
                return false;

            if (!Subject.Equals(message.Subject))
                return false;

            if (!Body.Equals(message.Body))
                return false;

            if (PostedTime != message.PostedTime)
                return false;

            return true;
        }
    }
}
