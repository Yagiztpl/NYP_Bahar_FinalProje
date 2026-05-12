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
        
        public Harita HaritaUret()
        {
            Harita _Harita = new Harita();
            // Şan/Zorluk
            _Harita.Sans = _random.Next(1 + Convert.ToInt32(_Zorluk * 5)+1);
            _Harita.HaritaZorlugu = _random.Next(1 + Convert.ToInt32(5 * _Zorluk)+1);
            //Biyom/Oda
            int biyomSayisi = Enum.GetNames(typeof(Biyomlar)).Length;
            _Harita.Biyom = (Biyomlar)_random.Next(0, biyomSayisi);
            _Harita.OdaSayisi = _random.Next(1,21+(int)_Zorluk);
            for (int i = 0; i < _Harita.OdaSayisi; i++)
            {
                _Harita.Odalar.Add(OdaUret(_Harita));
            }
            return _Harita;
        }
        public Oda OdaUret(Harita Harita)
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
                _Oda.Dusmanlar.Add(DusmanUret(_Oda, Harita));
            }
            return _Oda;
        }

        public Dusman DusmanUret(Oda Oda, Harita Harita)
        {
            Dusman _Dusman = new Dusman();
            int enumSayisi = Enum.GetNames(typeof(DusmanSinifi)).Length;
            _Dusman.Sinif = (DusmanSinifi)_random.Next(0,enumSayisi);
            enumSayisi = Enum.GetNames(typeof(DusmanYonelimi)).Length;
            _Dusman.Yonelim = (DusmanYonelimi)_random.Next(0, enumSayisi);
            // Zayıflık/direnç
            enumSayisi = Enum.GetNames(typeof(HasarTipi)).Length;
            for (int i = 0; i < _random.Next(1,7); i++)
            {
                int r = _random.Next(0, 2);
                if (r == 1)
                _Dusman.Direnc.Add((HasarTipi)_random.Next(0,enumSayisi));
                else
                _Dusman.Zayiflik.Add((HasarTipi)_random.Next(0, enumSayisi));
            }
            // isim
            string[] prefixler = Temel.BiyomPrefixKatalogu[Harita.Biyom];
            string[] sifatlar = Temel.YonelimSifatKatalogu[_Dusman.Yonelim];
            string[] isimler = Temel.SinifİsimKatalogu[_Dusman.Sinif];
            _Dusman.Isim = $"{prefixler[_random.Next(prefixler.Length)]} {sifatlar[_random.Next(sifatlar.Length)]} {isimler[_random.Next(isimler.Length)]}";
            // Diğer statlar
            double TabanÇarpan = 1.2 * _Zorluk;
            _Dusman.Can = TabanÇarpan * _random.Next(15,31);
            _Dusman.Guc = TabanÇarpan * _random.Next(5, 16);
            _Dusman.Dayaniklilik = TabanÇarpan * _random.Next(5, 16);
            _Dusman.Hiz = TabanÇarpan * _random.Next(5, 16);
            _Dusman.Zeka = TabanÇarpan * _random.Next(5, 16);
            _Dusman.Karizma = -1; // Oyuncu özgü, sonradan özel düzenleme yaparsam diye tuttum.
            _Dusman.Mana = -1; //Düşman manasını takip edecek bir method yazarak zaman kaybetmek istemedim.

            //Sınıflandırma
            switch (_Dusman.Sinif)
            {
                case DusmanSinifi.Avci:
                    _Dusman.Can *= 1.2;
                    _Dusman.Guc *= 1.2;
                    _Dusman.Dayaniklilik *= 1.2;
                    _Dusman.Hiz *= 0.8;
                    _Dusman.Zeka *= 0.6;
                    break;

                case DusmanSinifi.Pusucu:
                    _Dusman.Can *= 0.6;
                    _Dusman.Guc *= 1.5;
                    _Dusman.Dayaniklilik *= 0.6;
                    _Dusman.Hiz *= 1.5;
                    _Dusman.Zeka *= 0.8;
                    break;

                case DusmanSinifi.Av:
                    _Dusman.Can *= 2;
                    _Dusman.Guc *= 0.6;
                    _Dusman.Dayaniklilik *= 1;
                    _Dusman.Hiz *= 0.6;
                    _Dusman.Zeka *= 0.8;
                    break;

                case DusmanSinifi.Apex:
                    _Dusman.Can *= 1.2;
                    _Dusman.Guc *= 1;
                    _Dusman.Dayaniklilik *= 1.2;
                    _Dusman.Hiz *= 1;
                    _Dusman.Zeka *= 1;
                    break;
            }
            return _Dusman;
        }
    }
}
