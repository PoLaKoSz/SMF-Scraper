using SMF_Scraper.WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            FakeForumScraping();
        }

        Random Random { get; set; }
        private void FakeForumScraping()
        {
            Random = new Random();

            for (int i = 1; i < 3; i++)
                AddFakeCategories();
        }

        private void AddFakeCategories()
        {
            for (int i = 1; i < Random.Next(5); i++)
                Categories.Add(new Category("Category #" + i, AddFakeBoards()));
        }

        private List<IForumNode> AddFakeBoards()
        {
            var boardCollection = new List<IForumNode>();

            for (int i = 0; i < Random.Next(10); i++)
            {
                var childrenBoards = new List<IForumNode>();

                if (Random.Next(10) == 0)
                    childrenBoards = AddFakeBoards();

                boardCollection.Add(new Board("Board #" + i, childrenBoards, AddFakeTopics()));
            }

            return boardCollection;
        }

        private List<IForumNode> AddFakeTopics()
        {
            var topicCollection = new List<IForumNode>();

            for (int i = 0; i < Random.Next(10); i++)
            {
                var messageCollection = new List<IForumNode>();

                for (int k = 0; k < Random.Next(5); k++)
                    messageCollection.Add(new Message("Message #" + k));

                topicCollection.Add(new Topic("Topic #" + i, messageCollection));
            }

            return topicCollection;
        }

        private async void ProgressBarTest()
        {
            await UpdateProgressBar();
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
