using System;

namespace SMF_Scraper.WPF.Models
{
    public abstract class ForumNode : IForumNode
    {
        public string Name { get; set; }

        public bool IsScrapingInProgress { get; protected set; }

        public int RemainingCount { get; protected set; } = 10;
    }
}
