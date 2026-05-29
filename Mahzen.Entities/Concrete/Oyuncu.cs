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
        public int Ilerleme { get; set; }
        public int EsyaKilidi { get; set; }
        public int Maxcan { get; set; }
        public Oyuncu(int tabanCan, int tabanGuc, int tabanDayaniklilik, int tabanHiz, int tabanZeka)
        {
            TabanCan = tabanCan;
            TabanGuc = tabanGuc;
            TabanDayaniklilik = tabanDayaniklilik;
            TabanHiz = tabanHiz;
            TabanZeka = tabanZeka;
            Maxcan = tabanCan;
            Can = tabanCan;
            Guc = tabanGuc;
            Dayaniklilik = tabanDayaniklilik;
            Hiz = tabanHiz;
            Zeka = tabanZeka;
        }
    }
}
