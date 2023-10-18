using IQ_Class.Data;
using IQ_Class.Data.Dtos;
using IQ_Class.Data.Enums;
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
        private EmailService _emailService;
        private SchoolService _schoolService;
        private TokenService _tokenService;

        public UserController(UserService userService, TokenService tokenService, EmailService emailService, SchoolService schoolService)
        {
            _userService = userService;
            _emailService = emailService;
            _schoolService = schoolService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody]CreateUserDto dto)
        {
            if (!dto.roleid.HasValue) {
                dto.roleid = ((int)EnumarationRole.Roles.ADMIN);
            }

            if (!dto.schoolid.HasValue)
            {
                var newSchool = _schoolService.Create();
                dto.schoolid = newSchool.Id;
            }

            var createdUser = _userService.Register(dto);

            if (createdUser.Result.Failure)
            {
                return BadRequest(createdUser.Result.Failure);
            }

            return Ok($"Usuário {dto.name} cadastrado!");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginUserDto dto)
        {
            var token = _userService.Authenticate(dto);

            if (token == null)
            {
                return BadRequest("Usuário ou senha incorreto!");
            }

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

        [HttpPost("delete-account")]
        [Authorize]
        public IActionResult Delete() 
        {
            var token = Request.Headers["Authorization"].ToString().Split(" ")[1];

            var decodedToken = _tokenService.DecodeToken(token);

            int id;

            if (!decodedToken.ContainsKey(nameof(id)))
            {
                return NotFound("Not Found User");
            }

            int.TryParse(decodedToken[nameof(id)], out id);

            var result = _userService.DeleteUser(id);

            if (result.Failure)
            {
                return BadRequest("Erro ao deletar usuário!");
            }

            return Ok(result.Message);
        }
    }
}
