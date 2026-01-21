using AutoHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoHub.Application.Interfaces
{
    public interface IQuotationRepository
    {
        Task AddAsync(Quotation quotation);
        Task<Quotation?> GetByIdAsync(int id);
        Task<List<Quotation>> GetAllAsync();
    }
}
