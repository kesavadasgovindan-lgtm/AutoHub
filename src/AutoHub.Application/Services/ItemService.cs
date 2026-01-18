using AutoHub.Application.Interfaces;
using AutoHub.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoHub.Application.Services
{
    public class ItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _unitOfWork.Items.GetAllAsync();
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Items.GetByIdAsync(id);
        }

        public async Task CreateAsync(Item item)
        {
            await _unitOfWork.Items.AddAsync(item);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(Item item)
        {
            _unitOfWork.Items.Update(item);
            await _unitOfWork.SaveAsync();
        }

        // Stock increase (purchase)
        public async Task IncreaseStockAsync(int itemId, int quantity)
        {
            var item = await _unitOfWork.Items.GetByIdAsync(itemId);
            if (item == null) return;

            item.Stock += quantity;
            _unitOfWork.Items.Update(item);

            await _unitOfWork.SaveAsync();
        }

        // Stock decrease (billing)
        public async Task DecreaseStockAsync(int itemId, int quantity)
        {
            var item = await _unitOfWork.Items.GetByIdAsync(itemId);
            if (item == null) return;

            item.Stock -= quantity;
            if (item.Stock < 0)
                item.Stock = 0;

            _unitOfWork.Items.Update(item);
            await _unitOfWork.SaveAsync();
        }
    }
}
