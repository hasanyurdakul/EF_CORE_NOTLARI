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

        }
    }
}
