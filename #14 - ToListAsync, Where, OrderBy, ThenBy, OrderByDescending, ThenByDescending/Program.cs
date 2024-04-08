using Microsoft.EntityFrameworkCore;

namespace _14___ToListAsync__Where__OrderBy__ThenBy__OrderByDescending__ThenByDescending
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ETicaretContext context = new ETicaretContext();
            #region Cogul Veri Getiren Sorgulama Fonksiyonlari

            #region ToList()
            //Uretilen sorguyu execute etmemizi saglayan fonksiyondur.
            ///////////////////////////////////////////////
            ///Method Syntax
            //var urunler = context.Urunler.ToList();
            ///////////////////////////////////////////////
            ///Query Syntax
            //var urunler = from urun in context.Urunler
            //              select urun;
            //var data = urunler.ToList();
            ///////////////////////////////////////////////

            #endregion

            #region Where
            //Olusturulan sorguya Where sartini eklememizi saglar.
            ///////////////////////////////////////////////
            ///Method Syntax
            //var urunler = context.Urunler.Where(u => u.UrunID > 5).ToList();
            ///////////////////////////////////////////////
            ///Query Syntax
            //var urunlerQuery = (from urun in context.Urunler
            //                  where urun.UrunID > 5
            //                select urun).ToList();
            ///////////////////////////////////////////////
            #endregion

            #region OrderBy
            //Sorgu uzerinde siralama yapmamizi saglar. Default olarak Ascending olarak calısır. Descending olarak kullanılmak ıstenıyorsa, OrderByDescending() metodu cagırılmalıdır.
            ///////////////////////////////////////////////
            ///Method Syntax
            //var urunler = context.Urunler
            //    .Where(u => u.UrunID > 500 || u.UrunAdi
            //    .EndsWith("2"))
            //    .OrderBy(u => u.UrunID)
            //    .ToList();
            ///////////////////////////////////////////////
            ///Query Syntax
            //var urunlerQuery = (from urun in context.Urunler
            //                    where urun.UrunID > 500 || urun.UrunAdi.StartsWith("2")
            //                    orderby urun.UrunAdi ascending //ya da descending
            //                    select urun).ToList();
            ///////////////////////////////////////////////

            #endregion

            #region ThenBy 
            //OrderBy uzerınde yapılan bir sıralama islemini farklı kolonlara da uygulamamızı saglayan bır fonksıyondur. Burası da OrderBy gibi default olarak ascending olarak calısır. ThenByDescending() olarak da kullanılabilir.
            ///////////////////////////////////////////////
            ///Method Syntax
            //var urunler = context.Urunler
            //    .Where(u => u.UrunID > 500 || u.UrunAdi
            //    .EndsWith("2"))
            //    .OrderBy(u => u.UrunID)
            //    .ThenBy(u=>u.UrunAdi)
            //    .ToList();
            ///////////////////////////////////////////////
            ///Query Syntax
            ///Query Syntax yazarken ThenBy keywordu kullanılmaz. OrderBy yazarken ılk kolondan sonra vırgul konulur ve ıkıncı sıralanmak ıstenen kolon adı buraya gırılır.
            //var urunlerQuery = (from urun in context.Urunler
            //                    where urun.UrunID > 500 || urun.UrunAdi.StartsWith("2")
            //                    orderby urun.UrunAdi ascending ,urun.UrunID
            //                    select urun).ToList();
            ///////////////////////////////////////////////

            #endregion

            #endregion
        }

        #region Classes
        public class ETicaretContext : DbContext
        {
            public DbSet<Urun> Urunler { get; set; }
            public DbSet<Parca> Parcalar { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {

                optionsBuilder.UseSqlServer("Server=HASAN_YURDAKUL;Database=ETicaretDB;User ID=sa;Password=1q2w3e4r;TrustServerCertificate=True");
            }
        }

        public class Parca
        {
            public int ParcaID { get; set; }
            public string ParcaAdi { get; set; }
        }

        public class Urun
        {
            public int UrunID { get; set; }
            public string UrunAdi { get; set; }
            public float Fiyat { get; set; }
            public ICollection<Parca> Parcalar { get; set; }
        }
        #endregion
    }
}
