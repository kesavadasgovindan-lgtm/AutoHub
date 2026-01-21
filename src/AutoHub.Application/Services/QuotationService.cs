using AutoHub.Application.Interfaces;
using AutoHub.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoHub.Application.Services
{
    public class QuotationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuotationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateQuotationAsync(Quotation quotation)
        {
            await _unitOfWork.Quotations.AddAsync(quotation);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<Quotation>> GetAllAsync()
        {
            return await _unitOfWork.Quotations.GetAllAsync();
        }

        public async Task<Quotation?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Quotations.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Quotation quotation)
        {
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task MarkAsConvertedAsync(Quotation quotation)
        {
            quotation.Status = "Converted";
            await _unitOfWork.SaveChangesAsync();
        }


    }
}
