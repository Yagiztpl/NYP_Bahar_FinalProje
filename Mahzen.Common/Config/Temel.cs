using Mahzen.Entities.Concrete;
using Mahzen.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Common.Config
{
    public class Temel
    {
        public static double ZorlukCarpani = 1;
        public static Dictionary<HasarTipi, Hasar> HasarKatalogu = new Dictionary<HasarTipi, Hasar>()
        {
            // Fiziksel Hasarlar
            { HasarTipi.Kesme, new Hasar { Sinif = HasarSinifi.Fiziksel, Surec = HasarSureci.Anlik, Taban = 2 } },
            { HasarTipi.Delme, new Hasar { Sinif = HasarSinifi.Fiziksel, Surec = HasarSureci.Anlik, Taban = 2 } },
            { HasarTipi.Ezme, new Hasar { Sinif = HasarSinifi.Fiziksel, Surec = HasarSureci.Anlik, Taban = 2 } },
            { HasarTipi.Patlama, new Hasar { Sinif = HasarSinifi.Fiziksel, Surec = HasarSureci.Anlik, Taban = 3 } },

            // Elemental Hasarlar
            { HasarTipi.Ates, new Hasar { Sinif = HasarSinifi.Element, Surec = HasarSureci.ZamanlaSabit, Taban = 4 } },
            { HasarTipi.Toksik, new Hasar { Sinif = HasarSinifi.Element, Surec = HasarSureci.ZamanlaYuzde, Taban = 0.3 } },
            { HasarTipi.Elektrik, new Hasar { Sinif = HasarSinifi.Element, Surec = HasarSureci.AnlikYuzde, Taban = 0.05 } },
            { HasarTipi.Su, new Hasar { Sinif = HasarSinifi.Element, Surec = HasarSureci.ZamanlaYuzde, Zayiflatma = ZayiflatmaTipi.StatDusurur, Taban = 0.1, StatOdagi = StatOdagi.Dayaniklilik } },
            { HasarTipi.Buz, new Hasar { Sinif = HasarSinifi.Element, Surec = HasarSureci.ZamanlaYuzde, Zayiflatma = ZayiflatmaTipi.StatDusurur, Taban = 0.1, StatOdagi = StatOdagi.Hiz } },
            { HasarTipi.Lanet, new Hasar { Sinif = HasarSinifi.Element, Surec = HasarSureci.AnlikYuzde, Taban = 0.15 } },

            // Zihinsel Hasarlar
            { HasarTipi.Ikna, new Hasar { Sinif = HasarSinifi.Zihinsel, Surec = HasarSureci.Anlik, Taban = 1} },
            { HasarTipi.Tehtid, new Hasar { Sinif = HasarSinifi.Zihinsel, Surec = HasarSureci.Anlik, Taban = 1} }
        };
    }
}
