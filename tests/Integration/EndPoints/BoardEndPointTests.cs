using PoLaKoSz.SMF.Scraper.Models;
using PoLaKoSz.SMF.Scraper.Themes.Metin2HungaryNet;
using PoLaKoSz.SMF.Scraper.Workers;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using PoLaKoSz.SMF.Scraper.Parsers;

namespace PoLaKoSz.SMF.Scraper.Tests.Integration.EndPoints
{
    class BoardEndPointTests
    {
        class FirstPage : TestClassBase
        {
            private readonly RootObject<Board> _endPointResponse;



            public FirstPage()
                : base("Metin2Hungary.net", "Board", "BlackStorm")
            {
                var httpClient = new HttpClientMock();
                var settings = new ForumSettings(new BlackStormTheme(), new Uri("https://polakosz.hu"), new CommaUrlParser());
                var endPoint = new BoardEndPoint(settings, httpClient);

                httpClient.ResponseHTML = base.GetHtmlData("2018_04_25_NonAuthenticated");
                _endPointResponse = endPoint.Info(new Board(5, "Segítség")).GetAwaiter().GetResult();
            }



            [Test]
            public void Can_Extract_Children_Boards()
            {
                var expected = new List<Board>()
                {
                    new Board(80, "Lezárt témák")
                };

                var actual = _endPointResponse.Data.ChildBoards;

                Assert.That(actual[0], Is.EqualTo(expected[0]));
            }

