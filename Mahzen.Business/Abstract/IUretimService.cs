using Mahzen.Entities.Abstract;
using Mahzen.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Business.Abstract
{
    public interface IUretimService
    {
        Ekipman EkipmanUret(Oyuncu oyuncu, Ekipman uretilecekEkipman);
    }
}
