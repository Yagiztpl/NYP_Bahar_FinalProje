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
        public HasarSinifi Sinif { get; set; }
        public HasarTipi Tip { get; set; }
        public ZayiflatmaTipi? Zayiflatma { get; set; }
        private HasarSureci? _surec;
        public StatOdagi? StatOdagi { get; set; }
        public HamleOdagi? HamleOdagi { get; set; }
        public HasarSureci? Surec
        {
            get { return _surec; }
            set
            {
                _surec = value;
                if (_surec == HasarSureci.Anlik || _surec == HasarSureci.AnlikYuzde)
                {
                    Zayiflatma = null;
                    StatOdagi = null;
                    HamleOdagi = null;
                }
            }
        }
        public Hasar()
        {
        }
    }
}
