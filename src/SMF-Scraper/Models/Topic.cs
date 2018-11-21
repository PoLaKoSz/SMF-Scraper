using System.Collections.Generic;
using System.Linq;

namespace PoLaKoSz.SMF.Scraper.Models
{
	public class Topic
	{
		public int ID { get; private set; }
        public string Name { get; private set; }

        public List<Message> Messages { get; internal set; }



        public Topic(int topicID, string topicName)
		{
			ID       = topicID;
            Name     = topicName;
            Messages = new List<Message>();
		}



        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var topic = (Topic)obj;

            if (ID != topic.ID)
                return false;

            if (!Name.Equals(topic.Name))
                return false;

            if (Messages.Count != topic.Messages.Count)
                return false;

            if (!Messages.SequenceEqual(topic.Messages))
                return false;

            return true;
        }
    }
}
