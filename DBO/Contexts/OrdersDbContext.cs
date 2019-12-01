using System;
using DBO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBO.Contexts
{
    public partial class OrdersDbContext : DbContext
    {
        public OrdersDbContext()
        {
        }

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<BillingAddress> BillingAddresses { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-A3GFMQ8\SQLEXPRESS01;Database=ordersdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasIndex(e => e.OrderOxId);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.OrderOx)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.OrderOxId);
            });

            modelBuilder.Entity<BillingAddress>(entity =>
            {
                entity.HasIndex(e => e.OrderOxId)
                    .IsUnique();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.OrderOx)
                    .WithOne(p => p.BillingAddresses)
                    .HasForeignKey<BillingAddress>(d => d.OrderOxId);
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OxId);

                entity.Property(e => e.OxId).ValueGeneratedNever();

                entity.Property(e => e.OrderDatetime).HasColumnType("smalldatetime");

                entity.HasOne(d => d.OrderStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatus);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasIndex(e => e.OrderOxId);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MethodName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.OrderOx)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderOxId);
            });
        }
    }
}
