using AutoHub.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoHub.Application.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();

        Task<Item?> GetByIdAsync(int id);

        Task AddAsync(Item item);

        void Update(Item item);
    }
}
