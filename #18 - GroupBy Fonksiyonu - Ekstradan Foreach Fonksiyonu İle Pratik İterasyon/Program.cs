using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace _18___GroupBy_Fonksiyonu___Ekstradan_Foreach_Fonksiyonu_İle_Pratik_İterasyon
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ETicaretContext context = new ETicaretContext();
            #region GroupBy Fonksiyonu
            //Gruplama yapmamızı sağlayan fonksiyondur.
            #region Method Syntax
            //var datas = context.Urunler.GroupBy(u => u.Fiyat).Select(group => new
            //{
            //    Count = group.Count(),
            //    Fiyat = group.Key
            //}).ToList();
            #endregion
            #region Query Syntax
            var datas = (from urun in context.Urunler
                         group urun by urun.Fiyat
                        into @group
                         select new
                         {
                             Fiyat = @group.Key,
                             Count = @group.Count()
                         }).ToList();
            #endregion
            #endregion



            #region Foreach Fonksiyonu
            //Bir sorgulama fonksiyonu felan değildir!
            //Sorgulama neticesinde elde edilen koleksiyonel veriler üzerinde iterasyonel olarak dönmemizi ve teker teker verileri elde edip işlemler yapabilmemizi sağlayan bir fonksiyondur. foreach döngüsünün metot halidir!

            foreach (var item in datas)
            {

            }
            datas.ForEach(x =>
            {

            });
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
