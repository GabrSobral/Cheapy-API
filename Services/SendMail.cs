using System;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace Cheapy_API.Services
{
    public class SendMail
    {
        private string _email;
        private string _password;

        public SendMail(IConfiguration configuration){
            _email = configuration.GetValue<string>("MailCredentials:Email");
            _password = configuration.GetValue<string>("MailCredentials:Password");
        }

        public void Send(
            string to, 
            string subject,
            string htmlBody )
        {
            string from = _email;
            MailMessage message = new MailMessage(from, to);

            message.Subject = subject;
            message.Body = htmlBody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            NetworkCredential credentials = new NetworkCredential(_email, _password);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;
            
            client.Send(message);
        }
    }
}