using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace _10___Veri_Kalıcılığı___EF_Core_İle_Veri_Ekleme_Detayları
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            #region Veri Nasıl Eklenir?
            //ETicaretContext context = new();
            //Urun urun = new Urun() { UrunAdi = "A Urunu", Fiyat = 1000 };
            #endregion

            #region context.DbSet.AddAsync Fonksiyonu 
            //DbSet kullanılacagından type-safety kuralları çerçevesinde veri girişi yapmamızı sağlar
            //await context.Urunler.AddAsync(urun);
            #endregion

            #region EF Core Acısından Bir Verinin Eklenmesi Gerektiği Nasıl Anlasılıyor ?
            //Yapılacak işlem üzerinden bir state belirleniyor ve EfCore bu state üzerinden yapılması gerekn işlemi belirliyor.
            //ETicaretContext context = new();
            //Urun urun = new Urun() { UrunAdi = "c Urunu", Fiyat = 2001 };
            //Console.WriteLine(context.Entry(urun).State);
            //await context.AddAsync(urun);
            //Console.WriteLine(context.Entry(urun).State);
            //await context.SaveChangesAsync();
            //Console.WriteLine(context.Entry(urun).State);

            #endregion

            #region context.AddAsync Fonksiyonu
            //await context.AddAsync(urun); 
            #endregion

            #region context.SaveChanges Fonksiyonu 
            //await context.SaveChangesAsync();
            //Insert, Update ve Delete fonksiyonlarını olusturup, bir transaction aracılığıyla veritabanına gönderen fonksiyondur. Eğer ki oluşturulan sorgulardan herhangi biri başarısız olursa, tüm işlemler geri alınır. 
            #endregion

            #region Birden fazla veri eklerken nelere dikkat edilmelidir?
            #region SaveChanges'i verimli kullanalım.
            //ETicaretContext context = new();
            //Urun urun1 = new Urun() { UrunAdi = "AA Urunu", Fiyat = 2000 };
            //Urun urun2 = new Urun() { UrunAdi = "BB Urunu", Fiyat = 2000 };
            //Urun urun3 = new Urun() { UrunAdi = "CC Urunu", Fiyat = 2000 };
            //////////////////////////////////////////////////////////////////
            //await context.AddAsync(urun1);
            //await context.SaveChangesAsync();
            //                                                                //Şeklinde yapılan bir işlemde her SaveChanges metodu
            //                                                                //çağırıldıgında ayrı bir Transaction işlemşi çalışacak 
            //await context.AddAsync(urun2);                                  //ve bu da bize maliyet olarak dönecektir. 
            //await context.SaveChangesAsync();                               //ve bu da bize maliyet olarak dönecektir.
            //Bunun yerine tüm ekleme, silme vb. işlemlerin 
            //await context.AddAsync(urun3);                                  //tanımlanmasından sonra SaveChanges metodu çağırılmalıdır.
            //await context.SaveChangesAsync();
            //////////////////////////////////////////////////////////////////
            //await context.AddAsync(urun1);
            //await context.AddAsync(urun2);
            //await context.AddAsync(urun3);
            //await context.SaveChangesAsync();

            #endregion
            #region AddRange ile veri ekleme
            //ETicaretContext context = new();
            //Urun urun1 = new Urun() { UrunAdi = "AA Urunu", Fiyat = 2000 };
            //Urun urun2 = new Urun() { UrunAdi = "BB Urunu", Fiyat = 2000 };
            //Urun urun3 = new Urun() { UrunAdi = "CC Urunu", Fiyat = 2000 };

            //await context.Urunler.AddRangeAsync(urun1, urun2, urun3);
            //await context.SaveChangesAsync();
            //AddRange içine ürünleri tek tek parametre seklınde gonderebıldıgımız gıbı, IEnumerable interface'i içeren bir liste vb. obje de gönderebiliriz.
            #endregion
            #endregion

            #region Eklenen verinin generate edilen ID'sini elde etme.
            //TSQL sorgusundaki @@IDENTITY komutunu olarak düşünebiliriz.
            ETicaretContext context = new();
            Urun urun1 = new Urun() { UrunAdi = "AA Urunu", Fiyat = 2000 };
            await context.AddAsync(urun1);
            await context.SaveChangesAsync();
            Console.WriteLine(urun1.UrunID);
            #endregion





        }

    }
}