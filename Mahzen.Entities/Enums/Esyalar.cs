using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Entities.Enums
{
    public enum EsyaNadirligi
    {
        Kirik, //0.50x
        Kalitesiz, //0.8x
        Basit, // 1x
        Nadir, // 1.25x
        Epik, // 1.5x
        Efsanevi, // 2x
        Eser // 2x + %20
    }
    public enum EkipmanTipi
    {
        Silah,
        Zırh,
    }

    public enum EsyaIsimleri
    {
        // Materyal
        //0
        CurukOdun,
        HayvanPostu,
        SifaliOt,
        KirikKemik,
        //1
        CelikKulce,
        IslenmisDeri,
        YaratikKesesi,
        RunikToz,
        //2
        TungstenKulce,
        YaratikPulu,
        PeriTozu,
        BuyuKristali,
        // Ekipman 
        //0
        HasarliZirh,
        TahtaKalkan,
        EskiCubbe,
        KemikHancer,
        //1
        CelikKilic,
        CelikZirh,
        RunikAsa,
        KeskinBalta,
        //2
        TungstenAsa,
        PulZirh,
        KristalAsa,
        CehennemTirpani,
        // Tüketilebilir
        //0
        KufluEkmek,
        KirliBandaj,
        //1
        SaglikIksiri,
        AdrenalinIgnesi,
        //2
        IhyaIksiri,
        YildirimParsomeni
    }
}

