using Mahzen.Entities.Concrete;
using Mahzen.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Entities.Abstract
{
    public class Oda
    {
        public OdaTipi OdaTipi { get; set; }
        private int _DusmanSayisi { get; set; }
        public int DusmanSayisi 
        { get { return _DusmanSayisi; } set { if (OdaTipi == OdaTipi.Demirci || OdaTipi == OdaTipi.Dinlenme) _DusmanSayisi = 0; else _DusmanSayisi = value; } }
        public List<Dusman> Dusmanlar { get; set; } = new List<Dusman>();
    }
}
