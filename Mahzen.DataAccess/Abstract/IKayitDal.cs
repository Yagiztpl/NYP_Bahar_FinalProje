using Mahzen.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.DataAccess.Abstract
{


    public interface IKayitDal
    {
        bool Kaydet(Oyuncu oyuncu);
        Oyuncu Yukle();
        bool KayitVarMi();
    }

}
