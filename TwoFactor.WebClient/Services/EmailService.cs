using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace TwoFactor.WebClient.Services
{
    public class EmailService
    {
        public async Task Send(string toAddr, string subject, string body)
        {
            var fromAddress = new MailAddress("lycntech@gmail.com", "lycntech");
            var toAddress = new MailAddress(toAddr);
            const string fromPassword = "73e6220ea4";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                await smtp.SendMailAsync(message);
            }
        }
    }
}
