using System;
using Invoicing.Core.Data;
using Invoicing.Infrastructure.Data.Configuration;
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
        public virtual DbSet<InvoiceProduct> Invoiceproduct { get; set; }
        public virtual DbSet<Product> Product { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        
    }
}
