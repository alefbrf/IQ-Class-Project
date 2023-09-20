namespace IQ_Class.Data.Dtos
{
    public class EmailBaseDto
    {
        public string email { get; set; }
        public string receiver_name { get; set; }
        public string receiver_email { get; set; }
        public string subject { get; set; }
        public string verification_code { get; set; }
    }
}
