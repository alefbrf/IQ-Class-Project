namespace IQ_Class.Models
{
    public class School
    {
        public int Id { get; set; }
        public string name { get; set; }
        public virtual ICollection<SchoolClass> school_class { get; set; }
        public virtual ICollection<User> users { get; set; }
    }
}
