using Microsoft.EntityFrameworkCore;

namespace _15__Single__SingleOrDefault__First__FirstOrDefault__Last__LastOrDefault__Find
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ETicaretContext context = new ETicaretContext();

            #region Tekil Veri Getiren Sorgulama Fonksiyonları


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
