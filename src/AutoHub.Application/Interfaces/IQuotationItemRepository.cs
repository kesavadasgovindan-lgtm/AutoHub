using AutoHub.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoHub.Application.Interfaces
{
    public interface IQuotationItemRepository
    {
        Task AddRangeAsync(List<QuotationItem> items);
    }
}
