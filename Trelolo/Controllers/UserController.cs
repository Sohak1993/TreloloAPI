using BLL.Interfaces;
using BLLM = BLL.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trelolo.Models.User;
using Trelolo.Infrastructure;

namespace Trelolo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly TokenManager _tokenManager;

        public UserController(IUserService userService, TokenManager tokenManager)
        {
            this._userService = userService;
            this._tokenManager = tokenManager;
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

        [HttpPost("login")]
        public IActionResult Login(Login form)
        {
            BLLM.User u = _userService.Login(form.Email, form.Password);
            ConnectedUser cu = new ConnectedUser
            {
                Id = u.Id,
                Email = u.Email,
                Token = _tokenManager.GenerateToken(u)
            };

            return Ok(cu);
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
