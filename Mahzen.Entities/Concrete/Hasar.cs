using Mahzen.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Entities.Concrete
{
    public class Hasar
    {
        private string Isim { get; set; }
        public double Taban { get; set; }
        public HasarTipi Tip { get; set; }
        public HasarSureci? Surec { get; set; }
        public ZayiflatmaTipi? Zayiflatma { get; set; }
        public Hasar()
        {
            if (Surec == HasarSureci.Anlik || Surec == HasarSureci.AnlikYuzde)
                Zayiflatma = null;
        }
    }
}
