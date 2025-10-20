using ByuerApp.Domain.Entities;
using ByuerApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ByuerApp.Controllers
{
    [Route("api/v1/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IOrderServise orderServise;

        public OrderController(IRepository<Order> orderRepository, IOrderServise orderServise)
        {
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            this.orderServise = orderServise ?? throw new ArgumentNullException(nameof(orderServise));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await this.orderRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            return Ok(await this.orderRepository.GetByIdAsync(Id));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Order order)
        {
            if (order == null)
                return BadRequest("нет заказа...");
            else
            {
                await this.orderRepository.AddAsync(order);
                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Order order)
        {
                await this.orderRepository.UpdateAsync(order);
                return Ok();
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteAsync(Guid Id)
        {
                await this.orderRepository.DeleteAsync(Id);
                return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> IsOrderCreated(Guid Id)
        {
            await this.orderServise.IsOrderCreated(Id);
            return Ok();
        }
    }
}
