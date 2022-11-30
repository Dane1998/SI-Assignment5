using Customer.Repo;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            var result = await _customerRepo.GetCustomerById(customerId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            var result = await _customerRepo.GetCustomerByEmail(email);
            return Ok(result);
        }
    }
}
