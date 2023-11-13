using System;
using System.Net;
using System.Net.Mail;
using System.Text;
 
namespace Logic
{
    public class EmailSender
    {
        public const string DISPLAY_NAME = "STOP: The Game!";
        public const string BODY = "Your validation code is: ";

        public bool SendValidationEmail(String toEmail, String affair, int validationCode)
        {
            bool result = true;
            SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587);

            try
            {
                MailMessage mailMessage = new MailMessage()
                {
                    From = new MailAddress(Properties.Settings.Default.Email, DISPLAY_NAME),
                    Subject = affair,
                    Body = $"{BODY} {validationCode}",
                    BodyEncoding = Encoding.UTF8,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(toEmail);

                smtpClient.Credentials = new NetworkCredential(Properties.Settings.Default.Email, Properties.Settings.Default.EmailPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
            }
            catch (SmtpException ex)
            {
                result = false;
            }
            finally
            {
                smtpClient.Dispose();
            }
            return result;
        }
    }
}
