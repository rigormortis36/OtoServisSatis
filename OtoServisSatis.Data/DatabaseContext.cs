using Microsoft.EntityFrameworkCore;
using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Servis> Servisler { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=10.0.100.194;initial catalog=OtoServisSatisNetCore;persist security info=True;user id=bilgiislem;password=pos123*;MultipleActiveResultSets=True;Trust Server Certificate=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            modelBuilder.Entity<Marka>().Property(m=>m.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().Property(m => m.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id=1,
                Adi="Admin",
            });
            modelBuilder.Entity<Kullanici>().HasData(new Kullanici
            {
                Id=1,
                Adi="Admin",
                AktifMi=true,
                EklenmeTarihi=DateTime.Now,
                Email="admin@otoservisstasi.tc",
                KullaniciAdi="admin",
                Sifre="123456",
                //Rol=new Rol { Id=1},
                RolId=1,
                Soyadi="admin",
                Telefon="8385",
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
