using System.Net;
using System.Net.Mail;

namespace GenericEmailService
{    
    public static class EmailService
    {        
        public static async Task SendEmailAsync(SendEmailModel sendEmailModel)
        {            
            using (MailMessage mail = new MailMessage())
            {                
                mail.From = new MailAddress(sendEmailModel.Email);
                foreach (var email in sendEmailModel.Emails)
                {
                    mail.To.Add(email);
                }
                mail.Subject = sendEmailModel.Subject;
                mail.Body = sendEmailModel.Body;
                mail.IsBodyHtml = sendEmailModel.Html;
                if(sendEmailModel.Attachments != null)
                {
                    foreach (var attachment in sendEmailModel.Attachments)
                    {
                        mail.Attachments.Add(attachment);
                    }
                }                
                using (SmtpClient smtp = new SmtpClient(sendEmailModel.Smtp))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(sendEmailModel.Email, sendEmailModel.Password);
                    smtp.EnableSsl = sendEmailModel.SSL;
                    smtp.Port = sendEmailModel.Port;
                    await smtp.SendMailAsync(mail);
                }
            }
        }
    }
}
