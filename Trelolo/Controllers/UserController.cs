using BLL.Interfaces;
using BLLM = BLL.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trelolo.Models.User;

namespace Trelolo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            Console.WriteLine("Salut");
            return Ok(_userService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_userService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create(NewUser user)
        {
            if (!ModelState.IsValid) return BadRequest();

            _userService.Create(new BLLM.NewUser
            {
                Email = user.Email,
                Password = user.Password,
            });

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(NewUser user)
        {
            return Ok();
        }
    }
}
