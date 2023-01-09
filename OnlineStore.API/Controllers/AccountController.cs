using Microsoft.AspNetCore.Mvc;
using OnlineStore.Service.DTOs;
using OnlineStore.Service.Services.AccountService;

namespace OnlineStore.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]

        public ActionResult RegisterUser(RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok("Success");
        }

        [HttpPost("login")]
        public ActionResult Login(LoginUserDto dto)
        {
            string token = _accountService.GenerateJwt(dto);
            
            var user = new UserDto
            {
                Email = dto.Email,
                Token = token
            };
            return Ok(user);

        }
    }
}
