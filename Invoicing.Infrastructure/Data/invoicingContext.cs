using System;
using Invoicing.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Invoicing.Infrastructure.Data
{
    public partial class invoicingContext : DbContext
    {
        public invoicingContext()
        {
        }

        public invoicingContext(DbContextOptions<invoicingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Invoiceproduct> Invoiceproduct { get; set; }
        public virtual DbSet<Product> Product { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Idclient);

                entity.ToTable("client");

                entity.Property(e => e.Idclient).HasColumnName("idclient");

                entity.Property(e => e.Document)
                    .HasColumnName("document")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Idinvoice);

                entity.ToTable("invoice");

                entity.Property(e => e.Idinvoice).HasColumnName("idinvoice");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Idclient).HasColumnName("idclient");

                entity.HasOne(d => d.IdclientNavigation)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.Idclient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkinvoiceclient");
            });

            modelBuilder.Entity<Invoiceproduct>(entity =>
            {
                entity.HasKey(e => e.Idinvoiceproduct);

                entity.ToTable("invoiceproduct");

                entity.Property(e => e.Idinvoiceproduct).HasColumnName("idinvoiceproduct");

                entity.Property(e => e.Idinvoice).HasColumnName("idinvoice");

                entity.Property(e => e.Idproduct).HasColumnName("idproduct");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdinvoiceNavigation)
                    .WithMany(p => p.Invoiceproduct)
                    .HasForeignKey(d => d.Idinvoice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkIPidinvoice");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.Invoiceproduct)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkIPidproduct");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Idproduct);

                entity.ToTable("product");

                entity.Property(e => e.Idproduct).HasColumnName("idproduct");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasColumnName("productname")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("decimal(18, 0)");
            });

            
        }

        
    }
}
