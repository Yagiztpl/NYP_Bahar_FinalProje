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
        string OyuncuSaldirisiUygula(Oyuncu oyuncu, Dusman dusman, double hasar, bool savunmada);
        string DusmanSaldirisiUygula(Dusman dusman, Oyuncu oyuncu, double hasar, bool oyuncuSavunmada);
    }
}
