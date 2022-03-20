using Invoicing.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Infrastructure.Data.Configuration
{
    public class InvoiceProductConfiguration: IEntityTypeConfiguration<InvoiceProduct>
    {
        public void Configure(EntityTypeBuilder<InvoiceProduct> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("invoiceproduct");

            builder.Property(e => e.Id).HasColumnName("idinvoiceproduct");

            builder.Property(e => e.Idinvoice).HasColumnName("idinvoice");

            builder.Property(e => e.Idproduct).HasColumnName("idproduct");

            builder.Property(e => e.Value)
                .HasColumnName("value")
                .HasColumnType("decimal(18, 0)");

            builder.Property(e => e.Quantity).HasColumnName("Quantity");

            builder.HasOne(d => d.IdinvoiceNavigation)
                .WithMany(p => p.Invoiceproduct)
                .HasForeignKey(d => d.Idinvoice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkIPidinvoice");

            builder.HasOne(d => d.IdproductNavigation)
                .WithMany(p => p.Invoiceproduct)
                .HasForeignKey(d => d.Idproduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkIPidproduct");
        }
    }
}
