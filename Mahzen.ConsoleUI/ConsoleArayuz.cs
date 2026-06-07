using ColortextFunction;
using Mahzen.Business.Managers;
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
    public class ConsoleArayuz
    {
        private OdaManager _odaManager = new OdaManager();
        private SavasManager _savasManager = new SavasManager();
        private GirdiOkuyucu _girdiOkuyucu = new GirdiOkuyucu();
        private EnvanterManager _envanterManager = new EnvanterManager();
        private OyunManager _oyunManager = new OyunManager();
        private KayitManager _kayitManager = new KayitManager(new JsonKayitDal());

        public void OyunuBaslat()
        {
            ColorText.CWriteLine("Y", "=================================================");
            ColorText.CWriteLine("Y", "             MAHZEN'E HOŞ GELDİNİZ               ");
            ColorText.CWriteLine("Y", "=================================================");

            Oyuncu aktifOyuncu = null;
            if (_kayitManager.KayitBulunduMu())
            {
                ColorText.CWriteLine("G", "Mahzen'in derinliklerinde eski bir iz bulundu...");
                ColorText.CWriteLine("C", "[1] Yeni Oyun Başlat");
                ColorText.CWriteLine("C", "[2] Kaldığım Yerden Devam Et");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                if (secim == "2")
                {
                    aktifOyuncu = _kayitManager.OyunuYukle();
                    if (aktifOyuncu != null)
                    {
                        ColorText.CWriteLine("G", "Kayıt başarıyla yüklendi! Maceraya dönüyorsun...");
                    }
                    else
                    {
                        ColorText.CWriteLine("R", "Kayıt dosyası bozuk! Yeni oyun başlatılıyor...");
                    }
                }
            }
            if (aktifOyuncu == null)
            {
                aktifOyuncu = new Oyuncu(100, 12, 8, 10, 10)
                {
                    EsyaKilidi = 0,
                    Ilerleme = 0
                };
                ColorText.CWriteLine("Y", "Yeni bir maceracı mahzene adım atıyor...");
            }
            Harita mevcutHarita = _odaManager.HaritaUret(aktifOyuncu);

            while (aktifOyuncu.Can > 0)
            {
                Console.Clear();
                ColorText.CWriteLine("C", $"\n--- DURUM: [Can: {aktifOyuncu.Can:F0}/{aktifOyuncu.Maxcan:F0}] | [İlerleme: {aktifOyuncu.Ilerleme}/{mevcutHarita.OdaSayisi}] ---");

                if (aktifOyuncu.Ilerleme >= mevcutHarita.OdaSayisi)
                {
                    ColorText.CWriteLine("G", "\nTEBRİKLER! Mahzenin karanlığından sağ çıkmayı başardın!");
                    ColorText.CWriteLine("Y", "Yeni bir rotaya sapıyorsun.");
                    mevcutHarita = _odaManager.HaritaUret(aktifOyuncu);
                }

                List<Oda> secenekler = _odaManager.OdalariKar(mevcutHarita);
                if (secenekler == null || secenekler.Count == 0) break;

                Oda secilenOda = null;

                while (secilenOda == null)
                {
                    Console.Write("\nHamleniz (örn: oda1, envanter, kaydet): ");
                    string girdi = Console.ReadLine();
                    List<string> komutlar = _girdiOkuyucu.KomutIsle(girdi, aktifOyuncu, secenekler, true);
                    secilenOda = secenekler.FirstOrDefault(o => o.ZiyaretEdildi);
                    bool hamleGecerliMi = komutlar.Any(k => k != null && k.StartsWith("50"));

                    if (secilenOda == null && !hamleGecerliMi)
                    {
                        ColorText.CWriteLine("R", "Lütfen geçerli bir hamle yapın (oda1, envanter, kuşan çelik kılıç, kaydet).");
                    }
                    if (komutlar.Contains("50012"))
                    {
                        ColorText.CWriteLine("C", $"\n=== OYUNCU BİLGİLERİ ===");
                        ColorText.CWriteLine("Y", $"Can: {aktifOyuncu.Can:F0} / {aktifOyuncu.TabanCan:F0}");
                        ColorText.CWriteLine("Y", $"Güç: {aktifOyuncu.Guc:F0} | Dayanıklılık: {aktifOyuncu.Dayaniklilik:F0} | Hız: {aktifOyuncu.Hiz:F0} | Zeka: {aktifOyuncu.Zeka:F0}");
                        ColorText.CWriteLine("P", $"Dirençler: {(aktifOyuncu.Direnc.Any() ? string.Join(", ", aktifOyuncu.Direnc) : "Yok")}");
                        ColorText.CWriteLine("O", $"Zayıflıklar: {(aktifOyuncu.Zayiflik.Any() ? string.Join(", ", aktifOyuncu.Zayiflik) : "Yok")}");

                        ColorText.CWriteLine("C", "===============================\n");
                        continue;
                    }
                }

                if (secilenOda != null)
                {
                    OdaAksiyonunuTetikle(aktifOyuncu, secilenOda);
                }
            }

            if (aktifOyuncu.Can <= 0)
            {
                ColorText.CWriteLine("R", "\n=================================================");
                ColorText.CWriteLine("R", "      ÖLDÜN. Karanlık mahzen sana mezar oldu.    ");
                ColorText.CWriteLine("R", "=================================================");
            }
        }

        private void OdaAksiyonunuTetikle(Oyuncu oyuncu, Oda oda)
        {
            switch (oda.OdaTipi)
            {
                case OdaTipi.Dinlenme:
                    ColorText.CWriteLine("G", "\n>> Güvenli bir kamp ateşinin başına oturdun. Canın tamamen yenilendi!");
                    oyuncu.Can = oyuncu.Maxcan;
                    break;
                case OdaTipi.Savas:
                case OdaTipi.Arena:
                    ColorText.CWriteLine("R", $"\n>> TEHLİKE! Odaya adım atar atmaz {oda.Dusmanlar.Count} düşmanla karşılaştın!");
                    SavasDongusu(oyuncu, oda);
                    break;
                default:
                    Console.WriteLine("\n>> Boş ve karanlık bir koridordan geçtin.");
                    break;
            }
        }

        private void SavasDongusu(Oyuncu oyuncu, Oda oda)
        {
            int dusmanSayaci = 1;

            foreach (Dusman dusman in oda.Dusmanlar)
            {
                if (oyuncu.Can <= 0) break;

                ColorText.CWriteLine("Y", $"\n--- SAVAŞ BAŞLADI: {dusman.Isim} (Düşman {dusmanSayaci}/{oda.Dusmanlar.Count}) ---");
                while (oyuncu.Can > 0 && dusman.Can > 0)
                {
                    Console.WriteLine($"\n[Senin Canın: {oyuncu.Can:F0}/{oyuncu.Maxcan:F0}] vs [{dusman.Isim} Canı: {dusman.Can:F1}]");
                    Console.Write("Aksiyon (Saldır / Savun / Envanter): ");
                    string girdi = Console.ReadLine();
                    List<string> komutlar = _girdiOkuyucu.KomutIsle(girdi, oyuncu, new List<Oda>(), false);
                    if (komutlar.Contains("50009"))
                    {
                        ColorText.CWriteLine("C", $"\n=== {dusman.Isim} BİLGİLERİ ===");
                        ColorText.CWriteLine("Y", $"Can: {dusman.Can:F0} / {dusman.TabanCan:F0}");
                        ColorText.CWriteLine("Y", $"Sınıf: {dusman.Sinif} | Yönelim: {dusman.Yonelim}");
                        ColorText.CWriteLine("Y", $"Güç: {dusman.Guc:F0} | Dayanıklılık: {dusman.Dayaniklilik:F0} | Hız: {dusman.Hiz:F0} | Zeka: {dusman.Zeka:F0}");
                        ColorText.CWriteLine("P", $"Dirençler: {(dusman.Direnc.Any() ? string.Join(", ", dusman.Direnc) : "Yok")}");
                        ColorText.CWriteLine("O", $"Zayıflıklar: {(dusman.Zayiflik.Any() ? string.Join(", ", dusman.Zayiflik) : "Yok")}");
                        ColorText.CWriteLine("C", "===============================\n");
                        continue;
                    }
                    if (komutlar.Contains("50000"))
                    {
                        continue;
                    }
                    if (!komutlar.Contains("10000") && !komutlar.Contains("10001") && !komutlar.Contains("30000"))
                    {
                        ColorText.CWriteLine("W", "Savaşın ortasındasın! Aksiyonunu tam anlayamadım, düşman hamle fırsatı buldu!");
                    }
                    string turRaporu = _savasManager.TurIsle(oyuncu, dusman, komutlar);
                    Console.WriteLine(turRaporu);
                }
                if (dusman.Can <= 0)
                {
                    ColorText.CWriteLine("G", $"\n>> {dusman.Isim} yere yığıldı!");

                    _envanterManager.EsyalariTopla(dusman, oyuncu);

                    if (dusman.Esya_Lootable.Any() || dusman.Ekipman_Lootable.Any() || dusman.Tuketilebilir_Lootable.Any() || dusman.Loot.Any())
                    {
                        ColorText.CWriteLine("C", ">> Düşmanın üzerindeki ganimetleri envanterine kattın.");
                    }
                }
                dusmanSayaci++;
            }
            if (oyuncu.Can > 0)
            {
                ColorText.CWriteLine("G", "\n>> ODA TEMİZLENDİ! Kanını silip ilerlemeye hazırsın.");
            }
        }
    }
}