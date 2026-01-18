using AutoHub.Application.Interfaces;
using AutoHub.Domain.Entities;
using AutoHub.Infrastructure.Data;

namespace AutoHub.Infrastructure.Repositories
{
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        private readonly AutoHubDbContext _context;

        public InvoiceItemRepository(AutoHubDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(InvoiceItem item)
        {
            await _context.InvoiceItems.AddAsync(item);
        }
    }
}
