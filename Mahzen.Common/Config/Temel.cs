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
        { Biyomlar.Buz, new[] { "Kiraği", "Donmuş", "Kristal", "Kutup", "Kar" } },
        { Biyomlar.Lav, new[] { "Kor", "Magma", "Volkanik", "Ateşli", "Cehennem" } },
        { Biyomlar.Sahil, new[] { "Tuzlu", "Mercan", "Derinsu", "Dalga", "Batik" } },
        { Biyomlar.Orman, new[] { "Yosunlu", "Sarmaşik", "Kadim", "Vahşi", "Kuytu" } },
        { Biyomlar.Lanet, new[] { "Ruhsuz", "Çürük", "Kemik", "Uğursuz", "Melun" } },
        { Biyomlar.Dag, new[] { "Yüce", "Kaya", "Keskin", "Heybetli", "Sert" } },
        { Biyomlar.Magara, new[] { "Karanlik", "Yankili", "Nemli", "Dipsiz", "Kör" } }
        };

        public static Dictionary<DusmanYonelimi, string[]> YonelimSifatKatalogu = new Dictionary<DusmanYonelimi, string[]>
        {
        { DusmanYonelimi.Fiziksel, new[] { "Dişli", "Zirhli", "Vurucu", "Ezici", "Pençeli" } },
        { DusmanYonelimi.Buyu, new[] { "Rünik", "Mistik", "Işiltili", "Gizemli", "Efsunlu" } },
        { DusmanYonelimi.Zihinsel, new[] { "Lirik", "Hipnotik", "Sinsi", "Sessiz", "Kişkirtici" } }
        };

        public static Dictionary<DusmanSinifi, string[]> SinifIsimKatalogu = new Dictionary<DusmanSinifi, string[]>()
        {
            {DusmanSinifi.Pusucu, new[] {"Suikastçi", "Pusucusu", "Gölge" }},
            {DusmanSinifi.Avci, new[] {"Düellocu", "Asker", "Tazi", "Katil" }},
            {DusmanSinifi.Av, new[] {"Boğa", "TekBoynuzlu", "Yaratik Sürüsü" }},
            {DusmanSinifi.Apex, new[] {"Titan", "Yok Edici", "Efsane" }},
        };

        //----- Eşya, Tüketilebilir ve Ekipmanlar.

        public static Dictionary<EsyaIsimleri, Esya> EsyaKatalogu = new Dictionary<EsyaIsimleri, Esya>()
{
    // Kilit = 0
    { EsyaIsimleri.CurukOdun, new Materyal("10001") { Isim = "Çürük Odun", Seviye = 0, Kilit = 0 } },
    { EsyaIsimleri.HayvanPostu, new Materyal("10002") { Isim = "Hayvan Postu", Seviye = 0, Kilit = 0 } },
    { EsyaIsimleri.SifaliOt, new Materyal("10003") { Isim = "Şifali Ot", Seviye = 0, Kilit = 0 } },
    { EsyaIsimleri.KirikKemik, new Materyal("10004") { Isim = "Kirik Kemik", Seviye = 0, Kilit = 0 } },

    // Kilit = 1
    { EsyaIsimleri.CelikKulce, new Materyal("10005") { Isim = "Çelik Külçe", Seviye = 0, Kilit = 1 } },
    { EsyaIsimleri.IslenmisDeri, new Materyal("10006") { Isim = "İşlenmiş Deri", Seviye = 0, Kilit = 1 } },
    { EsyaIsimleri.YaratikKesesi, new Materyal("10007") { Isim = "Yaratik Kesesi", Seviye = 0, Kilit = 1 } },
    { EsyaIsimleri.RunikToz, new Materyal("10008") { Isim = "Rünik Toz", Seviye = 0, Kilit = 1 } },

    // Kilit = 2
    { EsyaIsimleri.TungstenKulce, new Materyal("10009") { Isim = "Tungsten Külçe", Seviye = 0, Kilit = 2 } },
    { EsyaIsimleri.YaratikPulu, new Materyal("10010") { Isim = "Yaratik Pulu", Seviye = 0, Kilit = 2 } },
    { EsyaIsimleri.PeriTozu, new Materyal("10011") { Isim = "Peri Tozu", Seviye = 0, Kilit = 2 } },
    { EsyaIsimleri.BuyuKristali, new Materyal("10012") { Isim = "Büyü Kristali", Seviye = 0, Kilit = 2 } }
};

        public static Dictionary<EsyaIsimleri, Ekipman> EkipmanKatalogu = new Dictionary<EsyaIsimleri, Ekipman>()
{
    // Kilit = 0
    { EsyaIsimleri.HasarliZirh, new Ekipman("20001") {
        Isim = "Hasarli Zirh", Seviye = 0, Kilit = 0, Dayaniklilik = 5, Can = 5, HasarSinifi = HasarSinifi.Fiziksel,
        UretimTarifi = new List<Esya> {
            new Materyal("10001"), new Materyal("10001"), new Materyal("10001"),
            new Materyal("10002"), new Materyal("10002")
        }
    } },
    { EsyaIsimleri.TahtaKalkan, new Ekipman("20002") { Isim = "Tahta Kalkan", Seviye = 0, Kilit = 0, Dayaniklilik = 8, Hiz = -1, HasarSinifi = HasarSinifi.Fiziksel } },
    { EsyaIsimleri.EskiCubbe, new Ekipman("20003") { Isim = "Eski Cübbe", Seviye = 0, Kilit = 0, Zeka = 3, Mana = 10, HasarSinifi = HasarSinifi.Zihinsel } },
    { EsyaIsimleri.KemikHancer, new Ekipman("20004") { Isim = "Kemik Hançer", Seviye = 0, Kilit = 0, Guc = 4, Hiz = 4, HasarSinifi = HasarSinifi.Fiziksel } },

    // Kilit = 1
    { EsyaIsimleri.CelikKilic, new Ekipman("20005") {
        Isim = "Çelik Kiliç", Seviye = 0, Kilit = 1, Guc = 12, Dayaniklilik = 2, HasarSinifi = HasarSinifi.Fiziksel,
        UretimTarifi = new List<Esya> {
            new Materyal("10005"), new Materyal("10005"), new Materyal("10005"),
            new Materyal("10006"), new Materyal("10004")
        }
    } },
    { EsyaIsimleri.CelikZirh, new Ekipman("20006") { Isim = "Çelik Zirh", Seviye = 0, Kilit = 1, Dayaniklilik = 20, Can = 20, Hiz = -3, HasarSinifi = HasarSinifi.Fiziksel } },
    { EsyaIsimleri.RunikAsa, new Ekipman("20007") { Isim = "Rünik Asa", Seviye = 0, Kilit = 1, Zeka = 15, Mana = 25, HasarSinifi = HasarSinifi.Element } },
    { EsyaIsimleri.KeskinBalta, new Ekipman("20008") { Isim = "Keskin Balta", Seviye = 0, Kilit = 1, Guc = 16, Hiz = -2, HasarSinifi = HasarSinifi.Fiziksel } },

    // Kilit = 2
    { EsyaIsimleri.TungstenAsa, new Ekipman("20009") {
        Isim = "Tungsten Asa", Seviye = 0, Kilit = 2, Guc = 28, Dayaniklilik = 10, HasarSinifi = HasarSinifi.Element,
        UretimTarifi = new List<Esya> {
            new Materyal("10009"), new Materyal("10009"), new Materyal("10009"), new Materyal("10009"),
            new Materyal("10012"), new Materyal("10012")
        }
    } },
    { EsyaIsimleri.PulZirh, new Ekipman("20010") { Isim = "Pul Zirh", Seviye = 0, Kilit = 2, Dayaniklilik = 30, Can = 40, Hiz = 5, HasarSinifi = HasarSinifi.Element } },
    { EsyaIsimleri.KristalAsa, new Ekipman("20011") { Isim = "Kristal Asa", Seviye = 0, Kilit = 2, Zeka = 35, Mana = 80, Karizma = 5, HasarSinifi = HasarSinifi.Zihinsel } },
    { EsyaIsimleri.CehennemTirpani, new Ekipman("20012") { Isim = "Cehennem Tirpani", Seviye = 0, Kilit = 2, Guc = 35, Can = -10, Hiz = 10, HasarSinifi = HasarSinifi.Fiziksel } }
};

        public static Dictionary<EsyaIsimleri, Tuketilebilir> TuketilebilirKatalogu = new Dictionary<EsyaIsimleri, Tuketilebilir>()
{
    // Kilit = 0
    { EsyaIsimleri.KufluEkmek, new Tuketilebilir("30001") { Isim = "Küflü Ekmek", Seviye = 0, Kilit = 0, OdakStat = "Can", EkledigiDeger = 15, Sure = null } },
    { EsyaIsimleri.KirliBandaj, new Tuketilebilir("30002") { Isim = "Kirli Bandaj", Seviye = 0, Kilit = 0, OdakStat = "Can", EkledigiDeger = 10, Sure = null } },

    // Kilit = 1
    { EsyaIsimleri.SaglikIksiri, new Tuketilebilir("30003") { Isim = "Sağlik İksiri", Seviye = 0, Kilit = 1, OdakStat = "Can", EkledigiDeger = 50, Sure = null } },
    { EsyaIsimleri.AdrenalinIgnesi, new Tuketilebilir("30004") { Isim = "Adrenalin İğnesi", Seviye = 0, Kilit = 1, OdakStat = "Hiz", EkledigiDeger = 15, Sure = 3 } }, 

    // Kilit = 2
    { EsyaIsimleri.IhyaIksiri, new Tuketilebilir("30005") { Isim = "İhya İksiri", Seviye = 0, Kilit = 2, OdakStat = "Can", EkledigiDeger = 200, Sure = null } },
    { EsyaIsimleri.YildirimParsomeni, new Tuketilebilir("30006") { Isim = "Yildirim Parşömeni", Seviye = 0, Kilit = 2, OdakStat = "Zeka", EkledigiDeger = 50, Sure = 1 } }
};
    }
}
