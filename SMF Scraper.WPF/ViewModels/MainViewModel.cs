using SMF_Scraper.WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SMF_Scraper.WPF.ViewModels
{
    public class MainViewModel
    {
        private MainWindow View { get; set; }
        public ObservableCollection<IForumNode> Categories { get; private set; }



        public MainViewModel()
        {
            Categories = new ObservableCollection<IForumNode>();

            View = new MainWindow(this);
            View.Show();

            //ProgressBarTest();

            SlowCategoryMaker();
        }

        private async void SlowCategoryMaker()
        {
            var taskList = new List<Task>();

            for (int i = 0; i < 1; i++)
                taskList.Add(DoIt(i));
            
            await Task.WhenAll(taskList.ToArray());
        }

        private async Task DoIt(int index)
        {
            Debug.Write("Started " + index + "\n");

            var category = new Category("Category #" + (index + 1), await AddFakeBoards())
            {
                IsScrapingInProgress = true
            };

            Categories.Insert(index, category);

            var rand = Random.Next(5, 10);

            Debug.Write("Waiting #" + index + " DoIt()" + rand * 1000 + "sec\n");

            await Task.Delay(1000 * rand);

            Categories[index].IsScrapingInProgress = false;

            Debug.Write("Eneded " + index + "\n");
        }

        Random Random { get; set; } = new Random();

        private async Task<List<IForumNode>> AddFakeBoards()
        {
            var taskList = new List<Task>();
            var boardCollection = new List<IForumNode>();

            for (int i = 0; i < 2; i++)
                taskList.Add(DoItBoard(boardCollection, i));

            await Task.WhenAll(taskList.ToArray());

            return boardCollection;
        }

        private async Task DoItBoard(List<IForumNode> boardCollection, int i)
        {
            await Task.Delay(1);
        }
    }
}
