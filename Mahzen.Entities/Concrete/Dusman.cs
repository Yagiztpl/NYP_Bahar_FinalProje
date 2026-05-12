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
        public Ekipman Slot0 { get; set; }
        public Ekipman Slot1 { get; set; }
        public Ekipman Slot2 { get; set; }
        public bool Boss { get; set; }
        public List<Esya> Loot = new List<Esya>();
    }
}
