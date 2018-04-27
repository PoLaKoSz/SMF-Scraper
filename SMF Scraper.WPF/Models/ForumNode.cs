using System;

namespace SMF_Scraper.WPF.Models
{
    public abstract class ForumNode : IForumNode
    {
        public bool IsScrapingFinished { get; set; }
    }
}
