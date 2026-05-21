using Mahzen.Business.Abstract;
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
    public class OyunManager: IOyunService
    {
        public Ekipman EkipmanOlustur(Ekipman Sablon)
        {
            Ekipman Ekipman = new Ekipman(Sablon.ID)
            {
                Isim = Sablon.Isim,
                Kilit = Sablon.Kilit,
                Dayaniklilik = Sablon.Dayaniklilik,
                Can = Sablon.Can,
                Guc = Sablon.Guc,
                Hiz = Sablon.Hiz,
                Zeka = Sablon.Zeka,
                Mana = Sablon.Mana,
                Karizma = Sablon.Karizma,
                HasarSinifi = Sablon.HasarSinifi
            };
            int kilitCarpani = Ekipman.Kilit == 0 ? 1 : Ekipman.Kilit;
            int EkStat = kilitCarpani * 10 * (int)OyuncuManager.OyunZorlukDegeri;
            Random _Random = new Random();
            int EnumSayisi;
            EnumSayisi = Enum.GetNames(typeof(HasarTipi)).Length;
            int[] Nadirlikler = {10,20,40,30,20,10,5 };
            switch (Yuzde.YuzdeRandom(Nadirlikler))
            {
                case 0: Ekipman.Nadirlik = EsyaNadirligi.Kirik; EkStat -= EkStat / 2; break;
                case 1: Ekipman.Nadirlik = EsyaNadirligi.Kalitesiz; EkStat -=  EkStat / 5; break;
                case 2: Ekipman.Nadirlik = EsyaNadirligi.Basit; break;
                case 3: Ekipman.Nadirlik = EsyaNadirligi.Nadir; EkStat += EkStat / 4; break;
                case 4: Ekipman.Nadirlik = EsyaNadirligi.Epik; EkStat += EkStat / 2; break;
                case 5: Ekipman.Nadirlik = EsyaNadirligi.Efsanevi; EkStat += EkStat; break;
                case 6: Ekipman.Nadirlik = EsyaNadirligi.Eser; EkStat += EkStat; break;
            }
            Ekipman.HasarTipi = (HasarTipi)_Random.Next(0, EnumSayisi);
            for (int i = 0; i < EkStat; i++)
            {
                int rastgeleStatIndex = _Random.Next(0, 7);

                switch (rastgeleStatIndex)
                {
                    case 0: Ekipman.Can += 1; break;
                    case 1: Ekipman.Guc += 1; break;
                    case 2: Ekipman.Dayaniklilik += 1; break;
                    case 3: Ekipman.Hiz += 1; break;
                    case 4: Ekipman.Zeka += 1; break;
                    case 5: Ekipman.Karizma += 1; break;
                    case 6: Ekipman.Mana += 1; break;
                }
            }
            int[] eklentiIhtimalleri = { 60, 25, 10, 5 };
            int eklenecekRunSayisi = Yuzde.YuzdeRandom(eklentiIhtimalleri);
            for (int i = 0; i < eklenecekRunSayisi; i++)
            {
                Ekipman.Runler.Add((HasarTipi)_Random.Next(0, EnumSayisi));
            }
            int eklenecekLanetSayisi = Yuzde.YuzdeRandom(eklentiIhtimalleri);
            for (int i = 0; i < eklenecekLanetSayisi; i++)
            {
                Ekipman.Lanetler.Add((HasarTipi)_Random.Next(0, EnumSayisi));
            }
            return Ekipman;
        }
    }
}
