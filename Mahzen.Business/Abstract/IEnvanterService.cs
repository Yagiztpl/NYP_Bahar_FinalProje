using Mahzen.Entities.Abstract;
using Mahzen.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzen.Business.Abstract
{
    public interface IEnvanterService
    {
        void EkipmanKusanOyuncu(Oyuncu Oyuncu, Ekipman Ekipman);
        void EkipmanKusan(Varlik Varlik, Ekipman Ekipman);
        void EkipmanCikart(Varlik Varlik, Ekipman Ekipman);
        Ekipman EkipmanUret(Oyuncu oyuncu, Ekipman uretilecekEkipman);
        void EsyalariTopla(Dusman Dusman, Oyuncu Oyuncu);
        void Listele(Oyuncu Oyuncu);
        void Debug_EsyaEkle(Oyuncu oyuncu, string arananGirdi);
        void TuketilebilirKullan(Oyuncu oyuncu, Tuketilebilir tuketilebilir);
        void EkipmanIncele(Ekipman ekipman);
        void Sil(Oyuncu oyuncu, Esya esya);
    }
}
