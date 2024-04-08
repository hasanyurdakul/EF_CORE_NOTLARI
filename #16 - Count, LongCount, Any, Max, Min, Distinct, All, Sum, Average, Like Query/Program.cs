using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace _16___Count__LongCount__Any__Max__Min__Distinct__All__Sum__Average__Like_Query
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ETicaretContext context = new ETicaretContext();
            #region Diğer Sorgulama Fonksiyonları
            #region Count
            //Oluşturulan sorgunun execute edilmesi neticesinde kaç adet satırın elde edileceğini sayısal olarak(int) bizlere bildiren fonksiyondur.
            //var urunler = (context.Urunler.ToList()).Count();
            //var urunler2 = context.Urunler.Count();
            #endregion

            #region LongCount
            //Oluşturulan sorgunun execute edilmesi neticesinde kaç adet satırın elde edileceğini sayısal olarak(long) bizlere bildiren fonksiyondur.
            //var urunler = context.Urunler.LongCount(u => u.Fiyat > 5000);
            #endregion

            #region Any
            //Sorgu neticesinde verinin gelip gelmediğini bool türünde dönen fonksiyondur. 
            //var urunler = context.Urunler.Where(u => u.UrunAdi.Contains("1")).Any();
            //var urunler = context.Urunler.Any(u => u.UrunAdi.Contains("1"));
            #endregion

            #region Max
            //Verilen kolondaki max değeri getirir.
            //var fiyat = context.Urunler.Max(u => u.Fiyat);
            #endregion

            #region Min
            //Verilen kolondaki min değeri getirir.
            //var fiyat = context.Urunler.Min(u => u.Fiyat);
            #endregion

            #region Distinct
            //Sorguda mükerrer kayıtlar varsa bunları tekilleştiren bir işleve sahip fonksiyondur.
            //var urunler = context.Urunler.Distinct().ToList();
            #endregion

            #region All
            //Bir sorgu neticesinde gelen verilerin, verilen şarta uyup uymadığını kontrol etmektedir. Eğer ki tüm veriler şarta uyuyorsa true, uymuyorsa false döndürecektir.
            //var m = context.Urunler.All(u => u.Fiyat < 15000);
            //var m = context.Urunler.All(u => u.UrunAdi.Contains("a"));
            #endregion

            #region Sum
            //Vermiş olduğumuz sayısal proeprtynin toplamını alır.
            //var fiyatToplam = context.Urunler.Sum(u => u.Fiyat);
            #endregion

            #region Average
            //Vermiş olduğumuz sayısal proeprtynin aritmatik ortalamasını alır.
            //var aritmatikOrtalama = context.Urunler.Average(u => u.Fiyat);
            #endregion

            #region Contains
            //Like '%...%' sorgusu oluşturmamızı sağlar.
            //var urunler = context.Urunler.Where(u => u.UrunAdi.Contains("7")).ToList();
            #endregion

            #region StartsWith
            //Like '...%' sorgusu oluşturmamızı sağlar.
            //var urunler = context.Urunler.Where(u => u.UrunAdi.StartsWith("7")).ToList();
            #endregion

            #region EndsWith
            //Like '%...' sorgusu oluşturmamızı sağlar.
            //var urunler = context.Urunler.Where(u => u.UrunAdi.EndsWith("7")).ToList();
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
