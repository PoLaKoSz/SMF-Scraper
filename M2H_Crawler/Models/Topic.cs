using System;

namespace M2H_Crawler.Models
{
	public class Topic
	{
		public int ID { get; private set; }
        public string Name { get; private set; }



        public Topic(int topicID, string topicName)
		{
			ID   = topicID;
            Name = topicName;
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

            return true;
        }
    }
}
