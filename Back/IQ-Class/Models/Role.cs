namespace IQ_Class.Models
{
    public class Role
    {
        public int id { get; set; }
        public string role { get; set; }
        public virtual ICollection<UserRole> user_role { get; set; }
    }
}
