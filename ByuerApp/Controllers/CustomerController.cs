using ByuerApp.Domain.Entities;
using ByuerApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ByuerApp.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> customerRepository;

        public CustomerController(IRepository<Customer> customerRepository) 
        {
            this.customerRepository = customerRepository?? throw new ArgumentNullException(nameof(customerRepository));
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await this.customerRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {

            try
            {
                var result = await this.customerRepository.GetByIdAsync(Id);
                if (result == null)
                {
                    return BadRequest("такого покупателя не найдено");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> AddAsync(Customer customer)
        {
            try
            {
                await customerRepository.AddAsync(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Customer customer)
        {
            try
            {
                await this.customerRepository.UpdateAsync(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            try
            {
                await this.customerRepository.DeleteAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
