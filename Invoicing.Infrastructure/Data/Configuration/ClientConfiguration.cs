using Invoicing.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoicing.Infrastructure.Data.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.Idclient);

            builder.ToTable("client");

            builder.Property(e => e.Idclient).HasColumnName("idclient");

            builder.Property(e => e.Document)
                .HasColumnName("document")
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.Lastname)
                .IsRequired()
                .HasColumnName("lastname")
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.Phone)
                .IsRequired()
                .HasColumnName("phone")
                .HasMaxLength(16)
                .IsUnicode(false);
        }
    }
}
