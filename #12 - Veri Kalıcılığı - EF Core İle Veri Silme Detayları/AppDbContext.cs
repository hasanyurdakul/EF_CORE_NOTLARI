using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12___Veri_Kalıcılığı___EF_Core_İle_Veri_Silme_Detayları
{
    public class ETicaretContext : DbContext
    {
        public DbSet<Urun> Urunler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=HASAN_YURDAKUL;Database=ETicaretDB;User ID=sa;Password=1q2w3e4r;TrustServerCertificate=True");
        }
    }
}
