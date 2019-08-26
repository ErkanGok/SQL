using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖgrenciListesi
{

    //veritabanından veri çekme veri silme işlemi için tablonun kodsal karşılığı

    public class ListeKatmanı
    {

        //datayı karşılayacak nesne
        public int Okul_NO { get; set; }
        public string İsim { get; set; }
        public string Soyisim { get; set; }
        public string Bölüm { get; set; }
        public double Ortalaması { get; set; }
    }
}
