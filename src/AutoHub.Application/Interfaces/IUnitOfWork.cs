using System.Threading.Tasks;

namespace AutoHub.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IEmployeeRepository Employees { get; }
        IItemRepository Items { get; }

        IInvoiceRepository Invoices { get; }
        IInvoiceItemRepository InvoiceItems { get; }

        // ✅ Quotation
        IQuotationRepository Quotations { get; }
        IQuotationItemRepository QuotationItems { get; }

        Task<int> SaveChangesAsync();
    }
}
