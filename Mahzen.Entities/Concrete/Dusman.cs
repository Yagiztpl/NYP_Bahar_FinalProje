using Mahzen.Entities.Abstract;
using Mahzen.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Entities.Concrete
{
    public class Dusman() : Varlik()
    {
        public DusmanSinifi Sinif { get; set; }
        public DusmanYonelimi Yonelim { get; set; }
        public string Isim { get; set; }
        public List<Ekipman> Ekipman_Lootable = new List<Ekipman>();
        public List<Tuketilebilir> Tuketilebilir_Lootable = new List<Tuketilebilir>();
        public List<Esya> Esya_Lootable = new List<Esya>();
        public bool Boss { get; set; }
        public List<Esya> Loot = new List<Esya>();
        public List<DusmanParcalari> DayanikliBolgeler = new List<DusmanParcalari>();
        public List<DusmanParcalari> ZayifBolgeler = new List<DusmanParcalari>();
    }
}
