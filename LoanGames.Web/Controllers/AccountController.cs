using LoanGames.Application.InputModels;
using LoanGames.Application.Interfaces;
using LoanGames.Application.ViewModels;
using LoanGames.Web.Helpers;
using LoanGames.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoanGames.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserAppService _userService;

        public AccountController(IUserAppService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(LoginInputModel model)
        {
            var user =  await _userService.Authenticate(model);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var token = TokenService.GenerateToken(user);
            var response = new AuthenticateResponse(user, token);
            return Ok(response);
        }
               
    }
}
