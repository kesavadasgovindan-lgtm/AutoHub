using AutoHub.Domain.Entities;
using System.Threading.Tasks;

namespace AutoHub.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IItemRepository Items { get; }

        Task<int> SaveAsync();
    }
}
