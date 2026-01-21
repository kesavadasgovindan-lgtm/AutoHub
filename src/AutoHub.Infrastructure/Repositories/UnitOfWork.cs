using AutoHub.Application.Interfaces;
using AutoHub.Infrastructure.Data;

namespace AutoHub.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AutoHubDbContext _context;

        public ICustomerRepository Customers { get; }
        public IEmployeeRepository Employees { get; }
        public IItemRepository Items { get; }

        public IInvoiceRepository Invoices { get; }
        public IInvoiceItemRepository InvoiceItems { get; }

        public IQuotationRepository Quotations { get; }
        public IQuotationItemRepository QuotationItems { get; }

        public UnitOfWork(
            AutoHubDbContext context,

            ICustomerRepository customers,
            IEmployeeRepository employees,
            IItemRepository items,

            IInvoiceRepository invoices,
            IInvoiceItemRepository invoiceItems,

            IQuotationRepository quotations,
            IQuotationItemRepository quotationItems
        )
        {
            _context = context;

            Customers = customers;
            Employees = employees;
            Items = items;

            Invoices = invoices;
            InvoiceItems = invoiceItems;

            Quotations = quotations;
            QuotationItems = quotationItems;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
