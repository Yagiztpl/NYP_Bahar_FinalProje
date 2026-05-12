using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Entities.Abstract
{
    public class Esya
    {
        private string ID;
        public Esya(string ID)
        {

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
