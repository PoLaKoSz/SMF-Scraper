using PoLaKoSz.SMF.Scraper.Models;
using PoLaKoSz.SMF.Scraper.Themes.Metin2HungaryNet;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using PoLaKoSz.SMF.Scraper.EndPoints;
using System.Threading.Tasks;

namespace PoLaKoSz.SMF.Scraper.Tests.Integration.EndPoints
{
    class TopicEndPointTests : TestClassBase
    {
        private ForumSettings _settings;
        private HttpClientMock _httpClient;



        [OneTimeSetUp]
        public void Init()
        {
            _settings = new ForumSettings(new BlackStormTheme(), new Uri("http://metin2hungary.test"));
            _httpClient = new HttpClientMock();
        }

        public TopicEndPointTests()
            : base("Metin2Hungary.net", "Topic", "BlackStorm") { }



        [Test]
        public async Task Can_Extract_From_First_Page()
        {
            var expected = new List<Message>()
            {
                new Message(487697, "Gyors pénzszerzési ötletek azoknak akik 0ról kezdik ( m )", "Tisztelt Játékosok!<br>Ezt a topicot azért nyitottam mert szeretném megnézni a véleményetek, hogy szerintetek hogy lehet gyorsan pénzhez jutni ha valaki 0-ról kezdi a játékot azaz semmi fegyver és semmi cucc.<br>Azért is kérdezem mivel nekem újra kellett kezdenem 0-ról, illetve más játékosoknak akik hasonló cipöben vannak mint én azoknak is elönyére válhat.<br>Elöre is várom a véleményeteket, ötleteteket!<br>Addig is további kellemes DDMT-zést, és Kellemes Húsvétot mindenkinek!<br>Tisztelettel: Empo444", new DateTime(2011,4,24, 20,37,0, DateTimeKind.Utc)),
            };

            _httpClient.ResponseHTML = base.GetHtmlData("2018_04_25_NonAuthenticated");
            var topic = await new TopicEndPoint(_settings, _httpClient).Info(new Topic(-1, "FakeTopic"));

            Assert.That(topic.Messages, Is.Not.Null, "actual.Messages");
            Assert.That(topic.Messages.Count, Is.EqualTo(25), "actual.Messages.Count");
            Assert.That(topic.Messages[0], Is.EqualTo(expected[0]), "topic.Messages[0]");
        }
    }
}
