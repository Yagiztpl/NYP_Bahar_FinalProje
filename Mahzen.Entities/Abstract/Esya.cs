using Mahzen.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mahzen.Entities.Abstract
{
    [JsonDerivedType(typeof(Materyal), typeDiscriminator: "materyal")]
    [JsonDerivedType(typeof(Ekipman), typeDiscriminator: "ekipman")]
    [JsonDerivedType(typeof(Tuketilebilir), typeDiscriminator: "tuketilebilir")]
    public class Esya
    {
        public string Isim;
        public string ID { get; set; }
        public int Seviye { get; set; } 
        public int Kilit { get; set; }
        public List<Esya> UretimTarifi = new List<Esya>();
        public Esya(string ID)
        {
            this.ID = ID;
        }
    }

    public class Materyal : Esya
    {
        public Materyal(string ID) : base(ID)
        {

        }
    }

    public class Ekipman : Esya
    {
        public double Can { get; set; }
        public double Guc { get; set; }
        
        public double Dayaniklilik { get; set; }
        public double Hiz { get; set; }
        public double Zeka { get; set; }
        public double Karizma { get; set; }
        public double Mana { get; set; }
        public EkipmanTipi Tip { get; set; }
        public HasarTipi HasarTipi { get; set; }
        public HasarSinifi HasarSinifi { get; set; }
        public EsyaNadirligi Nadirlik { get; set; }
        public List<HasarTipi> Lanetler = new List<HasarTipi>();
        public List<HasarTipi> Runler = new List<HasarTipi>();
        public Ekipman(string ID) : base(ID)
        {

        }
    }

    public class Tuketilebilir : Esya
    {
        public string OdakStat { get; set; }
        public int EkledigiDeger { get; set; }
        public int? Sure { get; set; }
        public Tuketilebilir(string ID) : base(ID)
        {

        }
    }
}
