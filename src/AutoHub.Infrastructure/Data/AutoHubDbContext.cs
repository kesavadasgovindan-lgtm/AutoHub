using AutoHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AutoHub.Infrastructure.Data
{
    public class AutoHubDbContext : DbContext
    {
        public AutoHubDbContext(DbContextOptions<AutoHubDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Quotation> Quotations => Set<Quotation>();
        public DbSet<QuotationItem> QuotationItems => Set<QuotationItem>();

    }
}
