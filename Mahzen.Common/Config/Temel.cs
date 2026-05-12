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
        public static Dictionary<string, Hasar> HasarKatalogu = new Dictionary<string, Hasar>()
            {
                // Fiziksel Hasarlar
                { "Kesme", new Hasar { Tip = HasarTipi.Fiziksel, Surec = HasarSureci.Anlik, Taban = 2 } },
                { "Delme", new Hasar { Tip = HasarTipi.Fiziksel, Surec = HasarSureci.Anlik, Taban = 2 } },
                { "Ezme", new Hasar { Tip = HasarTipi.Fiziksel, Surec = HasarSureci.Anlik, Taban = 2 } },
                { "Patlama", new Hasar { Tip = HasarTipi.Fiziksel, Surec = HasarSureci.Anlik, Taban = 3 } },

                // Elemental Hasarlar
                { "Ates", new Hasar { Tip = HasarTipi.Element, Surec = HasarSureci.ZamanlaSabit, Taban = 4 } },
                { "Toksik", new Hasar { Tip = HasarTipi.Element, Surec = HasarSureci.ZamanlaYuzde, Taban = 0.2 } },
                { "Elektrik", new Hasar { Tip = HasarTipi.Element, Surec = HasarSureci.AnlikYuzde, Taban = 0.05 } },
                { "Su", new Hasar { Tip = HasarTipi.Element, Surec = HasarSureci.ZamanlaYuzde, Zayiflatma = ZayiflatmaTipi.StatDusurur, Taban = 0.1 } },
                { "Buz", new Hasar { Tip = HasarTipi.Element, Surec = HasarSureci.ZamanlaYuzde, Zayiflatma = ZayiflatmaTipi.StatDusurur, Taban = 0.1 } },
                { "Lanet", new Hasar { Tip = HasarTipi.Element, Surec = HasarSureci.AnlikYuzde, Zayiflatma = ZayiflatmaTipi.HamleEngeller, Taban = 0.2 } },

                // Zihinsel Hasarlar
                { "Ikna", new Hasar {Tip = HasarTipi.Zihinsel, Surec = HasarSureci.Anlik, Zayiflatma = ZayiflatmaTipi.StatDusurur, Taban = 1} },
                { "Tehtid", new Hasar {Tip = HasarTipi.Zihinsel, Surec = HasarSureci.Anlik, Zayiflatma = ZayiflatmaTipi.HamleEngeller, Taban = 1} },
            };
    }
}
