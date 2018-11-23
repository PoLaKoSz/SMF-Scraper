using PoLaKoSz.SMF.Scraper.Models;
using PoLaKoSz.SMF.Scraper.Themes.Metin2HungaryNet;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using PoLaKoSz.SMF.Scraper.EndPoints;
using PoLaKoSz.SMF.Scraper.Parsers;

namespace PoLaKoSz.SMF.Scraper.Tests.Integration.EndPoints
{
    class TopicEndPointTests
    {
        class FirstPage : TestClassBase
        {
            private readonly RootObject<Topic> _endPointResponse;



            public FirstPage()
                : base("Metin2Hungary.net", "Topic", "BlackStorm")
            {
                var httpClient = new HttpClientMock();
                var settings = new ForumSettings(new BlackStormTheme(), new Uri("https://polakosz.hu"), new CommaUrlParser());
                var endPoint = new TopicEndPoint(settings, httpClient);

                httpClient.ResponseHTML = base.GetHtmlData("2018_04_25_NonAuthenticated");
                _endPointResponse = endPoint.Info(new Topic(66925, "Gyors pénzszerzési ötletek azoknak akik 0ról kezdik ( m )")).GetAwaiter().GetResult();
            }



            [Test]
            public void Can_Extract_Messages()
            {
                var expected = new List<Message>()
                {

                };

                var actual = _endPointResponse.Data.Messages;

                foreach (var message in actual)
                {
                    System.IO.File.AppendAllText("page_1.txt", $"new Message({message.ID}, \"{message.Subject}\", \"{message.Body}\", new DateTime({message.PostedTime.Year},{message.PostedTime.Month},{message.PostedTime.Day}, {message.PostedTime.Hour},{message.PostedTime.Minute},{message.PostedTime.Second}, DateTimeKind.Utc)),\n");
                }

                CollectionAssert.AreEqual(expected, actual);
            }

            [Test]
            public void HasPreviousPage_Should_Be_False()
            {
                Assert.That(_endPointResponse.HasPreviousPage, Is.False, "_endPointResponse.HasPreviousPage");
            }

            [Test]
            public void PreviousPage_Should_Be_Null()
            {
                Assert.That(_endPointResponse.PreviousPage, Is.Null, "_endPointResponse.HasPreviousPage");
            }

            [Test]
            public void HasNextPage_Should_Be_True()
            {
                Assert.That(_endPointResponse.HasNextPage, Is.True, "_endPointResponse.HasNextPage");
            }

            [Test]
            public void NextPage_Should_Be_2()
            {
                Assert.That(_endPointResponse.NextPage, Is.EqualTo(2), "_endPointResponse.NextPage");
            }
        }

        class ThirdPage : TestClassBase
        {
            private readonly RootObject<Topic> _endPointResponse;



            public ThirdPage()
                : base("Metin2Hungary.net", "Topic", "BlackStorm")
            {
                var httpClient = new HttpClientMock();
                var settings = new ForumSettings(new BlackStormTheme(), new Uri("https://polakosz.hu"), new CommaUrlParser());
                var endPoint = new TopicEndPoint(settings, httpClient);

                httpClient.ResponseHTML = base.GetHtmlData("2018_11_22_03_NonAuthenticated");
                _endPointResponse = endPoint.Info(new Topic(66925, "Gyors pénzszerzési ötletek azoknak akik 0ról kezdik ( m )")).GetAwaiter().GetResult();
            }



            [Test]
            public void Can_Extract_Messages()
            {
                var expected = new List<Message>()
                {
                };

                var actual = _endPointResponse.Data.Messages;

                foreach (var message in actual)
                {
                    System.IO.File.AppendAllText("page_3.txt", $"new Message({message.ID}, \"{message.Subject}\", \"{message.Body}\", new DateTime({message.PostedTime.Year},{message.PostedTime.Month},{message.PostedTime.Day}, {message.PostedTime.Hour},{message.PostedTime.Minute},{message.PostedTime.Second}, DateTimeKind.Utc)),\n");
                }

                CollectionAssert.AreEqual(expected, actual);
            }

            [Test]
            public void HasPreviousPage_Should_Be_True()
            {
                Assert.That(_endPointResponse.HasPreviousPage, Is.True, "_endPointResponse.HasPreviousPage");
            }

            [Test]
            public void PreviousPage_Should_Be_2()
            {
                Assert.That(_endPointResponse.PreviousPage, Is.EqualTo(2), "_endPointResponse.HasPreviousPage");
            }

            [Test]
            public void HasNextPage_Should_Be_True()
            {
                Assert.That(_endPointResponse.HasNextPage, Is.True, "_endPointResponse.HasNextPage");
            }

            [Test]
            public void NextPage_Should_Be_4()
            {
                Assert.That(_endPointResponse.NextPage, Is.EqualTo(4), "_endPointResponse.NextPage");
            }
        }

        class LastPage : TestClassBase
        {
            private readonly RootObject<Topic> _endPointResponse;



            public LastPage()
                : base("Metin2Hungary.net", "Topic", "BlackStorm")
            {
                var httpClient = new HttpClientMock();
                var settings = new ForumSettings(new BlackStormTheme(), new Uri("https://polakosz.hu"), new CommaUrlParser());
                var endPoint = new TopicEndPoint(settings, httpClient);

                httpClient.ResponseHTML = base.GetHtmlData("2018_11_22_04_NonAuthenticated");
                _endPointResponse = endPoint.Info(new Topic(66925, "Gyors pénzszerzési ötletek azoknak akik 0ról kezdik ( m )")).GetAwaiter().GetResult();
            }



            [Test]
            public void Can_Extract_Messages()
            {
                var expected = new List<Message>()
                {

                };

                var actual = _endPointResponse.Data.Messages;

                foreach (var message in actual)
                {
                    System.IO.File.AppendAllText("page_4.txt", $"new Message({message.ID}, \"{message.Subject}\", \"{message.Body}\", new DateTime({message.PostedTime.Year},{message.PostedTime.Month},{message.PostedTime.Day}, {message.PostedTime.Hour},{message.PostedTime.Minute},{message.PostedTime.Second}, DateTimeKind.Utc)),\n");
                }

                CollectionAssert.AreEqual(expected, actual);
            }

            [Test]
            public void HasPreviousPage_Should_Be_True()
            {
                Assert.That(_endPointResponse.HasPreviousPage, Is.True, "_endPointResponse.HasPreviousPage");
            }

            [Test]
            public void PreviousPage_Should_Be_3()
            {
                Assert.That(_endPointResponse.PreviousPage, Is.EqualTo(3), "_endPointResponse.HasPreviousPage");
            }

            [Test]
            public void HasNextPage_Should_Be_False()
            {
                Assert.That(_endPointResponse.HasNextPage, Is.False, "_endPointResponse.HasNextPage");
            }

            [Test]
            public void NextPage_Should_Be_Null()
            {
                Assert.That(_endPointResponse.NextPage, Is.Null, "_endPointResponse.NextPage");
            }
        }
    }
}
