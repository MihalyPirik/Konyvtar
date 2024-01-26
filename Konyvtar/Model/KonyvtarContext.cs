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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Szerzo>().HasData(
                new Szerzo() { Keresztnev = "Isaac", Vezeteknev = "Asimov", szerzoID = '1' },
                new Szerzo() { Keresztnev = "Dick", Vezeteknev = "Philip", szerzoID = 2 },
                new Szerzo() { Keresztnev = "Géza", Vezeteknev = "Gárdonyi", szerzoID = 3 }
                );

            modelBuilder.Entity<Tipus>().HasData(
                new Tipus() { Nev = "Sci-Fi", TipusID = 1 },
                new Tipus() { Nev = "Fantasy", TipusID = 2 },
                new Tipus() { Nev = "Documentary", TipusID = 3 }
                );

            modelBuilder.Entity<Konyv>().HasData(
                new Konyv() { KonyvID = 1, Cim = "Ember a fellegvárban", Pontszam = 9, Oldalszam = 550, TipusID = 1, SzerzoID = 2 },
                new Konyv() { KonyvID = 2, Cim = "Egri Csillago", Pontszam = 6, Oldalszam = 520, TipusID = 3, SzerzoID = 3 }
                );
        }
    }
}
