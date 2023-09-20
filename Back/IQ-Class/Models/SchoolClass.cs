namespace IQ_Class.Models
{
    public class SchoolClass
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<UserClass> users_class { get; set; }
        public int schoolid { get; set; }
        public virtual School school { get; set; }

    }
}
