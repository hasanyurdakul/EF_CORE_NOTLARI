using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace _11___Veri_Kalıcılığı___EF_Core_İle_Veri_Güncelleme_Detayları
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Veri nasıl güncellenir?
            //ETicaretContext context = new ETicaretContext();
            //var Urun1 = context.Urunler.FirstOrDefault(x => x.UrunID == 1);
            //Urun1.UrunAdi = "H Urunu";
            //Urun1.Fiyat = 3000;
            //context.SaveChanges();
            #endregion

            #region Change Tracker nedir? (Kısaca)
            //"Context üzerinden gelen" verilerin takibinden sorumlu bir mekanizmadır. Bu takip mekanizması sayesinde, context üzerinden gelen verilerle igili işlemler neticesinde update veya delete sorgularının olusturulacagı anlasılır.
            #endregion

            #region Takip edilmeyen nesneler nasıl güncellenir?
            //ETicaretContext context = new();
            //var urun1 = new Urun()
            //{
            //    UrunID = 1,
            //    Fiyat = 40,
            //    UrunAdi = "HH Urunu"
            //};
            #region Update Fonksiyonu
            //Context üzerinden gelmeyen veriler, Change Tracker tarafından takip edilmez. Bu durumda bu verileri güncellemek için "Update" fonksiyonunu kullanırız.
            //!!!!ONEMLI!!!
            //Update fonksiyonunun kullanılabilmesi için ilgili nesnenin ID değerinin kesinlikle verilmesi gerekir. ID olmadan hangi verinin güncelleneceğini sistem anlayamayacaktır.
            //context.Update(urun1);
            //context.SaveChanges();
            #endregion
            #endregion

            #region EntityState nedir?
            //ETicaretContext context = new ETicaretContext();
            //Urun urun = new();
            //Console.WriteLine(context.Entry(urun).State); //Added
            #endregion

            #region Birden fazla veri güncellenirken nelere dikkat edilmelidir?
            ETicaretContext context = new ETicaretContext();
            var urunler = context.Urunler.ToList();
            foreach (var urun in urunler)
            {
                urun.UrunAdi += "*";
                context.SaveChanges();
            }
            //foreach ile "urunler" listesini dondugumuzde her seferinde SaveChanges metodu calisacagi icin her seferinde ayri bir transaction acilacaktir. Bu da maliyetin artmasi anlamina gelir. Bunun yerine tüm ürünler dönüldükten sonra SaveChanges, foreach dongusunun disina yazilmalidir. Yani;
            foreach (var urun in urunler)
            {
                urun.UrunAdi += "*";
            }
            context.SaveChanges();


            #endregion


        }
    }
}
