using AutoHub.Application.Interfaces;
using AutoHub.Domain.Entities;
using AutoHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoHub.Infrastructure.Repositories
{
    public class QuotationRepository : IQuotationRepository
    {
        private readonly AutoHubDbContext _context;

        public QuotationRepository(AutoHubDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Quotation quotation)
        {
            await _context.Quotations.AddAsync(quotation);
        }

        public async Task<List<Quotation>> GetAllAsync()
        {
            return await _context.Quotations
                .Include(q => q.Customer)
                .Include(q => q.Items)
                .ToListAsync();
        }

        public async Task<Quotation?> GetByIdAsync(int id)
        {
            return await _context.Quotations
                .Include(q => q.Items)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
