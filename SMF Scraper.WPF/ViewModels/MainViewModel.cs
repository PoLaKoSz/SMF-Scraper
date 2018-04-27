using SMF_Scraper.WPF.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMF_Scraper.WPF.ViewModels
{
    public class MainViewModel
    {
        private MainWindow View { get; set; }
        public IList<IForumNode> Categories { get; private set; }



        public MainViewModel()
        {
            Categories = new TestData().Categories;

            View = new MainWindow(this);
            View.Show();

            StartTheProgram();
        }



        private async void StartTheProgram()
        {
            //await UpdateProgressBar();
        }

        private async Task UpdateProgressBar()
        {
            for (int i = 0; i < 100; i++)
            {
                //View.ProgressBar.Value = i;
                await Task.Delay(1000);
            }
        }
    }
}
