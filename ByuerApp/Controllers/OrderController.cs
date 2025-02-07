using ByuerApp.Domain.Entities;
using ByuerApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ByuerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> orderRepository;

        public OrderController(IRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await this.orderRepository.GetAllAsync());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {

            try
            {
                return Ok(await this.orderRepository.GetByIdAsync(Id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> AddAsync(Order order)
        {
            if (order == null)
                return BadRequest("нет заказа...");
            try
            {
                await this.orderRepository.AddAsync(order);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Order order)
        {
            try
            {
                await this.orderRepository.UpdateAsync(order);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteAsync(Guid Id)
        {
            try
            {
                await this.orderRepository.DeleteAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
