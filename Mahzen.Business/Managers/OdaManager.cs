using Mahzen.Common.Config;
using Mahzen.Entities.Abstract;
using Mahzen.Entities.Concrete;
using Mahzen.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Business.Managers
{
    public class OdaManager
    {
        private Random _random = new Random();
        private double _Zorluk = OyuncuManager.OyunZorlukDegeri;
        
        public Harita HaritaUret(int oyuncuEsyaKilidi)
        {
            Harita _Harita = new Harita();
            // Şan/Zorluk
            _Harita.Sans = _random.Next(1 + Convert.ToInt32(_Zorluk * 5)+1);
            _Harita.HaritaZorlugu = _random.Next(1 + Convert.ToInt32(5 * _Zorluk)+1);
            _Harita.DonusHakki = 3;
            //Biyom/Oda
            int biyomSayisi = Enum.GetNames(typeof(Biyomlar)).Length;
            _Harita.Biyom = (Biyomlar)_random.Next(0, biyomSayisi);
            _Harita.OdaSayisi = _random.Next(1,21+(int)_Zorluk);
            for (int i = 0; i < _Harita.OdaSayisi; i++)
            {
                _Harita.Odalar.Add(OdaUret(_Harita,oyuncuEsyaKilidi));
            }
            return _Harita;
        }
        public Oda OdaUret(Harita Harita, int oyuncuEsyaKilidi)
        {
            Oda _Oda = new Oda();
            int enumVaryantlari;
            enumVaryantlari = Enum.GetNames(typeof(OdaTipi)).Length;
            _Oda.OdaTipi = (OdaTipi)_random.Next(1, enumVaryantlari);
            switch (_Oda.OdaTipi)
            {
                case OdaTipi.Savas: _Oda.DusmanSayisi = _random.Next(1, Convert.ToInt32(Harita.HaritaZorlugu/2)); break;
                case OdaTipi.Arena: _Oda.DusmanSayisi = _random.Next(2, Convert.ToInt32(Harita.HaritaZorlugu)); break;
            }
            for (int i = 0; i < _Oda.DusmanSayisi; i++)
            {
                _Oda.Dusmanlar.Add(DusmanUret(_Oda, Harita,oyuncuEsyaKilidi));
            }
            return _Oda;
        }

        public Dusman DusmanUret(Oda Oda, Harita Harita, int oyuncuEsyaKilidi)
        {
            Dusman _Dusman = new Dusman();
            int enumSayisi = Enum.GetNames(typeof(DusmanSinifi)).Length;
            _Dusman.Sinif = (DusmanSinifi)_random.Next(0, enumSayisi);
            enumSayisi = Enum.GetNames(typeof(DusmanYonelimi)).Length;
            _Dusman.Yonelim = (DusmanYonelimi)_random.Next(0, enumSayisi);
            // Zayıflık/direnç
            enumSayisi = Enum.GetNames(typeof(HasarTipi)).Length;
            for (int i = 0; i < _random.Next(1, 7); i++)
            {
                int r = _random.Next(0, 2);
                if (r == 1)
                    _Dusman.Direnc.Add((HasarTipi)_random.Next(0, enumSayisi));
                else
                    _Dusman.Zayiflik.Add((HasarTipi)_random.Next(0, enumSayisi));
            }
            enumSayisi = Enum.GetNames(typeof(DusmanParcalari)).Length;
            for (int i = 0; i < _random.Next(1, 3); i++)
            {
                int r = _random.Next(0, 2);
                if (r == 1)
                    _Dusman.DayanikliBolgeler.Add((DusmanParcalari)_random.Next(0, enumSayisi));
                else
                    _Dusman.ZayifBolgeler.Add((DusmanParcalari)_random.Next(0, enumSayisi));
            }
            // isim
            string[] prefixler = Temel.BiyomPrefixKatalogu[Harita.Biyom];
            string[] sifatlar = Temel.YonelimSifatKatalogu[_Dusman.Yonelim];
            string[] isimler = Temel.SinifIsimKatalogu[_Dusman.Sinif];
            _Dusman.Isim = $"{prefixler[_random.Next(prefixler.Length)]} {sifatlar[_random.Next(sifatlar.Length)]} {isimler[_random.Next(isimler.Length)]}";
            // Diğer statlar
            double TabanÇarpan = 1.2 * _Zorluk;
            _Dusman.TabanCan = TabanÇarpan * _random.Next(15, 31);
            _Dusman.TabanGuc = TabanÇarpan * _random.Next(5, 16);
            _Dusman.TabanDayaniklilik = TabanÇarpan * _random.Next(5, 16);
            _Dusman.TabanHiz = TabanÇarpan * _random.Next(5, 16);
            _Dusman.TabanZeka = TabanÇarpan * _random.Next(5, 16);
            _Dusman.TabanKarizma = -1; // Oyuncu özgü, sonradan özel düzenleme yaparsam diye tuttum.
            _Dusman.TabanMana = -1; //Düşman manasını takip edecek bir method yazarak zaman kaybetmek istemedim.

            //Sınıflandırma
            switch (_Dusman.Sinif)
            {
                case DusmanSinifi.Avci:
                    _Dusman.TabanCan *= 1.2;
                    _Dusman.TabanGuc *= 1.2;
                    _Dusman.TabanDayaniklilik *= 1.2;
                    _Dusman.TabanHiz *= 0.8;
                    _Dusman.TabanZeka *= 0.6;
                    break;

                case DusmanSinifi.Pusucu:
                    _Dusman.TabanCan *= 0.6;
                    _Dusman.TabanGuc *= 1.5;
                    _Dusman.TabanDayaniklilik *= 0.6;
                    _Dusman.TabanHiz *= 1.5;
                    _Dusman.TabanZeka *= 0.8;
                    break;

                case DusmanSinifi.Av:
                    _Dusman.TabanCan *= 2;
                    _Dusman.TabanGuc *= 0.6;
                    _Dusman.TabanDayaniklilik *= 1;
                    _Dusman.TabanHiz *= 0.6;
                    _Dusman.TabanZeka *= 0.8;
                    break;

                case DusmanSinifi.Apex:
                    _Dusman.TabanCan *= 1.2;
                    _Dusman.TabanGuc *= 1;
                    _Dusman.TabanDayaniklilik *= 1.2;
                    _Dusman.TabanHiz *= 1;
                    _Dusman.TabanZeka *= 1;
                    break;

            }
            _Dusman.Can = _Dusman.TabanCan;
            _Dusman.Dayaniklilik = _Dusman.TabanDayaniklilik;
            _Dusman.Hiz = _Dusman.TabanHiz;
            _Dusman.Karizma = _Dusman.TabanKarizma;
            _Dusman.Mana = _Dusman.TabanMana;
            _Dusman.Zeka = _Dusman.TabanZeka;
            _Dusman.Guc = _Dusman.TabanGuc;
            // Loot
            EnvanterManager _EnvanterManager = new EnvanterManager();
            OyunManager _OyunManager = new OyunManager();
            var uygunEkipmanlar = Temel.EkipmanKatalogu.Values.Where(e => e.Kilit <= oyuncuEsyaKilidi).ToList();
            int[] SlotSanslari = { (int)Math.Ceiling(50 * _Zorluk), (int)Math.Ceiling(30 * _Zorluk), (int)Math.Ceiling(15 * _Zorluk), (int)Math.Ceiling(5 * _Zorluk) };
            if (Yuzde.YuzdeRandom(SlotSanslari) >= 1)
            {
                Ekipman equipment0 = _OyunManager.EkipmanOlustur(uygunEkipmanlar[_random.Next(uygunEkipmanlar.Count)]);
                _EnvanterManager.EkipmanKusan(_Dusman, equipment0);
                _Dusman.Ekipman_Lootable.Add(equipment0);
            }
            if (Yuzde.YuzdeRandom(SlotSanslari) >= 2)
            {
                Ekipman equipment1 = _OyunManager.EkipmanOlustur(uygunEkipmanlar[_random.Next(uygunEkipmanlar.Count)]);
                _EnvanterManager.EkipmanKusan(_Dusman, equipment1);
                _Dusman.Ekipman_Lootable.Add(equipment1);
            }
            if (Yuzde.YuzdeRandom(SlotSanslari) >= 3)
            {
                Ekipman equipment2 = _OyunManager.EkipmanOlustur(uygunEkipmanlar[_random.Next(uygunEkipmanlar.Count)]);
                _EnvanterManager.EkipmanKusan(_Dusman, equipment2);
                _Dusman.Ekipman_Lootable.Add(equipment2);
            }
            var uygunEsyalar = Temel.EsyaKatalogu.Values.Where(e => e.Kilit <= oyuncuEsyaKilidi).ToList();
            Esya secilenesya = uygunEsyalar[_random.Next(uygunEsyalar.Count)];
            Esya Item0 = new Esya(secilenesya.ID);
            _Dusman.Esya_Lootable.Add(Item0);
            if (_random.Next(1,5) == 4)
            {
                var uygunTuketilebilirler = Temel.TuketilebilirKatalogu.Values.Where(e => e.Kilit <= oyuncuEsyaKilidi).ToList();
                Tuketilebilir secilenTuketilebilir = uygunTuketilebilirler[_random.Next(uygunEsyalar.Count)];
                Tuketilebilir Item1 = new Tuketilebilir(secilenTuketilebilir.ID)
                {
                    Sure = secilenTuketilebilir.Sure,
                    OdakStat = secilenTuketilebilir.OdakStat,
                    EkledigiDeger = secilenTuketilebilir.EkledigiDeger,
                };
                _Dusman.Tuketilebilir_Lootable.Add(Item1);
            }
            return _Dusman;
        }
    }
}
