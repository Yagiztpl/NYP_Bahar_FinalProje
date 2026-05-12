using Mahzen.Entities.Concrete;
using Mahzen.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Entities.Abstract
{
    public class Varlik
    {
        public double Can { get; set; }
        public double Guc { get; set; }
        public double Dayaniklilik { get; set; }
        public double Hiz { get; set; }
        public double Zeka { get; set; }
        public double Karizma { get; set; }
        public double Mana { get; set; }
        public List<HasarTipi> Direnc { get; set; } = new List<HasarTipi>();
        public List<HasarTipi> Zayiflik { get; set; } = new List<HasarTipi>();
    }
}
