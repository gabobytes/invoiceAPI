using Invoicing.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Infrastructure.Data.Configuration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {

            builder.HasKey(e => e.Id);

            builder.ToTable("invoice");

            builder.Property(e => e.Id).HasColumnName("idinvoice");

            builder.Property(e => e.Date)
                .HasColumnName("date")
                .HasColumnType("date");

            builder.Property(e => e.Idclient).HasColumnName("idclient");

            builder.HasOne(d => d.IdclientNavigation)
                .WithMany(p => p.Invoice)
                .HasForeignKey(d => d.Idclient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkinvoiceclient");
        }
        
    }
}
