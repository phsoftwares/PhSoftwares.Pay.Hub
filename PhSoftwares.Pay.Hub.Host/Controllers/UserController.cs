using Microsoft.AspNetCore.Mvc;
using PhSoftwares.Pay.Hub.Application.DTOs;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;
using PhSoftwares.Pay.Hub.Application.Services;
using PhSoftwares.Pay.Hub.Core.Account;
using PhSoftwares.Pay.Hub.Host.Models;

namespace PhSoftwares.Pay.Hub.Host.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IUserService _userService;

        public UserController(IAuthenticateService authenticateService, IUserService userService)
        {
            _authenticateService = authenticateService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Insert(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("User required.");
            }
            var emailAddressExists = await _authenticateService.UserExists(userDTO.EmailAddress);
            if (emailAddressExists)
            {
                return BadRequest("User exists.");
            }

            var user = await _userService.Insert(userDTO);
            if (user == null || user.Id == null)
            {
                return BadRequest("Error on insert user.");
            }

            var token = _authenticateService.GenerateToken(user.Id ?? Guid.Empty, user.EmailAddress);
            return new UserToken
            {
                Token = token
            };
        }
    }
}
