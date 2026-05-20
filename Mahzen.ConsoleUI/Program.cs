using ColortextFunction;
using Mahzen.Business.Managers;
using Mahzen.Common.Config;
using Mahzen.Entities.Concrete;

namespace Mahzen.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Eklentilerimi yüklüyor
            Mahzen.Common.Config.Eklentiler.Yukle();
            ColorText.CWriteLine("g", "Mahzen'e Hoş Geldin...");

            // 1. GirdiOkuyucu sınıfından bir nesne (instance) oluşturuyoruz
            GirdiOkuyucu okuyucu = new GirdiOkuyucu();

            // 2. Metodun çalışması için parametre olarak vereceğimiz boş bir test oyuncusu oluşturuyoruz
            Oyuncu testOyuncusu = new Oyuncu();

            // Konsoldan test verisini alıyoruz
            string testGirdisi = Console.ReadLine();

            // 3. Metodu doğru parametrelerle (girdi ve oyuncu) çağırıyoruz
            List<string> sonucListesi = okuyucu.KomutIsle(testGirdisi, testOyuncusu);

            // 4. Geri dönen listeyi okumak için döngü kullanıyoruz
            Console.WriteLine("\n--- Test Çıktıları ---");
            foreach (string sonuc in sonucListesi)
            {
                Console.WriteLine("Kod: " + sonuc);
            }
            OdaManager _odaManager = new OdaManager();
            Harita testHarita = _odaManager.HaritaUret(testOyuncusu.EsyaKilidi);
            _odaManager.OdalariKar(testHarita);
        }
    }
}
