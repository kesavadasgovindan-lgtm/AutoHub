using AutoHub.Application.Interfaces;
using AutoHub.Domain.Entities;
using AutoHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoHub.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AutoHubDbContext _context;

        public ItemRepository(AutoHubDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _context.Items
                .Where(i => i.IsActive)
                .ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task AddAsync(Item item)
        {
            await _context.Items.AddAsync(item);
        }

        public void Update(Item item)
        {
            _context.Items.Update(item);
        }
    }
}
