using Mahzen.DataAccess.Abstract;
using Mahzen.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Business.Managers
{
    public class KayitManager
    {
        private IKayitDal _kayitDal;

        public KayitManager(IKayitDal kayitDal)
        {
            _kayitDal = kayitDal;
        }

        public bool OyunuKaydet(Oyuncu oyuncu)
        {
            return _kayitDal.Kaydet(oyuncu);
        }

        public Oyuncu OyunuYukle()
        {
            return _kayitDal.Yukle();
        }

        public bool KayitBulunduMu()
        {
            return _kayitDal.KayitVarMi();
        }
    }
}
