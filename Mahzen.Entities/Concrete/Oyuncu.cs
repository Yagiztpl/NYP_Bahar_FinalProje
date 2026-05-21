using Mahzen.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Entities.Concrete
{
    public class Oyuncu : Varlik
    {
        public List<Esya> Envanter = new List<Esya>();
        public Ekipman Zirh { get; set; }
        public Ekipman AnaSilah { get; set; }
        public Ekipman YanSilah { get; set; }
        public int Ilerleme;
        public int EsyaKilidi;
    }
}
