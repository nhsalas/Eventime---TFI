using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVICIOS.Email.Dominio;
using System.Net.Mail;
using System.Net;

namespace SERVICIOS.Email.DAL
{
    public class MailService
    {
        public string Email { get; set; }
        public string Mensaje { get; set; }
        public void EnviarMail(string mensaje, string email)
        {
            var fromAddress = new MailAddress(ApplicationSettings.Current.UsernameSMTP, "Sistema - Eventime TFI");
            var toAddress = new MailAddress(email, "To Name");
            string fromPassword = ApplicationSettings.Current.PasswordSMTP;
            const string subject = "Notificacion";
            string body = mensaje.Trim();

            Mensaje = mensaje;
            Email = email;

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
                smtp.Send(message);
            }
        }
    }
}
