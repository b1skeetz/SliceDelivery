using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SliceDelivery.Domain.Models;

#nullable disable

namespace SliceDelivery.DAL
{
    public partial class DiplomaContext : DbContext
    {
        public DiplomaContext()
        {
        }

        public DiplomaContext(DbContextOptions<DiplomaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<Mailers> Mailers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Diploma;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Basket>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Baskets_UserId")
                    .IsUnique();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Basket)
                    .HasForeignKey<Basket>(d => d.UserId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.BasketId, "IX_Orders_BasketId");

                entity.HasOne(d => d.Basket)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BasketId);
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Profiles_UserId")
                    .IsUnique();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Profile)
                    .HasForeignKey<Profile>(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
