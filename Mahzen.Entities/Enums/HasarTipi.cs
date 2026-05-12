using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Entities.Enums
{
    public enum HasarSinifi
    {
        Fiziksel,
        Zihinsel,
        Element
    }
    public enum HasarSureci 
    { 
        Anlik, 
        AnlikYuzde,
        ZamanlaSabit, 
        ZamanlaYuzde 
    }
    public enum ZayiflatmaTipi
    { 
      StatDusurur, 
      HamleEngeller 
    }

    public enum StatOdagi
    {
        Guc,
        Hiz,
        Dayaniklilik,
        Zeka,
        Karizma
    }
    public enum HamleOdagi
    {
        Saldiri,
        Savunma,
        Tehtid,
        Esya
    }

    public enum HasarTipi
    {
        // Fiziksel Hasarlar
        Kesme,
        Delme,
        Ezme,
        Patlama,
        // Elemental Hasarlar
        Ates,
        Toksik,
        Elektrik,
        Su,
        Buz,
        Lanet,
        // Zihinsel Hasarlar
        Ikna,
        Tehtid,
        // --- Eklenti Kökenli
        // Fiziksel Hasarlar
        // Elemental Hasarlar
        // Zihinsel Hasarlar
    }
}
