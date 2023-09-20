using MailKit.Net.Smtp;
using MimeKit;
using IQ_Class.Data.Dtos;
using MailKit.Security;

namespace IQ_Class.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public MimeMessage CreateEmailMessage(EmailBaseDto dto)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("IqClass", _configuration["Email:UserApp"]));
            email.To.Add(new MailboxAddress(dto.receiver_name, dto.receiver_email));

            email.Subject = dto.subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"Código de recuperação de conta: {dto.verification_code}"
            };

            return email;
        }
        public void SendEmail(EmailBaseDto dto)
        {
            var email = CreateEmailMessage(dto);

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_configuration["Email:smtp"], int.Parse(_configuration["Email:port"]) , SecureSocketOptions.StartTls);

                smtp.Authenticate(_configuration["Email:UserApp"], _configuration["Email:KeyApp"]);

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}
