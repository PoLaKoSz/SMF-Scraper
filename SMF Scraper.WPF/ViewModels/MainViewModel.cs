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

            //FakeForumScraping();
        }

        private async void SlowCategoryMaker()
        {
            var taskList = new List<Task>();

            for (int i = 0; i < 10; i++)
                taskList.Add(DoIt(i));
            
            await Task.WhenAll(taskList.ToArray());
        }

        private async Task DoIt(int index)
        {
            Debug.Write("Started " + index + "\n");

            var category = new Category("Category #" + (index + 1), new List<IForumNode>())
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
        private async void FakeForumScraping()
        {
            Random = new Random();

            var taskList = new List<Task>();

            for (int i = 1; i < 3; i++)
                taskList.Add(AddFakeCategories());

            await Task.WhenAll(taskList.ToArray());
        }

        private async Task AddFakeCategories()
        {
            var taskList = new List<Task>();

            for (int i = 1; i < Random.Next(10); i++)
            {
                Categories.Add(new Category("Category #" + i, await AddFakeBoards()) { IsScrapingInProgress = false });
            }
            
            await Task.WhenAll(taskList.ToArray());
        }

        private async Task<List<IForumNode>> AddFakeBoards()
        {
            var boardCollection = new List<IForumNode>();

            for (int i = 0; i < Random.Next(10); i++)
            {
                var childrenBoards = new List<IForumNode>();

                await Task.Delay(1000 * Random.Next(10));

                if (Random.Next(10) == 0)
                    childrenBoards = await AddFakeBoards();

                boardCollection.Add(new Board("Board #" + i, childrenBoards, await AddFakeTopics()));
            }

            return boardCollection;
        }

        private async Task<List<IForumNode>> AddFakeTopics()
        {
            var topicCollection = new List<IForumNode>();

            for (int i = 0; i < Random.Next(10); i++)
            {
                var messageCollection = new List<IForumNode>();

                var topic = new Topic("Topic #" + i);

                await Task.Delay(1000 * Random.Next(10));

                for (int k = 0; k < Random.Next(5); k++)
                    messageCollection.Add(new Message("Message #" + k) { IsScrapingInProgress = false });

                topic.Messages = messageCollection;

                topicCollection.Add(topic);
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
