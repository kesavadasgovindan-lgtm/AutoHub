using AutoHub.Application.Interfaces;
using AutoHub.Domain.Entities;
using AutoHub.Infrastructure.Data;

namespace AutoHub.Infrastructure.Repositories
{
    public class QuotationItemRepository : IQuotationItemRepository
    {
        private readonly AutoHubDbContext _context;

        public QuotationItemRepository(AutoHubDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(List<QuotationItem> items)
        {
            await _context.QuotationItems.AddRangeAsync(items);
        }
    }
}
