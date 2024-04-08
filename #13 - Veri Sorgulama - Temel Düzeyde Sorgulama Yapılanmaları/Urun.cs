using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13___Veri_Sorgulama___Temel_Düzeyde_Sorgulama_Yapılanmaları
{
    public class Urun
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public float Fiyat { get; set; }
        public ICollection<Parca> Parcalar{ get; set; }
    }

}
