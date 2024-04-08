namespace _13___Veri_Sorgulama___Temel_Düzeyde_Sorgulama_Yapılanmaları
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ETicaretContext context = new ETicaretContext();

            #region En temel basit bir sorgulama nasil yapilir?
            ///////////////////////////////////////////////////////////////////////////////////////
            ///Method Sytnax///////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////
            var urunlerMethod = context.Urunler.ToList();
            ///////////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////////
            ///Query Sytnax////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////
            var urunlerQuery = (from urun in context.Urunler
                                select urun).ToList();
            ///////////////////////////////////////////////////////////////////////////////////////
            #endregion

            #region IQueryable ve IEnumerable basit olarak nelerdir?
            #region IQueryable 
            //Sorguya karsilik gelir. 
            //EF Core uzerinden yapilmis olan sorgunun execute edilmemis halini ifade eder.
            #endregion

            #region IEnumerable 
            //Sorgunun calistirilip yani execute edilip, in memory ' ye yuklemis halidir.
            #endregion
            #endregion

            #region Deferred Execution (Ertelenmis Calisma)
            //IQueryable calismalarinda ilgili kod yazildigi noktada tetiklenmez yani execute edilmez. Yani ilgili kod yazildigi noktada sorgu generate etmez. Kod, ToList() veya foreach dongusu gibi durumlarda kullanıldıgında sorgu generate eder. Iste bu duruma Deferred Execution denir.
            #endregion







        }
    }
}
