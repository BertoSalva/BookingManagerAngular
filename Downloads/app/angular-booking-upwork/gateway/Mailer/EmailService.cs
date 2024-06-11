using MailKit.Net.Smtp;
using MimeKit;

namespace gateway.Mailer
{
    public interface IEmailService
    {
        void SendEmail(string recipientAddress, string subject, string body);
        string GetTemplate(BookingRequest model, string status);
    }

    public class EmailService : IEmailService
    {
        // TODO: Update SMTP creds in .env file
        readonly string email = Environment.GetEnvironmentVariable("EMAIL_USER");
        readonly string password = Environment.GetEnvironmentVariable("EMAIL_PASS");
        readonly string smptp = Environment.GetEnvironmentVariable("EMAIL_SMPT");
        readonly string port = Environment.GetEnvironmentVariable("EMAIL_PORT");

        public void SendEmail(string recipientAddress, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Booking Confirmation", email));
            message.To.Add(new MailboxAddress("", recipientAddress));
            message.Subject = subject;
            var bodyBuilder = new BodyBuilder { HtmlBody = body };

            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();

            client.Connect(
                smptp,
                Convert.ToInt32(port),
                MailKit.Security.SecureSocketOptions.StartTls
            );
            client.Authenticate(email, password);
            client.Send(message);
            client.Disconnect(true);
        }

        public string GetTemplate(BookingRequest model, string status)
        {
            string confirmationTemplatePath = "Content/approval.html";
            string rejectionTemplatePath = "Content/rejection.html";

            var confirmationTemplate = File.ReadAllText(confirmationTemplatePath);
            var rejectionTemplate = File.ReadAllText(rejectionTemplatePath);

            if (status == "APPROVED")
            {
                string emailBody = confirmationTemplate
                    .Replace("[Parent]", model.Parent.ParentName)
                    .Replace("[Child]", model.Child.ChildName)
                    .Replace("[AppointmentDate]", model.PreferredDateTime.Date.ToLongDateString())
                    .Replace("[AppointmentTime]", model.PreferredDateTime.ToLongTimeString())
                    .Replace("[Psychologist]", model.Psychologist.PsychologistName)
                    .Replace("[Organization]", "ThereBook");

                return emailBody;
            }
            else
            {
                string emailBody = rejectionTemplate
                    .Replace("[Parent]", model.Parent.ParentName)
                    .Replace("[Child]", model.Child.ChildName)
                    .Replace("[AppointmentDate]", model.PreferredDateTime.Date.ToLongDateString())
                    .Replace("[AppointmentTime]", model.PreferredDateTime.ToLongTimeString())
                    .Replace("[Psychologist]", model.Psychologist.PsychologistName)
                    .Replace("[Organization]", "ThereBook");
                return emailBody;
            }
        }
    }
}
