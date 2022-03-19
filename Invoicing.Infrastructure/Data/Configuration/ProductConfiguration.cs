using Invoicing.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Infrastructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Idproduct);

            builder.ToTable("product");

            builder.Property(e => e.Idproduct).HasColumnName("idproduct");

            builder.Property(e => e.Productname)
                .IsRequired()
                .HasColumnName("productname")
                .HasMaxLength(10)
                .IsFixedLength();

            builder.Property(e => e.Value)
                .HasColumnName("value")
                .HasColumnType("decimal(18, 0)");
        }
    }
}
