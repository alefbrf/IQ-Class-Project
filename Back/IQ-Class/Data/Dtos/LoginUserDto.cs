using System.ComponentModel.DataAnnotations;

namespace IQ_Class.Data.Dtos
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Email é obrigatório!")]
        public string email { get; set; }
        [Required(ErrorMessage = "Senha é obrigatório!")]
        public string password { get; set; }
    }
}
