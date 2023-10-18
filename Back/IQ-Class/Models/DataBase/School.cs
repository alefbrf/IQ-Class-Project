namespace IQ_Class.Models
{
    public class School
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public string logo { get; set; } = String.Empty;
        public string? address { get; set; }
        public int? phone { get; set; }
        public DateTime dt_created { get; set; } = DateTime.Now;
        public DateTime? dt_updated { get; set; }
        public virtual ICollection<SchoolClass> school_class { get; set; }
        public virtual ICollection<User> users { get; set; }
    }
}
