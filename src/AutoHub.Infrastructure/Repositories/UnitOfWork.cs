using AutoHub.Application.Interfaces;
using AutoHub.Infrastructure.Data;

namespace AutoHub.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AutoHubDbContext _context;

        public UnitOfWork(AutoHubDbContext context)
        {
            _context = context;

            Customers = new CustomerRepository(_context);
            Items = new ItemRepository(_context);
        }

        public ICustomerRepository Customers { get; }

        public IItemRepository Items { get; }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
