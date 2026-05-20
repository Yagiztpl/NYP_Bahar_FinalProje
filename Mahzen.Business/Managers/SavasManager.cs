using Mahzen.Business.Abstract;
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
    public class SavasManager: ISavasService
    {
        public string TurIsle(Oyuncu oyuncu, Dusman dusman, List<string> oyuncuKomutlari)
        {
            StringBuilder turRaporu = new StringBuilder();
            bool savunmada = oyuncuKomutlari.Contains("30000");
            bool yanSilahKullan = oyuncuKomutlari.Contains("10001");
            double oyuncuHamHasar = 0;
            if (!savunmada)
            {
                Ekipman kullanilanSilah = yanSilahKullan && oyuncu.YanSilah != null ? oyuncu.YanSilah : oyuncu.AnaSilah;
                double zayiflikCarpani = 1.0;
                if (kullanilanSilah != null && dusman.Zayiflik != null && dusman.Zayiflik.Contains(kullanilanSilah.HasarTipi))
                {
                    zayiflikCarpani = kullanilanSilah.HasarSinifi == HasarSinifi.Element ? 1.5 : 1.3;
                }
                if (kullanilanSilah != null && dusman.Direnc != null && dusman.Direnc.Contains(kullanilanSilah.HasarTipi))
                {
                    zayiflikCarpani = 0.5;
                }
                oyuncuHamHasar = oyuncu.Guc * zayiflikCarpani;
            }

            double dusmanHamHasar = dusman.Guc;

            if (oyuncu.Hiz >= dusman.Hiz)
            {
                turRaporu.AppendLine(OyuncuSaldirisiUygula(oyuncu, dusman, oyuncuHamHasar, savunmada));

                if (dusman.Can > 0) 
                {
                    turRaporu.AppendLine(DusmanSaldirisiUygula(dusman, oyuncu, dusmanHamHasar, savunmada));
                }
            }
            else
            {
                turRaporu.AppendLine(DusmanSaldirisiUygula(dusman, oyuncu, dusmanHamHasar, savunmada));

                if (oyuncu.Can > 0)
                {
                    turRaporu.AppendLine(OyuncuSaldirisiUygula(oyuncu, dusman, oyuncuHamHasar, savunmada));
                }
            }
            return turRaporu.ToString();
        }
        private string OyuncuSaldirisiUygula(Oyuncu oyuncu, Dusman dusman, double hasar, bool savunmada)
        {
            if (savunmada) return ">> Savunma duruşuna geçtin. Gelecek darbeleri bekliyorsun.";
            double netHasar = hasar - (dusman.Dayaniklilik * 0.4);
            if (netHasar < 1) netHasar = 1;
            dusman.Can -= netHasar;
            return $">> Düşmana saldırdın ve {netHasar} hasar verdin! (Düşman Kalan Can: {(dusman.Can)})";
        }
        private string DusmanSaldirisiUygula(Dusman dusman, Oyuncu oyuncu, double hasar, bool oyuncuSavunmada)
        {
            double aktifDayaniklilik = oyuncuSavunmada ? oyuncu.Dayaniklilik * 2 : oyuncu.Dayaniklilik;
            double netHasar = hasar - (aktifDayaniklilik * 0.4);
            if (netHasar < 1) netHasar = 1;
            oyuncu.Can -= netHasar;
            string ekstraMesaj = oyuncuSavunmada ? " (Kalkanın/Zırhın darbeyi hafifletti!)" : "";
            return $">> {dusman.Isim ?? "Düşman"} sana vurdu ve {netHasar:F1} hasar aldın!{ekstraMesaj} (Kalan Canın: {(oyuncu.Can):F1})";
        }
    }
}
