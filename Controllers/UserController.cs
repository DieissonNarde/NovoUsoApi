using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovoUsoApi.DTOs.User;
using NovoUsoApi.Interfaces.Account;
using NovoUsoApi.Interfaces.Services;

namespace NovoUsoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticate _authenticateService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserPostDTO userPostDTO)
        {
            var user = await _userService.AddAsync(userPostDTO);
            var token = _authenticateService.GenerateToken(user.Id, user.Email.ToLower());
            return Ok(new { Name = user.Name, Token = token });
        }
    }
}