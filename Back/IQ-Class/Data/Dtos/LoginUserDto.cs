using System.ComponentModel.DataAnnotations;

namespace IQ_Class.Data.Dtos
{
    public class LoginUserDto
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
