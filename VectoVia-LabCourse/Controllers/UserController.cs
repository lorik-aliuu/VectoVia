using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VectoVia_LabCourse.Models.Users.Services;
using VectoVia_LabCourse.Views;

namespace VectoVia_LabCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserServices _userService;

        public UserController(UserServices userServices)
        {
            _userService = userServices;
        }

        [HttpPost("add-user")]

        public IActionResult AddUser([FromBody]UserVM user)
        {
            _userService.AddUser(user);
            return Ok();
        }
    }
}
