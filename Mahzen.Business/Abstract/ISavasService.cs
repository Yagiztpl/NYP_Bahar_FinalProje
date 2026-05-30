using Mahzen.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Business.Abstract
{
    public interface ISavasService
    {
        string TurIsle(Oyuncu oyuncu, Dusman dusman, List<string> oyuncuKomutlari);
    }
}
