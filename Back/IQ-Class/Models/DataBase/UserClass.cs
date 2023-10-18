namespace IQ_Class.Models.DataBase
{
    public class UserClass
    {
        public int id { get; set; }
        public virtual User user { get; set; }
        public virtual SchoolClass school_class { get; set; }
    }
}
