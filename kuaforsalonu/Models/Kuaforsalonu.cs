using kuaforsalonu.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace kuaforsalonu.Models
{
    public class Kuaforsalonu : DbContext
    {
        public Kuaforsalonu(DbContextOptions<Kuaforsalonu> options) : base(options) { }

        // Veritabanı tablolarını temsil eden DbSet'ler

        public virtual DbSet<Calisan> Calisans { get; set; }
        public virtual DbSet<Musteri> Musteris { get; set; }
        public virtual DbSet<Randevu> Randevus { get; set; }
        public virtual DbSet<Saat> Saats { get; set; }
        public virtual DbSet<Salon> Salonlar { get; set; }
        public virtual DbSet<Yetki> Yetkis { get; set; }

        public virtual DbSet<Islem> Islemler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // İlgili tablo yapılandırmaları

            modelBuilder.Entity<Calisan>().ToTable("Çalışanlar");
            modelBuilder.Entity<Randevu>().ToTable("Randevular");
            modelBuilder.Entity<Musteri>().ToTable("Müşteriler");
            modelBuilder.Entity<Saat>().ToTable("Saat");
            modelBuilder.Entity<Salon>().ToTable("Salonlar");
            modelBuilder.Entity<Islem>().ToTable("Islemler");
            modelBuilder.Entity<Yetki>().ToTable("Yetki");
        }
    }
}
