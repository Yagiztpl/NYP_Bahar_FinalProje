using Mahzen.Business.Abstract;
using Mahzen.Common.Config;
using Mahzen.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Business.Managers
{
    public class OyuncuManager : IOyuncuService
    {
        public static double OyunZorlukDegeri = 1;

        public void IlerlemeHesapla(Oyuncu Oyuncu)
        {
            switch (Oyuncu.Ilerleme)
            {
                case 10: Oyuncu.EsyaKilidi = 1; break;
                case 20: Oyuncu.EsyaKilidi = 2; break;
                default: Oyuncu.EsyaKilidi = 0; break;
            }
        }

        public Oyuncu OyuncuUret()
        {
            Oyuncu _Oyuncu = new Oyuncu();
            _Oyuncu.TabanCan = 20;
            _Oyuncu.TabanDayaniklilik = 5;
            _Oyuncu.TabanHiz = 3;
            _Oyuncu.TabanKarizma = 2;
            _Oyuncu.TabanMana = 20;
            _Oyuncu.TabanZeka = 3;
            _Oyuncu.TabanGuc = 3;
            _Oyuncu.Can = _Oyuncu.TabanCan;
            _Oyuncu.Dayaniklilik = _Oyuncu.TabanDayaniklilik;
            _Oyuncu.Hiz = _Oyuncu.TabanHiz;
            _Oyuncu.Karizma = _Oyuncu.TabanKarizma;
            _Oyuncu.Mana = _Oyuncu.TabanMana;
            _Oyuncu.Zeka = _Oyuncu.TabanZeka;
            _Oyuncu.Guc = _Oyuncu.TabanGuc;
            return _Oyuncu;
        }
        public void ZorlukHesabi(Oyuncu Oyuncu)
        {
            // (2 + 2.5 + 1.5 + 1 + 2 + 1 + 1)/10 = 1 = Taban Guc 
            double OyuncuGucu = ((Oyuncu.Can / 10) + (Oyuncu.Mana / 10) + (Oyuncu.Dayaniklilik / 2) + (Oyuncu.Hiz/2) + (Oyuncu.Karizma /2) + (Oyuncu.Zeka/3) + (Oyuncu.Guc/3))/10;
            double Zorluk = (Temel.TemelZorlukCarpani - 1) + OyuncuGucu;
            OyunZorlukDegeri = Zorluk;
        }
    }
}
