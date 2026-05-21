using Mahzen.Business.Managers;
using Mahzen.Common.Config;
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
                    cikti.Add("00002"); UretimiTetikle(aktifOyuncu, EsyaIsimleri.DermeCatmaZirh); 
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
                string esyaAdi = komut.Replace("debug_", "").Trim();
                EnvanterManager.Debug_EsyaEkle(aktifOyuncu, esyaAdi);
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