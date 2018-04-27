using System.Collections.Generic;

namespace SMF_Scraper.WPF.Models
{
    public class TestData
    {
        public IList<IForumNode> Categories { get; set; }

        public TestData()
        {
            Categories = new List<IForumNode>();

            var brd1 = new Board()
            {
                Key = 1,
                Name = "Board #1",
                ChildBoards = new List<IForumNode>(),
                Topics = new List<IForumNode>()
                {
                    new Topic("Topic #1")
                    {
                        Messages = new List<IForumNode>()
                        {
                            new Message() { Name = "Message #1" },
                            new Message() { Name = "Message #2" },
                            new Message() { Name = "Message #3" },
                        },
                    },
                    new Topic("Topic #2"),
                    new Topic("Topic #3"),
                    new Topic("Topic #4"),
                },
            };
            var brd3 = new Board()
            {
                Key = 1,
                Name = "Board #3",
                ChildBoards = new List<IForumNode>()
                {
                    brd1,
                },
                Topics = new List<IForumNode>()
                {
                    new Topic("Topic #5"),
                    new Topic("Topic #6")
                    {
                        Messages = new List<IForumNode>()
                        {
                            new Message() { Name = "Message #10" },
                            new Message() { Name = "Message #11" },
                            new Message() { Name = "Message #12" },
                        }
                    },
                    new Topic("Topic #7"),
                    new Topic("Topic #8"),
                },                
            };
            var brd2 = new Board()
            {
                Key = 1,
                Name = "Board #2",
                ChildBoards = new List<IForumNode>()
                {
                    brd3,
                },
                Topics = new List<IForumNode>()
                {
                    new Topic("Topic #09"),
                    new Topic("Topic #10"),
                    new Topic("Topic #11")
                    {
                        Messages = new List<IForumNode>()
                        {
                            new Message() { Name = "Message #4" },
                            new Message() { Name = "Message #5" },
                            new Message() { Name = "Message #6" },
                        }
                    },
                    new Topic("Topic #12"),
                },                
            };

            var ctg1 = new Category("Category #1")
            {
                Boards = new List<IForumNode>()
                {
                    brd1,
                },
            };

            var ctg2 = new Category("Category #2")
            {
                Boards = new List<IForumNode>()
                {
                    brd1,
                    brd2,
                    brd3,
                },
            };


            Categories.Add(ctg1);
            Categories.Add(ctg2);
        }
    }
}
