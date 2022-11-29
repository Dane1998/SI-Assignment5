using Customer.Repo;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Customer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var result = await _userRepo.GetUserById(userId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var result = await _userRepo.GetUserByEmail(email);
            return Ok(result);
        }
    }
}

