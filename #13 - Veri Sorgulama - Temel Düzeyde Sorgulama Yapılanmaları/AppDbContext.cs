using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13___Veri_Sorgulama___Temel_Düzeyde_Sorgulama_Yapılanmaları
{
    public class ETicaretContext : DbContext
    {
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Parca> Parcalar{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=HASAN_YURDAKUL;Database=ETicaretDB;User ID=sa;Password=1q2w3e4r;TrustServerCertificate=True");
        }
    }
}
