using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Entities.Abstract
{
    public class Esya
    {
        private string ID { get; set; }
        public int Nadirlik { get; set; }
        public int Seviye { get; set; }
        public int Kilit { get; set; }
        public Esya(string ID)
        {
            ID = this.ID;
        }
    }

    public class Materyal : Esya
    {
        public Materyal(string ID) : base(ID)
        {

        }
    }

    public class Ekipman : Esya
    {
        public Ekipman(string ID) : base(ID)
        {

        }
    }

    public class Tuketilebilir : Esya
    {
        public Tuketilebilir(string ID) : base(ID)
        {

        }
    }
}
