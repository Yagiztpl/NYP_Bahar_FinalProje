using Mahzen.DataAccess.Abstract;
using Mahzen.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mahzen.DataAccess.Concrete
{
    public class JsonKayitDal : IKayitDal
    {
        private string _dosyaYolu;

        public JsonKayitDal()
        {
            string dataKlasor = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(dataKlasor))
            {
                Directory.CreateDirectory(dataKlasor);
            }

            _dosyaYolu = Path.Combine(dataKlasor, "mahzen_kayit.json");
        }

        public bool Kaydet(Oyuncu oyuncu)
        {
            try
            {
                var ayarlar = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };
                string json = JsonSerializer.Serialize(oyuncu, ayarlar);

                File.WriteAllText(_dosyaYolu, json);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Oyuncu Yukle()
        {
            try
            {
                if (!File.Exists(_dosyaYolu)) return null;

                string json = File.ReadAllText(_dosyaYolu);
                if (string.IsNullOrEmpty(json)) return null;
                var ayarlar = new JsonSerializerOptions { IncludeFields = true };

                return JsonSerializer.Deserialize<Oyuncu>(json, ayarlar);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool KayitVarMi()
        {
            return File.Exists(_dosyaYolu);
        }
    }
}
