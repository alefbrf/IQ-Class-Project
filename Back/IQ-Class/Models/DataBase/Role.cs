namespace IQ_Class.Models
{
    public class Role
    {
        public int id { get; set; }
        public string role { get; set; }
        public virtual ICollection<User> users { get; set; }
    }
}
