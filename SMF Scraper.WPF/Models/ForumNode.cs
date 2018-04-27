using Framework;

namespace SMF_Scraper.WPF.Models
{
    public abstract class ForumNode : ObservableObject, IForumNode
    {

        public string Name { get; set; }

        private bool _isScrapingInProgress;
        public bool IsScrapingInProgress
        {
            get { return _isScrapingInProgress; }
            set
            {
                SetProperty(ref _isScrapingInProgress, value);
            }
        }        

        public int RemainingCount { get; set; }
    }
}
