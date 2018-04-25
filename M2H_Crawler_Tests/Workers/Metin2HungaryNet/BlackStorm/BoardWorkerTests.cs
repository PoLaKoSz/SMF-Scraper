using M2H_Crawler.Models;
using M2H_Crawler.Themes.Metin2HungaryNet;
using M2H_Crawler.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace M2H_Crawler_Tests.Workers.Metin2HungaryNet.BlackStorm
{
    [TestClass]
    public class BoardWorkerTests
    {
        [TestMethod]
        public void BlackStormTheme_WithoutAuthentication_BoardWorker_GetChildrenBoards()
        {
            var expected = new List<Board>()
            {
                new Board(80, 2, "Lezárt témák", 0),
            };

            var sourceCode = File.ReadAllText("StaticResource/Metin2Hungary.net/Board/BlackStorm/2018_04_25_NonAuthenticated.html");
            var     actual = new BoardWorker(sourceCode, new BlackStormTheme())
                .GetChildrenBoards();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestClass]
        public class GetBoardTopicsMethod
        {
            [TestMethod]
            public void BlackStormTheme_WithoutAuthentication_BoardWorker_GetBoardTopics_FirstPage()
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

                var sourceCode = File.ReadAllText(@"StaticResource\Metin2Hungary.net\Board\BlackStorm\2018_04_25_NonAuthenticated.html");
                var actual = new BoardWorker(sourceCode, new BlackStormTheme())
                    .GetBoardTopics();

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void BlackStormTheme_WithoutAuthentication_BoardWorker_GetBoardTopics_NotFirstPage()
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
                    new Topic(61967, "Rangolási tippek ( m )"),
                };

                var sourceCode = File.ReadAllText(@"StaticResource\Metin2Hungary.net\Board\BlackStorm\2018_04_25_02_NonAuthenticated.html");
                var actual = new BoardWorker(sourceCode, new BlackStormTheme())
                    .GetBoardTopics();

                CollectionAssert.AreEqual(expected, actual);
            }
        }
    }
}
