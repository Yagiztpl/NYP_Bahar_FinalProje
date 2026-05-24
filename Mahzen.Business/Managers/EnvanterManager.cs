using ColortextFunction;
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
    public class EnvanterManager : IEnvanterService, IUretimService
    {
        public void EkipmanKusanOyuncu(Oyuncu Oyuncu, Ekipman Ekipman)
        {
            if (Ekipman.Tip == EkipmanTipi.Zırh)
            {
                if (Oyuncu.Zirh != null)
                {
                    EkipmanCikart(Oyuncu, Oyuncu.Zirh);
                    Console.WriteLine($"[-] {Oyuncu.Zirh.Isim} çıkartıldı.");
                }
                Oyuncu.Zirh = Ekipman;
            }
            else if (Ekipman.Tip == EkipmanTipi.Silah)
            {
                if (Oyuncu.AnaSilah == null)
                {
                    Oyuncu.AnaSilah = Ekipman;
                }
                else if (Oyuncu.YanSilah == null)
                {
                    Oyuncu.YanSilah = Ekipman;
                }
                else
                {
                    EkipmanCikart(Oyuncu, Oyuncu.AnaSilah);
                    Console.WriteLine($"[-] {Oyuncu.AnaSilah.Isim} çıkartıldı.");
                    Oyuncu.AnaSilah = Ekipman;
                }
            }
            switch (Ekipman.Nadirlik)
            {
                case Entities.Enums.EsyaNadirligi.Eser:
                    Oyuncu.Can += Oyuncu.TabanCan / 5 + Ekipman.Can;
                    Oyuncu.Guc += Oyuncu.TabanGuc / 5 + Ekipman.Guc;
                    Oyuncu.Dayaniklilik += Oyuncu.TabanDayaniklilik / 5 + Ekipman.Dayaniklilik;
                    Oyuncu.Hiz += Oyuncu.TabanHiz / 5 + Ekipman.Hiz;
                    Oyuncu.Zeka += Oyuncu.TabanZeka / 5 + Ekipman.Zeka;
                    if (Oyuncu.TabanMana != -1)
                        Oyuncu.Mana += Oyuncu.TabanMana / 5 + Ekipman.Mana;
                    if (Oyuncu.TabanKarizma != -1)
                        Oyuncu.Karizma += Oyuncu.TabanKarizma / 5 + Ekipman.Karizma;
                    break;
                default:
                    Oyuncu.Can += Ekipman.Can;
                    Oyuncu.Guc += Ekipman.Guc;
                    Oyuncu.Dayaniklilik += Ekipman.Dayaniklilik;
                    Oyuncu.Hiz += Ekipman.Hiz;
                    Oyuncu.Zeka += Ekipman.Zeka;
                    if (Oyuncu.TabanMana != -1)
                        Oyuncu.Mana += Ekipman.Mana;
                    if (Oyuncu.TabanKarizma != -1)
                        Oyuncu.Karizma += Ekipman.Karizma;
                    break;
            }
            if (Ekipman.Runler != null && Ekipman.Runler.Count > 0)
            {
                Oyuncu.Direnc.AddRange(Ekipman.Runler);
            }

            if (Ekipman.Lanetler != null && Ekipman.Lanetler.Count > 0)
            {
                Oyuncu.Zayiflik.AddRange(Ekipman.Lanetler);
            }
            Console.WriteLine($"[+] {Ekipman.Isim} başarıyla kuşandın!");
        }
        public void EkipmanKusan(Varlik Varlik, Ekipman Ekipman)
        {
            switch (Ekipman.Nadirlik)
            {
                case Entities.Enums.EsyaNadirligi.Eser:
                    Varlik.Can += Varlik.TabanCan / 5 + Ekipman.Can;
                    Varlik.Guc += Varlik.TabanGuc / 5 + Ekipman.Guc;
                    Varlik.Dayaniklilik += Varlik.TabanDayaniklilik / 5 + Ekipman.Dayaniklilik;
                    Varlik.Hiz += Varlik.TabanHiz / 5 + Ekipman.Hiz;
                    Varlik.Zeka += Varlik.TabanZeka / 5 + Ekipman.Zeka;
                    if (Varlik.TabanMana != -1)
                        Varlik.Mana += Varlik.TabanMana / 5 + Ekipman.Mana;
                    if (Varlik.TabanKarizma != -1)
                        Varlik.Karizma += Varlik.TabanKarizma / 5 + Ekipman.Karizma;
                    break;
                default:
                    Varlik.Can += Ekipman.Can;
                    Varlik.Guc += Ekipman.Guc;
                    Varlik.Dayaniklilik += Ekipman.Dayaniklilik;
                    Varlik.Hiz += Ekipman.Hiz;
                    Varlik.Zeka += Ekipman.Zeka;
                    if (Varlik.TabanMana != -1)
                        Varlik.Mana += Ekipman.Mana;
                    if (Varlik.TabanKarizma != -1)
                        Varlik.Karizma += Ekipman.Karizma;
                    break;
            }
            if (Ekipman.Runler != null && Ekipman.Runler.Count > 0)
            {
                Varlik.Direnc.AddRange(Ekipman.Runler);
            }

            if (Ekipman.Lanetler != null && Ekipman.Lanetler.Count > 0)
            {
                Varlik.Zayiflik.AddRange(Ekipman.Lanetler);
            }
        }
        public void EkipmanCikart(Varlik Varlik, Ekipman Ekipman)
        {
            switch (Ekipman.Nadirlik)
            {
                case Entities.Enums.EsyaNadirligi.Eser:
                    Varlik.Can -= (Varlik.TabanCan / 5 + Ekipman.Can);
                    Varlik.Guc -= (Varlik.TabanGuc / 5 + Ekipman.Guc);
                    Varlik.Dayaniklilik -= (Varlik.TabanDayaniklilik / 5 + Ekipman.Dayaniklilik);
                    Varlik.Hiz -= (Varlik.TabanHiz / 5 + Ekipman.Hiz);
                    Varlik.Zeka -= (Varlik.TabanZeka / 5 + Ekipman.Zeka);

                    if (Varlik.TabanMana != -1)
                        Varlik.Mana -= (Varlik.TabanMana / 5 + Ekipman.Mana);
                    if (Varlik.TabanKarizma != -1)
                        Varlik.Karizma -= (Varlik.TabanKarizma / 5 + Ekipman.Karizma);
                    break;

                default:
                    Varlik.Can -= Ekipman.Can;
                    Varlik.Guc -= Ekipman.Guc;
                    Varlik.Dayaniklilik -= Ekipman.Dayaniklilik;
                    Varlik.Hiz -= Ekipman.Hiz;
                    Varlik.Zeka -= Ekipman.Zeka;

                    if (Varlik.TabanMana != -1)
                        Varlik.Mana -= Ekipman.Mana;
                    if (Varlik.TabanKarizma != -1)
                        Varlik.Karizma -= Ekipman.Karizma;
                    break;
            }

            if (Ekipman.Runler != null && Ekipman.Runler.Count > 0)
            {
                foreach (var run in Ekipman.Runler)
                {
                    Varlik.Direnc.Remove(run);
                }
            }
            if (Ekipman.Lanetler != null && Ekipman.Lanetler.Count > 0)
            {
                foreach (var lanet in Ekipman.Lanetler)
                {
                    Varlik.Zayiflik.Remove(lanet);
                }
            }
        }
        public Ekipman EkipmanUret(Oyuncu oyuncu, Ekipman uretilecekEkipman)
        {
            OyunManager oyunManager = new OyunManager();
            if (uretilecekEkipman.UretimTarifi == null || uretilecekEkipman.UretimTarifi.Count == 0)
            {
                throw new InvalidOperationException("Bu eşyanın bir üretim tarifi bulunmuyor.");
            }

            var tarifGereksinimleri = uretilecekEkipman.UretimTarifi
                .GroupBy(e => e.ID)
                .ToDictionary(g => g.Key, g => g.Count());

            var oyuncuEnvanteri = oyuncu.Envanter
                .GroupBy(e => e.ID)
                .ToDictionary(g => g.Key, g => g.Count());

            foreach (var gereksinim in tarifGereksinimleri)
            {
                if (!oyuncuEnvanteri.ContainsKey(gereksinim.Key) || oyuncuEnvanteri[gereksinim.Key] < gereksinim.Value)
                {
                    throw new InvalidOperationException($"{gereksinim.Key} materyalinden yeterli miktarda bulunmuyor. Gereken: {gereksinim.Value}");
                }
            }

            foreach (var gereksinim in tarifGereksinimleri)
            {
                for (int i = 0; i < gereksinim.Value; i++)
                {
                    var silinecekEysa = oyuncu.Envanter.First(e => e.ID == gereksinim.Key);
                    oyuncu.Envanter.Remove(silinecekEysa);
                }
            }
            oyuncu.Envanter.Add(oyunManager.EkipmanOlustur(uretilecekEkipman));

            return uretilecekEkipman;
        }
        public void EsyalariTopla(Dusman Dusman, Oyuncu Oyuncu)
        {
            if (Dusman.Can <= 0)
            {
                if (Dusman.Ekipman_Lootable != null && Dusman.Ekipman_Lootable.Count > 0)
                {
                    Oyuncu.Envanter.AddRange(Dusman.Ekipman_Lootable);
                    Dusman.Ekipman_Lootable.Clear();
                }
                if (Dusman.Esya_Lootable != null && Dusman.Esya_Lootable.Count > 0)
                {
                    Oyuncu.Envanter.AddRange(Dusman.Esya_Lootable);
                    Dusman.Esya_Lootable.Clear();
                }

                if (Dusman.Tuketilebilir_Lootable != null && Dusman.Tuketilebilir_Lootable.Count > 0)
                {
                    Oyuncu.Envanter.AddRange(Dusman.Tuketilebilir_Lootable);
                    Dusman.Tuketilebilir_Lootable.Clear();
                }
                if (Dusman.Loot != null && Dusman.Loot.Count > 0)
                {
                    Oyuncu.Envanter.AddRange(Dusman.Loot);
                    Dusman.Loot.Clear();
                }
            }
        }
        public void Listele(Oyuncu Oyuncu)
        {
            ColorText.CWriteLine("Y","Takılı Eşyalar:");
            if (Oyuncu.AnaSilah!=null)
            ColorText.CWriteLine("G", $"Birincil Silah -> {Oyuncu.AnaSilah.Isim}");
            if (Oyuncu.YanSilah != null)
                ColorText.CWriteLine("G", $"Yan Silah -> {Oyuncu.YanSilah.Isim}");
            if (Oyuncu.Zirh != null)
                ColorText.CWriteLine("G", $"Zırh Silah -> {Oyuncu.Zirh.Isim}");
            ColorText.CWriteLine("Y","Envanter: ");
            foreach (var item in Oyuncu.Envanter)
            {
                Console.WriteLine($"-> {item.Isim}");
            }
        }
        public void Debug_EsyaEkle(Oyuncu oyuncu, string arananGirdi)
        {
            arananGirdi = arananGirdi.ToLower().Trim();
            var materyal = Mahzen.Common.Config.Temel.EsyaKatalogu.Values.FirstOrDefault(e =>
                e.ID == arananGirdi || (e.Isim != null && e.Isim.ToLower() == arananGirdi));

            var ekipman = Mahzen.Common.Config.Temel.EkipmanKatalogu.Values.FirstOrDefault(e =>
                e.ID == arananGirdi || (e.Isim != null && e.Isim.ToLower() == arananGirdi));

            var tuket = Mahzen.Common.Config.Temel.TuketilebilirKatalogu.Values.FirstOrDefault(e =>
                e.ID == arananGirdi || (e.Isim != null && e.Isim.ToLower() == arananGirdi));

            if (materyal != null)
            {
                oyuncu.Envanter.Add(new Materyal(materyal.ID) { Isim = materyal.Isim, Kilit = materyal.Kilit });
                Console.WriteLine($"[DEBUG] {materyal.Isim} (ID: {materyal.ID}) envantere eklendi.");
            }
            else if (ekipman != null)
            {
                var yeniEkipman = new OyunManager().EkipmanOlustur(ekipman);
                oyuncu.Envanter.Add(yeniEkipman);
                Console.WriteLine($"[DEBUG] {yeniEkipman.Isim} (ID: {yeniEkipman.ID}) envantere eklendi.");
            }
            else if (tuket != null)
            {
                oyuncu.Envanter.Add(new Tuketilebilir(tuket.ID) { Isim = tuket.Isim, Sure = tuket.Sure, OdakStat = tuket.OdakStat, EkledigiDeger = tuket.EkledigiDeger });
                Console.WriteLine($"[DEBUG] {tuket.Isim} (ID: {tuket.ID}) envantere eklendi.");
            }
            else
            {
                Console.WriteLine($"[DEBUG] '{arananGirdi}' isminde veya ID kimliğinde bir eşya bulunamadı!");
            }
        }
        public void TuketilebilirKullan(Oyuncu oyuncu, Tuketilebilir tuketilebilir)
        {
            if (tuketilebilir.OdakStat == "Can")
            {
                double eskiCan = oyuncu.Can;
                oyuncu.Can += tuketilebilir.EkledigiDeger;
                double iyilesme = oyuncu.Can - eskiCan;
                ColorText.CWriteLine("G", $"[+] {tuketilebilir.Isim} tükettin! Canın {iyilesme:F1} kadar yenilendi. (Mevcut Can: {oyuncu.Can:F1}/{oyuncu.TabanCan:F1})");
            }
            else
            {
                switch (tuketilebilir.OdakStat)
                {
                    case "Hiz": oyuncu.Hiz += tuketilebilir.EkledigiDeger; break;
                    case "Guc": oyuncu.Guc += tuketilebilir.EkledigiDeger; break;
                    case "Dayaniklilik": oyuncu.Dayaniklilik += tuketilebilir.EkledigiDeger; break;
                    case "Zeka": oyuncu.Zeka += tuketilebilir.EkledigiDeger; break;
                }
                ColorText.CWriteLine("G", $"[+] Mistik bir güç hissettin! {tuketilebilir.Isim} tükettin ve {tuketilebilir.OdakStat} değerin {tuketilebilir.EkledigiDeger} arttı.");
            }
            oyuncu.Envanter.Remove(tuketilebilir);
        }
    }
}
