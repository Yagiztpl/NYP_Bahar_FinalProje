using Mahzen.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Business.Abstract
{
    public interface IOyuncuService
    {
        void ZorlukHesabi(Oyuncu Oyuncu);
        void IlerlemeHesapla(Oyuncu Oyuncu);
    }
}
