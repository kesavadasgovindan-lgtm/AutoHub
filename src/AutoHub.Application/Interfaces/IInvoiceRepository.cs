using AutoHub.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoHub.Application.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetAllAsync();

        Task<Invoice?> GetByIdAsync(int id);

        Task AddAsync(Invoice invoice);
    }
}
