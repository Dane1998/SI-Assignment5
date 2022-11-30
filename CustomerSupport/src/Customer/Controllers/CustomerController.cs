using Customer.Repo;
using Customer.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Shared;

namespace Customer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IKafkaProducerService _kafkaProducerService;

        public CustomerController(ICustomerRepo customerRepo, IKafkaProducerService kafkaProducerService)
        {
            _customerRepo = customerRepo;
            _kafkaProducerService = kafkaProducerService;
        }

        [HttpPost("review")]
        public async Task<bool> CreateFeedback([FromBody] ReviewDTO reviewDto)
        {
            return await _kafkaProducerService.SendReviewRequest("create_review", JsonConvert.SerializeObject(reviewDto));
        }

        [HttpGet("byId")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            var result = await _customerRepo.GetCustomerById(customerId);
            return Ok(result);
        }

        [HttpGet("byEmail")]
        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            var result = await _customerRepo.GetCustomerByEmail(email);
            return Ok(result);
        }

    }
}
