namespace SMF_Scraper.WPF.Models
{
    public class Message : ForumNode, IForumNode
    {
        public Message() { }

        public Message(string messsageText)
        {
            Name = messsageText;
        }
    }
}
