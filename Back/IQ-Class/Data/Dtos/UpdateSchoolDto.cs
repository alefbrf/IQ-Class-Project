using System.ComponentModel.DataAnnotations;

namespace IQ_Class.Data.Dtos
{
    public class UpdateSchoolDto
    {
        public string? name { get; set; }
        public string logo { get; set; } = String.Empty;
        public string? address { get; set; }
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Somente números")]
        [Range(9999999, 999999999999999, ErrorMessage = "Formato não aceito")]
        public int? phone { get; set; }
        public DateTime? dt_updated { get; set; } = DateTime.Now;
    }
}
