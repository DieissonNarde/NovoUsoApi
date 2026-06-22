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
        private readonly IAuthenticate _authenticate;
        public UserController(IUserService userService, IAuthenticate authenticate)
        {
            _userService = userService;
            _authenticate = authenticate;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserPostDTO userPostDTO)
        {
            var user = await _userService.AddAsync(userPostDTO);
            var token = _authenticate.GenerateToken(user.Id, user.Email.ToLower());
            return Ok(new { Name = user.Name, Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetTokenUser(UserLoginDTO userLoginDTO)
        {
            var user = await _authenticate.GetUserByEmail(userLoginDTO.Email);
            if (user == null)
                return BadRequest(new { message = "Usuário ou senha inválidos." });
            
            var userValid = await _authenticate.AuthenticateAsync(userLoginDTO.Email, userLoginDTO.Password);
            if (!userValid)
                return BadRequest(new { message = "Usuário ou senha inválidos." });

            var token = _authenticate.GenerateToken(user.Id, user.Email.ToLower());
            return Ok(new { Name = user.Name, Token = token });
        }
    }
}