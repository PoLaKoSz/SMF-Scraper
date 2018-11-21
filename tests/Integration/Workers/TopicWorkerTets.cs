using PoLaKoSz.SMF.Scraper.Models;
using PoLaKoSz.SMF.Scraper.Themes.Metin2HungaryNet;
using PoLaKoSz.SMF.Scraper.Workers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace PoLaKoSz.SMF.Scraper.Tests.Integration.Workers
{
    class TopicWorkerTets
    {
        public class GetMessagesMethod
        {
            [Test]
            public void BlackStormTheme_WithoutAuthentication_TopicWorker_GetMessages_FirstPage()
            {
                var expected = new List<Message>()
                {
                    new Message(487697, "Gyors pénzszerzési ötletek azoknak akik 0ról kezdik ( m )", "Tisztelt Játékosok!<br>Ezt a topicot azért nyitottam mert szeretném megnézni a véleményetek, hogy szerintetek hogy lehet gyorsan pénzhez jutni ha valaki 0-ról kezdi a játékot azaz semmi fegyver és semmi cucc.<br>Azért is kérdezem mivel nekem újra kellett kezdenem 0-ról, illetve más játékosoknak akik hasonló cipöben vannak mint én azoknak is elönyére válhat.<br>Elöre is várom a véleményeteket, ötleteteket!<br>Addig is további kellemes DDMT-zést, és Kellemes Húsvétot mindenkinek!<br>Tisztelettel: Empo444", new DateTime(2011,4,24, 20,37,0, DateTimeKind.Utc)),
                };

                var sourceCode = File.ReadAllText(@"StaticResource\Metin2Hungary.net\Topic\BlackStorm\2018_04_25_NonAuthenticated.html");
                var actual = new TopicWorker(sourceCode, new BlackStormTheme())
                    .GetMessages();

                //CollectionAssert.AreEqual(expected, actual);
                Assert.AreEqual(expected[0], actual[0]);
            }
        }
    }
}
