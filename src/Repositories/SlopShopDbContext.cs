using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SlopShop.Entities;

namespace SlopShop.Repositories;

public partial class SlopShopDbContext : DbContext
{
    public SlopShopDbContext()
    {
    }

    public SlopShopDbContext(DbContextOptions<SlopShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:SlopShopDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("id");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.Category)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.MarketPrice).HasColumnName("market_price");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Rating)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("rating");
            entity.Property(e => e.SalePrice).HasColumnName("sale_price");
            entity.Property(e => e.SubCategory)
                .IsUnicode(false)
                .HasColumnName("sub_category");
            entity.Property(e => e.Type)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
