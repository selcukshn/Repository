using Microsoft.AspNetCore.Mvc;
using Repository.Services.Interfaces;

namespace Repository.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(UserService.GetAll());
        }
    }
}