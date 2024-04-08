using Microsoft.EntityFrameworkCore;

namespace _17___ToDictionary__ToArray__Select__SelectMany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ETicaretContext context = new ETicaretContext();

            #region Sorgu Sonucu Dönüşüm Fonksiyonları
            //Bu fonksiyonlar ile sorgu neticesinde elde edilen verileri isteğimiz doğrultusunda farklı türlerde projecsiyon edebiliyoruz.

            #region ToDictionary
            //Sorgu neticesinde gelecek olan veriyi bir dictioanry olarak elde etmek/tutmak/karşılamak istiyorsak eğer kullanılır!
            //var urunler = context.Urunler.ToDictionary(u => u.UrunAdi, u => u.Fiyat);

            //ToList ile aynı amaca hizmet etmektedir. Yani, oluşturulan sorguyu execute edip neticesini alırlar.
            //ToList : Gelen sorgu neticesini entity türünde bir koleksiyona(List<TEntity>) dönüştürmekteyken,
            //ToDictionary ise : Gelen sorgu neticesini Dictionary türünden bir koleksiyona dönüştürecektir.
            #endregion

            #region ToArray
            //Oluşturulan sorguyu dizi olarak elde eder.
            //ToList ile muadil amaca hizmet eder. Yani sorguyu execute eder lakin gelen sonucu entity dizisi  olarak elde eder.
            //var urunler = context.Urunler.ToArray();
            #endregion

            #region Select
            //Select fonksiyonunun işlevsel olarak birden fazla davranışı söz konusudur,
            //1. Select fonksiyonu, generate edilecek sorgunun çekilecek kolonlarını ayarlamamızı sağlamaktadır. 

            //var urunler =  context.Urunler.Select(u => new Urun
            //{
            //    Id = u.Id,
            //    Fiyat = u.Fiyat
            //}).ToList();

            //2. Select fonksiyonu, gelen verileri farklı türlerde karşılamamızı sağlar. T, anonim

            //var urunler =  context.Urunler.Select(u => new 
            //{
            //    Id = u.Id,
            //    Fiyat = u.Fiyat
            //}).ToList();


            //var urunler =  context.Urunler.Select(u => new UrunDetay
            //{
            //    Id = u.Id,
            //    Fiyat = u.Fiyat
            //}).ToList();

            #endregion

            #region SelectMany
            //Select ile aynı amaca hizmet eder. Lakin, ilişkisel tablolar neticesinde gelen koleksiyonel verileri de tekilleştirip projeksiyon etmemizi sağlar.

            //var urunler =  context.Urunler.Include(u => u.Parcalar).SelectMany(u => u.Parcalar, (u, p) => new
            //{
            //    u.Id,
            //    u.Fiyat,
            //    p.ParcaAdi
            //}).ToList();
            #endregion
            #endregion

        }


        #region Classes

        public class ETicaretContext : DbContext
        {
            public DbSet<Urun> Urunler { get; set; }
            public DbSet<Parca> Parcalar { get; set; }
            public DbSet<UrunParca> UrunParca { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=localhost, 1433;Database=ETicaretDB;User ID=SA;Password=1q2w3e4r+!");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<UrunParca>().HasKey(up => new { up.UrunId, up.ParcaId });
            }
        }
        public class Urun
        {
            public int Id { get; set; }
            public string UrunAdi { get; set; }
            public float Fiyat { get; set; }

            public ICollection<Parca> Parcalar { get; set; }
        }
        public class Parca
        {
            public int Id { get; set; }
            public string ParcaAdi { get; set; }
        }
        public class UrunParca
        {
            public int UrunId { get; set; }
            public int ParcaId { get; set; }

            public Urun Urun { get; set; }
            public Parca Parca { get; set; }
        }

        public class UrunDetay
        {
            public int Id { get; set; }
            public float Fiyat { get; set; }
        }
        #endregion

    }
}
