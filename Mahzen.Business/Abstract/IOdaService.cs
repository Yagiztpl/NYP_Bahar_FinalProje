using Mahzen.Entities.Abstract;
using Mahzen.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Business.Abstract
{
    public interface IOdaService
    {
        Harita HaritaUret();
        Oda OdaUret(Harita Harita);
        Dusman DusmanUret(Oda Oda, Harita Harita);
        List<Oda> OdalariKar(Harita Harita);
        void OdaSec(Oyuncu Oyuncu, Oda Oda);
    }
}
