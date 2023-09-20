using System.ComponentModel.DataAnnotations;

namespace IQ_Class.Data.Dtos
{
    public class ChangePasswordDto
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string verification_code { get; set; }

        [Required(ErrorMessage = "Senha obrigatório")]
        [StringLength(10, ErrorMessage = "Senha pequena")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Confirmação de senha incorreta.")]
        public string password_confirmation { get; set; }
    }
}
