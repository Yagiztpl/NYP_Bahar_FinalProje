using Mahzen.Business.Abstract;
using Mahzen.Entities.Abstract;
using Mahzen.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Business.Managers
{
    internal class EnvanterManager : IEnvanterService
    {
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
                if (Dusman.Loot != null && Dusman.Loot.Count > 0)
                {
                    Oyuncu.Envanter.AddRange(Dusman.Loot);
                    Dusman.Loot.Clear();
                }
            }

        }
    }
}
