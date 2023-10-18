namespace IQ_Class.Data.Dtos
{
    public class AuthenticatedUserDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password_hash { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime? last_acess { get; set; }
        public string verification_code { get; set; }
        public string role { get; set; }
    }
}
