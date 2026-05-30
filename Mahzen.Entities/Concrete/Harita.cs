using Mahzen.Entities.Abstract;
using Mahzen.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Entities.Concrete
{
    public class Harita
    {
        public int OdaSayisi { get; set; }
        public int Sans { get; set; }
        public int HaritaZorlugu { get; set; }
        public Biyomlar Biyom { get; set; }
        public List<Oda> Odalar { get; set; } = new List<Oda>();

    }
}