            [Test]
            public void Can_Extract_Topics()
            {
                var expected = new List<Topic>()
                {
                    new Topic(182615, "105 Fegyverek, Vétek, Ékszerek, Öv rendszer!"),
                    new Topic(48, "Amit a lovakról tudni kell"),
                    new Topic(28956, "Account Lopó Oldalak! ( m )"),
                    new Topic(162458, "Energiarendszer"),
                    new Topic(131773, "Felhívás! Letöltés előtt olvasd el!"),
                    new Topic(42920, "Skillek mértéke!"),
                    new Topic(29679, "Bónuszok hatása / felszerelhetősége 1-7opt!"),
                    new Topic(28399, "Skillek/Státuszok/Skill Újraosztás Lv.99"),
                    new Topic(23115, "Közös érdek!"),
                    new Topic(15300, "Amit a DT-ről tudni kell(Javított)"),
                    new Topic(200722, "[3ds max] run/walk animació probléma"),
                    new Topic(200469, "Tárgyak összerakása"),
                    new Topic(200370, "Farmos"),
                    new Topic(199627, "Kidobálás"),
                    new Topic(199124, "Hol csináljam a csata lovat?"),
                    new Topic(199526, "Ló név"),
                    new Topic(199191, "Fejlődés?"),
                    new Topic(199159, "Mikor nullázódik a pénz?"),
                    new Topic(199110, "48-as vértek"),
                    new Topic(198590, "Tőr ninja 6-7 opt (war)"),
                    new Topic(198199, "Elit kliens"),
                    new Topic(195437, "Sziasztok, aki ért surához, segitsen:D de aki tényleg ért"),
                    new Topic(195463, "2 kérdés, surgos!"),
                    new Topic(195344, "RunOk azrael stb ddmt 2"),
                    new Topic(195198, "max. alap tp"),
                    new Topic(195091, "Lelek2"),
                    new Topic(195063, "HELP"),
                    new Topic(193790, "email cím"),
                    new Topic(141892, "Miböl lehet megélni manapság??? ( m )"),
                    new Topic(191060, "DDMt2 Patcher."),
                    new Topic(106287, "Számítógép problémák!~Összevont! ( m )"),
                    new Topic(163070, "Szabadozó kari!! :D"),
                    new Topic(183812, "Ninja: tőr vs íjász Melyiket válasszam?"),
                    new Topic(185136, "Tőr Vs Gyógy? :D"),
                    new Topic(184334, "5/5 optok."),
                    new Topic(182555, "Kliens indítási hiba orvosolása? [HELP]"),
                    new Topic(178304, "Érdemes váltani? War karakter."),
                    new Topic(140709, "BM Sura vs MENTA Harcos?"),
                    new Topic(167738, "Bm vagy Wp? :oo"),
                    new Topic(165721, "Warra : Megfelelő karakter"),
                    new Topic(71594, "Warra Optok~Összevont ( m )"),
                    new Topic(166478, "Menta vagy testi??  Ez a kérdés. :D"),
                    new Topic(169687, "WP-nek félelem vagy a elv vértezés a jobb PVP-re"),
                    new Topic(9597, "Ezek mik és mire valók? ( m )"),
                    new Topic(167220, "Sárkány vagy Gyógy ?"),
                    new Topic(164112, "Ninja szakértők ide!:D"),
                    new Topic(166998, "Sura Sámi ellen? :D"),
                    new Topic(165891, "3D Hiba"),
                    new Topic(160619, "Szerintetek? Melyiket érdemesebb? :)"),
                    new Topic(159549, "Segitség és vélemény lb2-es farmoláshoz!"),
                };

                var actual = _endPointResponse.Data.Topics;

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

        class SecondPage : TestClassBase
        {
            private readonly RootObject<Board> _endPointResponse;



            public SecondPage()
                : base("Metin2Hungary.net", "Board", "BlackStorm")
            {
                var httpClient = new HttpClientMock();
                var settings = new ForumSettings(new BlackStormTheme(), new Uri("https://polakosz.hu"), new CommaUrlParser());
                var endPoint = new BoardEndPoint(settings, httpClient);

                httpClient.ResponseHTML = base.GetHtmlData("2018_04_25_02_NonAuthenticated");
                _endPointResponse = endPoint.Info(new Board(5, "Segítség")).GetAwaiter().GetResult();
            }



            [Test]
            public void Should_Not_Have_Children_Board()
            {
                var actual = _endPointResponse.Data.ChildBoards;

                Assert.That(actual, Is.Not.Null, "actual.Count");
                Assert.That(actual.Count, Is.EqualTo(0), "actual.Count");
            }

            [Test]
            public void Can_Extract_Topics()
            {
                var expected = new List<Topic>()
                {
                    new Topic(161450, "PvP Verseny ? ! :DDD"),
                    new Topic(162535, "Menta vs Testi?:DD"),
                    new Topic(156760, "Vértezés vagy a Félelem? :o"),
                    new Topic(162120, "FELHÁBORÍTÓ:D"),
                    new Topic(160023, "Wp vagy Tőr ninja?"),
                    new Topic(131388, "Hogyan optoljunk! ( m )"),
                    new Topic(129631, "Céh Jelek ( m )"),
                    new Topic(109338, "Vásárlás átverés/nélkül ( m )"),
                    new Topic(159708, "Bossok"),
                    new Topic(66925, "Gyors pénzszerzési ötletek azoknak akik 0ról kezdik ( m )"),
                    new Topic(158416, "Fórum kinézet visszaállítása"),
                    new Topic(147070, "War felszerelés! ( m )"),
                    new Topic(153469, "Mire való a bölcs császár szimbóluma?"),
                    new Topic(145268, "Milyen karit érdemes kezdeni PVP-re? ( m )"),
                    new Topic(151997, "Fejlődési tippek,avagy amire a kezdők kiváncsiak ( m )"),
                    new Topic(149846, "Tp elszívás & Harci mámor :)"),
                    new Topic(149000, "Ércek!"),
                    new Topic(147993, "Karakter törlés!( m )"),
                    new Topic(148221, "Élet gyümőlcse"),
                    new Topic(148216, "Üres Üveg"),
                    new Topic(148214, "Mibe lehet rakni 20% duplatárgyat?"),
                    new Topic(106644, "Krit poti ,Átható poti miből készül? ( m )"),
                    new Topic(148241, "Bölcs jegyzete??"),
                    new Topic(148225, "Hogyan??"),
                    new Topic(134874, "Képesség visszaállítás ( m )"),
                    new Topic(148239, "Zene"),
                    new Topic(70758, "Lélek Barlang 3"),
                    new Topic(148237, "Aranyrög"),
                    new Topic(148242, "Tűzijáték???"),
                    new Topic(148257, "Bónusz"),
                    new Topic(148248, "Ördög elleni erő ( m )"),
                    new Topic(148243, "DDMT2 horgászbot ( m )"),
                    new Topic(148258, "Villám ellenállás"),
                    new Topic(127401, "Karakter törlés ( m )"),
                    new Topic(120113, "Mi az a demi??? ( m )"),
                    new Topic(148256, "átható vs. krit"),
                    new Topic(124545, "10%Tp Eltunes ( m )"),
                    new Topic(124251, "Képesség váltás ( m )"),
                    new Topic(148255, "Láthatatlanság tükör ???"),
                    new Topic(109118, "KK Vs ÁK? ( m )"),
                    new Topic(148264, "DT kovács"),
                    new Topic(148267, "Valaki tudja mi a Kín?"),
                    new Topic(148287, "P skill egyszerüen HOGYAN?"),
                    new Topic(148276, "Def lélekbe a katonák ellen"),
                    new Topic(110786, "2 milliárd~Yang bug ( m )"),
                    new Topic(109016, "Bossok ölése ( m )"),
                    new Topic(106395, "Kvarchomok! ( m )"),
                    new Topic(65827, "Lélekbarlang 1-2 Farm! ( m )"),
                    new Topic(105623, "75-ös fegyver dropp ( m )"),
                    new Topic(61967, "Rangolási tippek ( m )")
                };

                var actual = _endPointResponse.Data.Topics;

                CollectionAssert.AreEqual(expected, actual);
            }

            [Test]
            public void HasPreviousPage_Should_Be_True()
            {
                Assert.That(_endPointResponse.HasPreviousPage, Is.True, "_endPointResponse.HasPreviousPage");
            }

            [Test]
            public void PreviousPage_Should_Be_1()
            {
                Assert.That(_endPointResponse.PreviousPage, Is.EqualTo(1), "_endPointResponse.HasPreviousPage");
            }

            [Test]
            public void HasNextPage_Should_Be_True()
            {
                Assert.That(_endPointResponse.HasNextPage, Is.True, "_endPointResponse.HasNextPage");
            }

            [Test]
            public void NextPage_Should_Be_3()
            {
                Assert.That(_endPointResponse.NextPage, Is.EqualTo(3), "_endPointResponse.NextPage");
            }
        }

        class LastPage : TestClassBase
        {
            private readonly RootObject<Board> _endPointResponse;



            public LastPage()
                : base("Metin2Hungary.net", "Board", "BlackStorm")
            {
                var httpClient = new HttpClientMock();
                var settings = new ForumSettings(new BlackStormTheme(), new Uri("https://polakosz.hu"), new CommaUrlParser());
                var endPoint = new BoardEndPoint(settings, httpClient);

                httpClient.ResponseHTML = base.GetHtmlData("2018_04_25_03_NonAuthenticated");
                _endPointResponse = endPoint.Info(new Board(5, "Segítség")).GetAwaiter().GetResult();
            }



            [Test]
            public void Should_Not_Have_Children_Board()
            {
                var actual = _endPointResponse.Data.ChildBoards;

                Assert.That(actual, Is.Not.Null, "actual.Count");
                Assert.That(actual.Count, Is.EqualTo(0), "actual.Count");
            }

            [Test]
            public void Can_Extract_Topics()
            {
                var expected = new List<Topic>()
                {
                    new Topic(105623, "75-ös fegyver dropp ( m )"),
                    new Topic(61967, "Rangolási tippek ( m )"),
                    new Topic(33, "Ércek - Kemencék ( m )"),
                    new Topic(100406, "max inteligencia ( m )"),
                    new Topic(97215, "Új fejlesztési itemek ( m )"),
                    new Topic(89105, "King Vért ( m )"),
                    new Topic(87154, "Lv 99-en kk olvasás ( m )"),
                    new Topic(72321, "OPT ( m )"),
                    new Topic(83191, "Látható OX vért! ( m )"),
                    new Topic(39592, "Vezetés ( m )"),
                    new Topic(82032, "Támadó érték ( m )"),
                    new Topic(82007, "Hack? Bug? ( m )"),
                    new Topic(81985, "Hol kérhetem le a raktár jelszavam? ( m )"),
                    new Topic(80174, "30-as fegyver dropp ( m )"),
                    new Topic(80265, "Defek értéke.! ( m )"),
                    new Topic(79850, "Nem 100%-os a Lélek előtti NPC? ( m )"),
                    new Topic(78626, "OPTok és STAT ( m )"),
                    new Topic(77940, "Hol érdemes növényeket farmolni?( m )"),
                    new Topic(31539, "Sé rendelés (m)"),
                    new Topic(75154, "WP lélek2 felszerelés ( m )"),
                    new Topic(74729, "Céhtelek-alkalmista ( m )"),
                    new Topic(74132, "About-nak Pár kérdés! ( m )"),
                    new Topic(72091, "Méreg ( m )"),
                    new Topic(71804, "Szerelempont ( m )"),
                    new Topic(71409, "Birodalom váltás ( m )"),
                    new Topic(68572, "Ében Vs Kristály ( m )"),
                    new Topic(67710, "Szent k. vs. Vágó k."),
                    new Topic(66848, "mennyi a max erő??? ( m )"),
                    new Topic(63136, "Hogy lehet olyan nagyot sebezni? ( m )"),
                    new Topic(60977, "Itemshop, ital ( m )"),
                    new Topic(52150, "Sebzés, avagy hogy adódnak össze a bónok? ( m )"),
                    new Topic(44996, "Mozgós avatar ( m )"),
                    new Topic(43083, "6-7 optok!!! ( m )"),
                    new Topic(33983, "Farm KING vért nélkül? Lehetséges? (m)"),
                    new Topic(33443, "Surára~sámira def ( m )"),
                    new Topic(31534, "Átlagkár vagy Készségkár(m)"),
                    new Topic(30790, "KK OLVASÁS HELP!!! ( m )"),
                    new Topic(26801, "A szellem kövek ( m )"),
                    new Topic(26273, "Lélek2 ( m )"),
                    new Topic(26242, "Vörös erdő vége ( m )"),
                    new Topic(25467, "Mi Mi ellen véd! ( m )"),
                    new Topic(22209, "Az a csúnya ájulás immun bug.....   (m)"),
                    new Topic(7965, "istennői könny mire jó?")
                };

                var actual = _endPointResponse.Data.Topics;

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
