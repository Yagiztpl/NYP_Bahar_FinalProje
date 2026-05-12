using Mahzen.Entities.Abstract;
using Mahzen.Entities.Concrete;
using Mahzen.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Common.Config
{
    public class Temel
    {
        public static double TemelZorlukCarpani = 1;
        //----- Hasarlar
        public static Dictionary<HasarTipi, Hasar> HasarKatalogu = new Dictionary<HasarTipi, Hasar>()
        {
            // Fiziksel Hasarlar
            { HasarTipi.Kesme, new Hasar { Sinif = HasarSinifi.Fiziksel, Surec = HasarSureci.Anlik, Taban = 2 } },
            { HasarTipi.Delme, new Hasar { Sinif = HasarSinifi.Fiziksel, Surec = HasarSureci.Anlik, Taban = 2 } },
            { HasarTipi.Ezme, new Hasar { Sinif = HasarSinifi.Fiziksel, Surec = HasarSureci.Anlik, Taban = 2 } },
            { HasarTipi.Patlama, new Hasar { Sinif = HasarSinifi.Fiziksel, Surec = HasarSureci.Anlik, Taban = 3 } },

            // Elemental Hasarlar
            { HasarTipi.Ates, new Hasar { Sinif = HasarSinifi.Element, Surec = HasarSureci.ZamanlaSabit, Taban = 4 } },
            { HasarTipi.Toksik, new Hasar { Sinif = HasarSinifi.Element, Surec = HasarSureci.ZamanlaYuzde, Taban = 0.3 } },
            { HasarTipi.Elektrik, new Hasar { Sinif = HasarSinifi.Element, Surec = HasarSureci.AnlikYuzde, Taban = 0.05 } },
            { HasarTipi.Su, new Hasar { Sinif = HasarSinifi.Element, Surec = HasarSureci.ZamanlaYuzde, Zayiflatma = ZayiflatmaTipi.StatDusurur, Taban = 0.1, StatOdagi = StatOdagi.Dayaniklilik } },
            { HasarTipi.Buz, new Hasar { Sinif = HasarSinifi.Element, Surec = HasarSureci.ZamanlaYuzde, Zayiflatma = ZayiflatmaTipi.StatDusurur, Taban = 0.1, StatOdagi = StatOdagi.Hiz } },
            { HasarTipi.Lanet, new Hasar { Sinif = HasarSinifi.Element, Surec = HasarSureci.AnlikYuzde, Taban = 0.15 } },

            // Zihinsel Hasarlar
            { HasarTipi.Ikna, new Hasar { Sinif = HasarSinifi.Zihinsel, Surec = HasarSureci.Anlik, Taban = 1} },
            { HasarTipi.Tehtid, new Hasar { Sinif = HasarSinifi.Zihinsel, Surec = HasarSureci.Anlik, Taban = 1} }
        };

        //----- İsimler
        public static Dictionary<Biyomlar, string[]> BiyomPrefixKatalogu = new Dictionary<Biyomlar, string[]>
        {
        { Biyomlar.Buz, new[] { "Kırağı", "Donmuş", "Kristal", "Kutup", "Kar" } },
        { Biyomlar.Lav, new[] { "Kor", "Magma", "Volkanik", "Ateşli", "Cehennem" } },
        { Biyomlar.Sahil, new[] { "Tuzlu", "Mercan", "Derinsu", "Dalga", "Batık" } },
        { Biyomlar.Orman, new[] { "Yosunlu", "Sarmaşık", "Kadim", "Vahşi", "Kuytu" } },
        { Biyomlar.Lanet, new[] { "Ruhsuz", "Çürük", "Kemik", "Uğursuz", "Melun" } },
        { Biyomlar.Dag, new[] { "Yüce", "Kaya", "Keskin", "Heybetli", "Sert" } },
        { Biyomlar.Magara, new[] { "Karanlık", "Yankılı", "Nemli", "Dipsiz", "Kör" } }
        };

        public static Dictionary<DusmanYonelimi, string[]> YonelimSifatKatalogu = new Dictionary<DusmanYonelimi, string[]>
        {
        { DusmanYonelimi.Fiziksel, new[] { "Dişli", "Zırhlı", "Vurucu", "Ezici", "Pençeli" } },
        { DusmanYonelimi.Buyu, new[] { "Rünik", "Mistik", "Işıltılı", "Gizemli", "Efsunlu" } },
        { DusmanYonelimi.Zihinsel, new[] { "Lirik", "Hipnotik", "Sinsi", "Sessiz", "Kışkırtıcı" } }
        };

        public static Dictionary<DusmanSinifi, string[]> SinifIsimKatalogu = new Dictionary<DusmanSinifi, string[]>()
        {
            {DusmanSinifi.Pusucu, new[] {"Suikastçi", "Pusucusu", "Gölge" }},
            {DusmanSinifi.Avci, new[] {"Düellocu", "Asker", "Tazı", "Katil" }},
            {DusmanSinifi.Av, new[] {"Boğa", "TekBoynuzlu", "Yaratık Sürüsü" }},
            {DusmanSinifi.Apex, new[] {"Titan", "Yok Edici", "Efsane" }},
        };

        //----- Eşya, Tüketilebilir ve Ekipmanlar.

        public static Dictionary<EsyaIsimleri, Esya> EsyaKatalogu = new Dictionary<EsyaIsimleri, Esya>()
        {
            // Kilit = 0
            { EsyaIsimleri.CurukOdun, new Materyal("10001") { Seviye = 0, Kilit = 0 } },
            { EsyaIsimleri.HayvanPostu, new Materyal("10002") { Seviye = 0, Kilit = 0 } },
            { EsyaIsimleri.SifaliOt, new Materyal("10003") { Seviye = 0, Kilit = 0 } },
            { EsyaIsimleri.KırıkKemik, new Materyal("10004") { Seviye = 0, Kilit = 0 } },

            // Kilit = 1
            { EsyaIsimleri.CelikKulce, new Materyal("10005") { Seviye = 0, Kilit = 1 } },
            { EsyaIsimleri.IslenmisDeri, new Materyal("10006") { Seviye = 0, Kilit = 1 } },
            { EsyaIsimleri.YaratikKesesi, new Materyal("10007") { Seviye = 0, Kilit = 1 } },
            { EsyaIsimleri.RunikToz, new Materyal("10008") { Seviye = 0, Kilit = 1 } },

            // Kilit = 2
            { EsyaIsimleri.TungstenKulce, new Materyal("10009") { Seviye = 0, Kilit = 2 } },
            { EsyaIsimleri.YaratikPulu, new Materyal("10010") { Seviye = 0, Kilit = 2 } },
            { EsyaIsimleri.PeriTozu, new Materyal("10011") { Seviye = 0, Kilit = 2 } },
            { EsyaIsimleri.BuyuKristali, new Materyal("10012") { Seviye = 0, Kilit = 2 } }
        };
    
        public static Dictionary<EsyaIsimleri, Ekipman> EkipmanKatalogu = new Dictionary<EsyaIsimleri, Ekipman>()
        {
            // Kilit = 0
            { EsyaIsimleri.DermeCatmaZirh, new Ekipman("20001") { Seviye = 0, Kilit = 0, Dayaniklilik = 5, Can = 5, HasarSinifi = HasarSinifi.Fiziksel } },
            { EsyaIsimleri.TahtaKalkan, new Ekipman("20002") { Seviye = 0, Kilit = 0, Dayaniklilik = 8, Hiz = -1, HasarSinifi = HasarSinifi.Fiziksel } },
            { EsyaIsimleri.EskiCubbe, new Ekipman("20003") { Seviye = 0, Kilit = 0, Zeka = 3, Mana = 10, HasarSinifi = HasarSinifi.Zihinsel } },
            { EsyaIsimleri.KemikHancer, new Ekipman("20004") { Seviye = 0, Kilit = 0, Guc = 4, Hiz = 4, HasarSinifi = HasarSinifi.Fiziksel } },

            // Kilit = 1
            { EsyaIsimleri.CelikKilic, new Ekipman("20005") { Seviye = 0, Kilit = 1, Guc = 12, Dayaniklilik = 2, HasarSinifi = HasarSinifi.Fiziksel } },
            { EsyaIsimleri.AgirCelikZirh, new Ekipman("20006") { Seviye = 0, Kilit = 1, Dayaniklilik = 20, Can = 20, Hiz = -3, HasarSinifi = HasarSinifi.Fiziksel } },
            { EsyaIsimleri.RunikAsa, new Ekipman("20007") { Seviye = 0, Kilit = 1, Zeka = 15, Mana = 25, HasarSinifi = HasarSinifi.Element } },
            { EsyaIsimleri.KeskinBalta, new Ekipman("20008") { Seviye = 0, Kilit = 1, Guc = 16, Hiz = -2, HasarSinifi = HasarSinifi.Fiziksel } },

            // Kilit = 2
            { EsyaIsimleri.TungstenAsa, new Ekipman("20009") { Seviye = 0, Kilit = 2, Guc = 28, Dayaniklilik = 10, HasarSinifi = HasarSinifi.Fiziksel } },
            { EsyaIsimleri.YaratikPuluZirh, new Ekipman("20010") { Seviye = 0, Kilit = 2, Dayaniklilik = 30, Can = 40, Hiz = 5, HasarSinifi = HasarSinifi.Element } },
            { EsyaIsimleri.KaranlikKristalAsa, new Ekipman("20011") { Seviye = 0, Kilit = 2, Zeka = 35, Mana = 80, Karizma = 5, HasarSinifi = HasarSinifi.Zihinsel } },
            { EsyaIsimleri.CehennemTirpani, new Ekipman("20012") { Seviye = 0, Kilit = 2, Guc = 35, Can = -10, Hiz = 10, HasarSinifi = HasarSinifi.Fiziksel } }
        };
    public static Dictionary<EsyaIsimleri, Tuketilebilir> TuketilebilirKatalogu = new Dictionary<EsyaIsimleri, Tuketilebilir>()
        {
            // Kilit = 0
            { EsyaIsimleri.KufluEkmek, new Tuketilebilir("30001") { Seviye = 0, Kilit = 0, OdakStat = "Can", EkledigiDeger = 15, Sure = null } },
            { EsyaIsimleri.KirliBandaj, new Tuketilebilir("30002") { Seviye = 0, Kilit = 0, OdakStat = "Can", EkledigiDeger = 10, Sure = null } },

            // Kilit = 1
            { EsyaIsimleri.SaglikIksiri, new Tuketilebilir("30003") { Seviye = 0, Kilit = 1, OdakStat = "Can", EkledigiDeger = 50, Sure = null } },
            { EsyaIsimleri.AdrenalinIgnesi, new Tuketilebilir("30004") { Seviye = 0, Kilit = 1, OdakStat = "Hiz", EkledigiDeger = 15, Sure = 3 } }, 

            // Kilit = 2
            { EsyaIsimleri.IhyaIksiri, new Tuketilebilir("30005") { Seviye = 0, Kilit = 2, OdakStat = "Can", EkledigiDeger = 200, Sure = null } },
            { EsyaIsimleri.YildirimParsomeni, new Tuketilebilir("30006") { Seviye = 0, Kilit = 2, OdakStat = "Zeka", EkledigiDeger = 50, Sure = 1 } }
        };
    }
}
