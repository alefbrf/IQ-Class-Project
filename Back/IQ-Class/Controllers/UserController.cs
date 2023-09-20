using IQ_Class.Data.Dtos;
using IQ_Class.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IQ_Class.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        private TokenService _tokenService;

        public UserController(UserService userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("cadastro")]
        public IActionResult RegisterUser([FromBody]CreateUserDto dto)
        {
            _userService.Register(dto);

            return Ok("Usuário cadastrado");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginUserDto dto)
        {
            var token = _userService.Authenticate(dto);

            return Ok(token);
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult Teste() {
            return Ok("AAAbbsc"); 
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public IActionResult GetNewAcessToken([FromBody] string email)
        {
            var token = _userService.RequestNewAcess(email);
            return Ok(token);
        }

        [HttpPost("change-password")]
        [AllowAnonymous]
        public IActionResult ChangePassword([FromBody] ChangePasswordDto dto)
        {
            var token = Request.Headers["Authorization"].ToString().Split(" ")[1];

            var decodedToken = _tokenService.DecodeToken(token);
            int id;
            Guid guid;
            string email;

            if(!decodedToken.ContainsKey("id") || !decodedToken.ContainsKey("guid") || !decodedToken.TryGetValue("email", out email))
            {
                return NotFound("Not Found Token");
            }

            int.TryParse(decodedToken["id"], out id);
            Guid.TryParse(decodedToken["guid"], out guid);

            dto.id = id;
            dto.guid = guid;
            dto.email = email;

            var user = _userService.ChangePassword(dto);

            if(user == null)
            {
                return NotFound("Not Found User");
            }

            return Ok(user);
        }

        [HttpGet("email")]
        [AllowAnonymous]
        public IActionResult GetEmail() { }
    }
}
