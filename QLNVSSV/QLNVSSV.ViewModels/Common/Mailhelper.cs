using System;
using System.Net;
using System.Net.Mail;

namespace QLNVSSV.Models.Common
{
    public class Mailhelper
    {
        public static void SendMail(string toEmailAddress, string subject, string content)
        {

            var fromEmailAddress = "chijiwooon@gmail.com";
            var fromEmailDisplayName = "Coong ty SSV";
            var fromEmailPassword = "anhphong1";
            var smtpHost = "smtp.gmail.com";
            var smtpPort = "587";

            bool enabledSsl = true;

            string body = content;
            MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAddress));
            message.Subject = subject;
            //message.IsBodyHtml = true;
            message.Body = body;

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = enabledSsl;
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(message);
        }
    }
}
