using Mahzen.Common.Config;
using Mahzen.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Business.Managers
{
    public class OyuncuManager
    {
        public static double OyunZorlukDegeri = 1;
        public Oyuncu OyuncuUret()
        {
            Oyuncu _Oyuncu = new Oyuncu();
            _Oyuncu.Can = 20;
            _Oyuncu.Dayaniklilik = 5;
            _Oyuncu.Hiz = 3;
            _Oyuncu.Karizma = 2;
            _Oyuncu.Mana = 20;
            _Oyuncu.Zeka = 3;
            _Oyuncu.Guc = 3;
            return _Oyuncu;
        }
        public void ZorlukHesabi(Oyuncu Oyuncu)
        {
            // (2 + 2.5 + 1.5 + 1 + 2 + 1 + 1)/10 = 1 = Taban Guc 
            double OyuncuGucu = ((Oyuncu.Can / 10) + (Oyuncu.Mana / 10) + (Oyuncu.Dayaniklilik / 2) + (Oyuncu.Hiz/2) + (Oyuncu.Karizma /2) + (Oyuncu.Zeka/3) + (Oyuncu.Guc/3))/10;
            double Zorluk = (Temel.TemelZorlukCarpani - 1) + OyuncuGucu;
            Zorluk = OyunZorlukDegeri;
        }
    }
}
