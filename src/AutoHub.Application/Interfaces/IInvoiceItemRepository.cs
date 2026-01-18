using AutoHub.Domain.Entities;
using System.Threading.Tasks;

namespace AutoHub.Application.Interfaces
{
    public interface IInvoiceItemRepository
    {
        Task AddAsync(InvoiceItem item);
    }
}
