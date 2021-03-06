﻿using Microsoft.EntityFrameworkCore;
using XYZ.InventoryManagementSystem.Framework.MidTable;

namespace XYZ.InventoryManagementSystem.Framework
{
    public class FrameworkContext : DbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public FrameworkContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // For Product table
            modelBuilder.Entity<Product>().Property(p => p.Price)
                .IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Qty)
                .IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Description)
                .IsRequired();

            // many to many relationship to Product and Color table
            modelBuilder.Entity<ProductColor>()
                .HasKey(t => new { t.ProductId, t.ColorId });

            modelBuilder.Entity<ProductColor>()
                .HasOne(p => p.Product)
                .WithMany(pc => pc.ProductColor)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<ProductColor>()
                .HasOne(c => c.Color)
                .WithMany(p => p.ProductColor)
                .HasForeignKey(p => p.ColorId);

            // One to many relationship Product to Brand
            modelBuilder.Entity<Product>()
                .HasOne(b => b.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.BrandId);

            // Many to many relationship Product to Size
            modelBuilder.Entity<ProductSize>()
                .HasKey(t => new { t.ProductId, t.SizeId });

            modelBuilder.Entity<ProductSize>()
                .HasOne(p => p.Product)
                .WithMany(s => s.ProductSizes)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<ProductSize>()
                .HasOne(s => s.Size)
                .WithMany(ps => ps.ProductSizes)
                .HasForeignKey(s => s.SizeId);

            // Many to many relation between Product to Store
            modelBuilder.Entity<ProductStore>()
                .HasKey(ps => new { ps.ProductId, ps.StoreId});

            modelBuilder.Entity<ProductStore>()
                .HasOne(p => p.Product)
                .WithMany(ps => ps.ProductStores)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<ProductStore>()
                .HasOne(s => s.Store)
                .WithMany(ps => ps.ProductStores)
                .HasForeignKey(s => s.StoreId);

            // For Store table 
            modelBuilder.Entity<Store>()
                .Property(s => s.Name)
                .IsRequired();
            base.OnModelCreating(modelBuilder);

            // For Order table
            modelBuilder.Entity<Order>()
                .Property(n => n.ProductName)
                .IsRequired();
            modelBuilder.Entity<Order>()
                .Property(a => a.Address)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(a => a.Phone)
                .IsRequired();

            modelBuilder.Entity<Order>()
               .Property(a => a.CustomerName)
               .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(a => a.Qty)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(a => a.Rate)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(a => a.Amount)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(a => a.NetAmount)
                .IsRequired();
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Group> Groups { get; set; } 
    }
}
