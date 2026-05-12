using Mahzen.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Entities.Abstract
{
    internal class Oda
    {
        public OdaTipi OdaTipi { get; set; }
        private int _yaratikSayisi { get; set; }
        public int YaratikSayisi 
        { get { return _yaratikSayisi; } set { if (OdaTipi == OdaTipi.Demirci || OdaTipi == OdaTipi.Dinlenme) _yaratikSayisi = 0; else _yaratikSayisi = value; } }
    }
}
