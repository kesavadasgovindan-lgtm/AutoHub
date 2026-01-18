using AutoHub.Domain.Entities;
using System.Threading.Tasks;

namespace AutoHub.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IItemRepository Items { get; }

        IEmployeeRepository Employees { get; }

        IInvoiceRepository Invoices { get; }
        IInvoiceItemRepository InvoiceItems { get; }

        Task<int> SaveAsync();
    }
}
