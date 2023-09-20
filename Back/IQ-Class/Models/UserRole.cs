namespace IQ_Class.Models
{
    public class UserRole
    {
        public int id { get; set; }
        public int userid { get; set; }
        public virtual User user { get; set; }
        public int roleid { get; set; }
        public virtual Role role { get; set; }
    }
}
