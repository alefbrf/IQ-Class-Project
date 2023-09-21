using IQ_Class.Data.Dtos;
using System.Net;
using System.Net.Mail;

namespace IQ_Class.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MailMessage CreateEmailMessage(EmailBaseDto dto)
        {
            string receiver = dto.receiver_email;
            string sender = _configuration["Email:UserApp"];
            string subject = dto.subject;
            string body = $"@Código de recuperação de conta: {dto.verification_code}";

            MailMessage message = new MailMessage(sender, receiver, subject, body);

            return message;
        }

        public void SendEmail(EmailBaseDto dto)
        {
            var message = CreateEmailMessage(dto);

            try
            {
                using (SmtpClient smtpClient = new SmtpClient())
                {

                    smtpClient.Credentials = new NetworkCredential(_configuration["Email:UserApp"], _configuration["Email:KeyApp"]);
                    smtpClient.Host = _configuration["Email:smtp"];
                    smtpClient.Port = int.Parse(_configuration["Email:port"]);
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(message);
                }
                    
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
