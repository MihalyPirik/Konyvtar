using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtar.Model
{
    public class KonyvtarContext : DbContext
    {
        public DbSet<Szerzo> Szerzo { get; set; }
        public DbSet<Konyv> Konyv { get; set; }
        public DbSet<Kolcsonzes> Kolcsonzes { get; set; }
        public DbSet<Tanulo> Tanulo { get; set; }
        public DbSet<Tipus> Tipus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;database=Konyvtar;uid=root;pwd=;", ServerVersion.AutoDetect("Server=localhost;database=Konyvtar;uid=root;pwd=;"));
        }
    }
}
