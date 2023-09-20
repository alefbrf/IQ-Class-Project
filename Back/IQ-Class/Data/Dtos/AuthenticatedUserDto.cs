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
        public Guid? guid { get; set; }
        public List<string> roles { get; set; }
    }
}
