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

        public virtual DbSet<Salon> Salonlar { get; set; }
        public virtual DbSet<Islem> Islemler { get; set; }
        public virtual DbSet<Admin> Adminler { get; set; }
        public virtual DbSet<Randevu> Randevular { get; set; }
        public virtual DbSet<Musteri> Musteriler { get; set; }
        public virtual DbSet<Saat> Saatler { get; set; }
        public virtual DbSet<Yetki> Yetkiler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // İlgili tablo yapılandırmaları

            modelBuilder.Entity<Calisan>().ToTable("Çalışanlar");
            modelBuilder.Entity<Salon>().ToTable("Salonlar");
            modelBuilder.Entity<Islem>().ToTable("Islemler");
            modelBuilder.Entity<Admin>().ToTable("Adminler");
            modelBuilder.Entity<Randevu>().ToTable("Randevular");
            modelBuilder.Entity<Musteri>().ToTable("Musteriler");
            modelBuilder.Entity<Saat>().ToTable("Saatler");
            modelBuilder.Entity<Yetki>().ToTable("Yetkiler");

        }
    }
}
