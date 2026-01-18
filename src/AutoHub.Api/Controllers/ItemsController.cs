using AutoHub.Application.Services;
using AutoHub.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutoHub.Api.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _service;

        public ItemsController(ItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            await _service.CreateAsync(item);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Item item)
        {
            await _service.UpdateAsync(item);
            return Ok();
        }

        [HttpPost("{id}/stock-in/{quantity}")]
        public async Task<IActionResult> StockIn(int id, int quantity)
        {
            await _service.IncreaseStockAsync(id, quantity);
            return Ok();
        }
    }
}
