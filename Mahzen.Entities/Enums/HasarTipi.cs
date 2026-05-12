using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Entities.Enums
{
    public enum HasarTipi
    {
        Fiziksel,
        Zihinsel,
        Element
    }
    public enum HasarSureci 
    { 
        Anlik, 
        AnlikYuzde,
        ZamanlaSabit, 
        ZamanlaYuzde 
    }
    public enum ZayiflatmaTipi
    { 
      StatDusurur, 
      HamleEngeller 
    }
}
