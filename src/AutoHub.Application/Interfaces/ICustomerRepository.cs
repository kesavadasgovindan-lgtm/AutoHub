using AutoHub.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoHub.Domain.Entities;

namespace AutoHub.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();

        Task<Customer?> GetByIdAsync(int id);

        Task AddAsync(Customer customer);

        void Update(Customer customer);

        void Delete(Customer customer);
    }
}
