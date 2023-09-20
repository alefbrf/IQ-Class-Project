using IQ_Class.Data.Dtos;
using IQ_Class.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IQ_Class.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        private TokenService _tokenService;
        private EmailService _emailService;

        public UserController(UserService userService, TokenService tokenService, EmailService emailService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _emailService = emailService;
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
            var user = _userService.RequestNewAcess(email);

            if (user == null)
            {
                return NotFound("Not found user");
            }

            var SendEmail = new EmailBaseDto();

            SendEmail.receiver_email = user.email;
            SendEmail.receiver_name = user.name;
            SendEmail.subject = "Código de verificação IqClass";
            SendEmail.verification_code = user.verification_code;

            _emailService.SendEmail(SendEmail);

            return Ok();
        }

        [HttpPost("change-password")]
        [AllowAnonymous]
        public IActionResult ChangePassword([FromBody] ChangePasswordDto dto)
        {
            var user = _userService.ChangePassword(dto);

            if(user == null)
            {
                return NotFound("Not Found User");
            }

            return Ok("Senha alterada com sucesso!");
        }
    }
}
