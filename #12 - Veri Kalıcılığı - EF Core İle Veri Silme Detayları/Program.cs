using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace _12___Veri_Kalıcılığı___EF_Core_İle_Veri_Silme_Detayları
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Veri nasil silinir?
            //ETicaretContext context = new ETicaretContext();
            //Urun urun = context.Urunler.FirstOrDefault(x => x.UrunID == 5);
            //context.Urunler.Remove(urun);
            //context.SaveChanges();
            #endregion

            #region ChangeTracker ile takip edilemeyen nesneler nasil silinir?
            //ETicaretContext context = new ETicaretContext();
            //var urun2 = new Urun()
            //{
            //    UrunID = 3,
            //    Fiyat = 2222,
            //    UrunAdi = "ZZ Urunu"
            //};
            //context.Urunler.Remove(urun2);
            //context.SaveChanges();
            #endregion

            #region EntityState ile silme islemi 
            ETicaretContext context = new ETicaretContext();
            var urun3 = new Urun()
            {
                UrunID = 5,
                Fiyat = 2222,
                UrunAdi = "YY Urunu"
            };
            //Entity'nin EntityState'ini Deleted olarak set edersek ve ardından SaveChanges metodunu cagirirsak, entity silincektir.
            context.Entry(urun3).State = EntityState.Deleted;
            context.SaveChanges();
            #endregion

            #region RemoveRange ile silme islemi
            context.RemoveRange(context.Urunler.Where(x => x.UrunID > 7 && x.UrunID < 9).ToList());
            context.SaveChanges();
            #endregion







        }
    }
}
