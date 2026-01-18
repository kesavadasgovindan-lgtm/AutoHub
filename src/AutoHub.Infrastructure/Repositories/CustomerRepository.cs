using AutoHub.Application.Interfaces;
using AutoHub.Domain.Entities;
using AutoHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoHub.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AutoHubDbContext _context;

        public CustomerRepository(AutoHubDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public void Delete(Customer customer)
        {
            customer.IsDeleted = true;
            _context.Customers.Update(customer);
        }
    }
}
