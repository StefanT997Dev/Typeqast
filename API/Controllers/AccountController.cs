using System.Threading.Tasks;
using API.DTOs;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // Although logging in and registering are use-cases
    // When it comes to authenticating the user it is not
    // part of our application logic but a part of the API
    // project (issuing tokens, authenticating tokens). Our
    // application layer should have no knowledge about Identity.

    // The reason I am manually integrating login functionality
    // instead and MVC project and automatically being given login
    // and register functionality is because I want to separate the frontend
    // completely from the backend so that this app may be integrated on 
    // different mediums, not it just being a web app. I will not be implementing
    // register functionality doe and will just seed the users to the database
    // because of practicality reasons
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> LogIn(LoginDto logindDto)
        {
            var user = await _userManager.FindByEmailAsync(logindDto.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, logindDto.Password, false);

            if (result.Succeeded)
            {
                return new UserDto
                {
                    DisplayName = user.DisplayName,
                    Token = _tokenService.CreateToken(user),
                    Username = user.UserName
                };
            }

            return Unauthorized();
        }
    }
}