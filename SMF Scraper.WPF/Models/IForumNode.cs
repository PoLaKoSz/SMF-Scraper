using System;

namespace SMF_Scraper.WPF.Models
{
    public interface IForumNode
    {
        string Name { get; }
        bool IsScrapingInProgress { get; set; }
        int RemainingCount { get; set; }
}
}
