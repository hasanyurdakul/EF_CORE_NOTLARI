using Microsoft.EntityFrameworkCore;


namespace Lesson9
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        public class ETicaretContext : DbContext
        {
            public DbSet<Urun> Urunler { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                //Provider 
                //Connection String
                //Lazy Loading olacak mı olmayacak mı ?
                //vb. yapılandırmalar OnConfiguring metodu override edilerek yapılır.
                optionsBuilder.UseSqlServer("Server=HASAN_YURDAKUL;Database=ETicaretDB;User ID=sa;Password=1q2w3e4r;TrustServerCertificate=True");
            }
        }
        public class Urun
        {
            //Aşağıdaki isimlendirmelerin hepsi default konfigürasyonda naming convention nedeni ile Primary Key olarak kabul edilecektir.
            //public int Id { get; set; }
            //public int ID { get; set; }
            //public int UrunId { get; set; }
            //public int UrunID { get; set; }
            public int UrunID { get; set; }

        }



        #region OnConfiguring ile Konfigürasyon Ayarlarını Gerçekleştirmek
        //EF Core Tool'unu yapılandırmak için kullandığımız bir metottur.
        //Context nesnesi içinde override edilerek kullanılır.

        #endregion

        #region Basit Düzeyde Entity Tanımlama Kuralları
        //EF Core, her tablonun varsayılan olarak bir primary key kolonu olmasını gerektiğini kabul eder.
        //Bundan dolayı, bu kolonu temsil eden bir property tanımlamadığımız taktirde hata verecektir!
        #endregion

        #region Tablo Adını Belirleme
        //Default olarak tablo adları, yaratılan "DbSet" nesnelerine verdiğimiz isim olacaktır.
        #endregion

    }
}




