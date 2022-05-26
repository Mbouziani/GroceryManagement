using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GroceryManagement.Models
{
    public partial class MarketManagementDBContext : DbContext
    {
        public MarketManagementDBContext()
        {
        }

        public MarketManagementDBContext(DbContextOptions<MarketManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Reciep> Recieps { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>(entity =>
            {
                entity.ToTable("Agent");

                entity.Property(e => e.AgentId).HasColumnName("agentId");

                entity.Property(e => e.AgentAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("agentAddress");

                entity.Property(e => e.AgentEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("agentEmail");

                entity.Property(e => e.AgentMobile)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("agentMobile");

                entity.Property(e => e.AgentName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("agentName");

                entity.Property(e => e.AgentTele)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("agentTele");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.ProductBarcode).HasColumnName("productBarcode");

                entity.Property(e => e.ProductImageLink)
                    .HasMaxLength(700)
                    .IsUnicode(false)
                    .HasColumnName("productImageLink");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.ProductPrice).HasColumnName("productPrice");
            });

            modelBuilder.Entity<Reciep>(entity =>
            {
                entity.ToTable("reciep");

                entity.Property(e => e.ReciepId).HasColumnName("reciepID");

                entity.Property(e => e.PriceTotalWithTax).HasColumnName("priceTotalWithTax");

                entity.Property(e => e.ReciepDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("reciepDate");

                entity.Property(e => e.ReciepNumber).HasColumnName("reciepNumber");

                entity.Property(e => e.ReciepProductCount).HasColumnName("reciepProductCount");

                entity.Property(e => e.ReciepTotalPrice).HasColumnName("reciepTotalPrice");

                entity.Property(e => e.RecieppriceTax).HasColumnName("recieppriceTax");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sale");

                entity.Property(e => e.SaleId).HasColumnName("saleID");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.ReciepId).HasColumnName("reciepID");

                entity.Property(e => e.SaleQuntity).HasColumnName("saleQuntity");

                entity.Property(e => e.SaleTotalPrice).HasColumnName("saleTotalPrice");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__sale__productID__2B3F6F97");

                entity.HasOne(d => d.Reciep)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ReciepId)
                    .HasConstraintName("FK__sale__reciepID__2C3393D0");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.UserAge)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("userAge");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("userEmail");

                entity.Property(e => e.UserName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.Property(e => e.UserNumberLogin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userNumberLogin");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("userPassword");

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("userPhone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
