using ColortextFunction;
using Mahzen.Business.Managers;
using Mahzen.Common.Config;
using Mahzen.DataAccess.Concrete;
using Mahzen.Entities.Abstract;
using Mahzen.Entities.Concrete;
using Mahzen.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.ConsoleUI
{
    public class GirdiOkuyucu
    {
        private EnvanterManager EnvanterManager = new EnvanterManager();
        public List<string> KomutIsle(string komut, Oyuncu aktifOyuncu, List<Oda> aktifOdalar, bool odaSecimi)
        {
            komut = komut.ToLower().Trim();
            List<string> cikti = new List<string>(); 
            if (komut.Contains("uret"))
            {
                if (komut.Contains("kilic"))
                {
                    cikti.Add("00001");  UretimiTetikle(aktifOyuncu, EsyaIsimleri.CelikKilic); 
                } 
                else if (komut.Contains("zirh"))
                {
                    cikti.Add("00002"); UretimiTetikle(aktifOyuncu, EsyaIsimleri.HasarliZirh); 
                }
                else if (komut.Contains("asa"))
                {
                    cikti.Add("00003"); UretimiTetikle(aktifOyuncu, EsyaIsimleri.TungstenAsa); 
                }
                else
                {
                    Console.WriteLine("hata"); cikti.Add("00000");
                }
            }
            if (komut.Contains("saldir"))
            {
                if (komut.Contains("ana"))
                {
                    cikti.Add("10000");
                }
                if (komut.Contains("yan"))
                {
                    cikti.Add("10001");
                }
                if (!cikti.Contains("10001") && !cikti.Contains("10000"))
                    cikti.Add("10000");
            }
            if (komut.Contains("savun"))
            {
                cikti.Add("30000");
            }
            if (komut.Contains("yiyecegim") || komut.Contains("icecegim") || komut.Contains("tuketecegim"))
            {

            }
            if (komut.Contains("envanter"))
            {
                EnvanterManager.Listele(aktifOyuncu);
                cikti.Add("50000");
            }
            if (komut.Contains("oda1"))
            {
                OdaManager _OdaManager = new OdaManager();
                cikti.Add("50001");
                if (odaSecimi)
                    _OdaManager.OdaSec(aktifOyuncu, aktifOdalar[0]);
            }
            if (komut.Contains("oda2"))
            {
                OdaManager _OdaManager = new OdaManager();
                cikti.Add("50002");
                if (odaSecimi)
                    _OdaManager.OdaSec(aktifOyuncu, aktifOdalar[1]);
            }
            if (komut.Contains("oda3"))
            {
                OdaManager _OdaManager = new OdaManager();
                cikti.Add("50003");
                if (odaSecimi)
                    _OdaManager.OdaSec(aktifOyuncu, aktifOdalar[2]);
            }
            if (komut.Contains("debug_"))
            {
                if ((komut.Replace("debug_", "").Trim()) == "kill")
                {
                    cikti.Add("50010");
                }
                else
                {
                    string esyaAdi = komut.Replace("debug_", "").Trim();
                    EnvanterManager.Debug_EsyaEkle(aktifOyuncu, esyaAdi);
                    cikti.Add("50000");
                }
            }
            if (komut.Contains("kusan") || komut.Contains("tak") || komut.Contains("giy"))
            {
                string esyaAdi = komut.Replace("kuşan", "").Replace("kusan", "").Replace("tak", "").Replace("giy", "").Trim();
                var envanterdekiEsya = aktifOyuncu.Envanter.FirstOrDefault(e => e.Isim != null && e.Isim.ToLower() == esyaAdi);
                if (envanterdekiEsya != null)
                {
                    if (envanterdekiEsya is Ekipman kusanilacakEkipman)
                    {
                        EnvanterManager.EkipmanKusanOyuncu(aktifOyuncu, kusanilacakEkipman);
                    }
                    else
                    {
                        ColorText.CWriteLine("R", $"[-] {envanterdekiEsya.Isim} kuşanılabilecek (giyilebilecek) bir eşya değil!");
                    }
                }
                else
                {
                    ColorText.CWriteLine("R", $"[-] Envanterinde '{esyaAdi}' adında bir eşya bulamadım. Adını tam yazdığından emin ol.");
                }
                cikti.Add("50000");
            }
            if (komut.Contains("kaydet"))
            {
                KayitManager _kayitManager = new KayitManager(new JsonKayitDal());
                if (_kayitManager.OyunuKaydet(aktifOyuncu))
                {
                    ColorText.CWriteLine("G", ">> Oyun başarıyla kaydedildi! (Güvendesin)");
                }
                else
                {
                    ColorText.CWriteLine("R", ">> Kayıt sırasında bir hata oluştu!");
                }
                cikti.Add("50005");
            }
            if (komut.Contains("sil"))
            {
                string esyaAdi = komut.Replace("sil", "").Trim();
                var envanterdekiEsya = aktifOyuncu.Envanter.FirstOrDefault(e => e.Isim != null && e.Isim.ToLower() == esyaAdi);
                if (envanterdekiEsya != null)
                {
                    ColorText.CWriteLine("p", $"{envanterdekiEsya.Isim} başarıyla silindi!");
                    EnvanterManager.Sil(aktifOyuncu, envanterdekiEsya);
                }
                else
                {
                    ColorText.CWriteLine("r", $"Silinecek eşya bulunamadı.");
                }

                    cikti.Add("50011");
            }
            if (komut.Contains("incele"))
            {
                if (komut == "incele" || komut == "düşmanı incele" || komut == "dusmani incele")
                {
                    cikti.Add("50009");
                }
                else
                {
                    string esyaAdi = komut.Replace("incele", "").Trim();
                    var envanterdekiEsya = aktifOyuncu.Envanter.FirstOrDefault(e => e.Isim != null && e.Isim.ToLower() == esyaAdi);
                    if (envanterdekiEsya != null)
                    {
                        if (envanterdekiEsya is Ekipman incelenecekEkipman)
                        {
                            EnvanterManager.EkipmanIncele(incelenecekEkipman);
                        }
                        else if (envanterdekiEsya is Tuketilebilir tuketilebilirEsya)
                        {
                            ColorText.CWriteLine("Y", $"\n=== {tuketilebilirEsya.Isim.ToUpper()} ===");
                            ColorText.CWriteLine("G", $"Odak: {tuketilebilirEsya.OdakStat} | Etki: +{tuketilebilirEsya.EkledigiDeger} | Süre: {(tuketilebilirEsya.Sure.HasValue ? tuketilebilirEsya.Sure + " Tur" : "Anlık")}\n");
                        }
                        else
                        {
                            ColorText.CWriteLine("Y", $"\n=== {envanterdekiEsya.Isim.ToUpper()} ===\nBasit bir materyal. Üretimde (Craft) kullanılabilir.\n");
                        }
                    }
                    else
                    {
                        ColorText.CWriteLine("R", $"[-] Envanterinde '{esyaAdi}' adında bir eşya bulamadım.");
                    }
                    cikti.Add("50000");
                }
            }
            if (komut.Contains("iç") || komut.Contains("ic") || komut.Contains("ye") || komut.Contains("tüket") || komut.Contains("tuket") || komut.Contains("kullan"))
            {
                string esyaAdi = komut.Replace("iç", "").Replace("ic", "").Replace("ye", "")
                                      .Replace("tüket", "").Replace("tuket", "").Replace("kullan", "").Trim();
                var envanterdekiEsya = aktifOyuncu.Envanter.FirstOrDefault(e => e.Isim != null && e.Isim.ToLower() == esyaAdi);
                if (envanterdekiEsya != null)
                {
                    if (envanterdekiEsya is Tuketilebilir tuketilecekEsya)
                    {
                        EnvanterManager.TuketilebilirKullan(aktifOyuncu, tuketilecekEsya);
                    }
                    else
                    {
                        ColorText.CWriteLine("R", $"[-] {envanterdekiEsya.Isim} yenilecek veya içilecek bir şey değil!");
                    }
                }
                else
                {
                    ColorText.CWriteLine("R", $"[-] Envanterinde '{esyaAdi}' adında bir eşya bulamadım.");
                }

                cikti.Add("50000");
            }

            return cikti;
        }

        private void UretimiTetikle(Oyuncu oyuncu, EsyaIsimleri esyaIsmi)
        {
                var uretilecekEkipman = Temel.EkipmanKatalogu[esyaIsmi];
                EnvanterManager.EkipmanUret(oyuncu, uretilecekEkipman);
        }
    }
}