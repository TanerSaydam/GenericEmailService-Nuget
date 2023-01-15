using System.Net.Mail;

namespace GenericEmailService
{
    public sealed class SendEmailModel
    {
        public SendEmailModel()
        {

        }
        public SendEmailModel(List<string> emails, string email, string password,string subject, string body, string smtp, bool html,bool ssl, int port, List<Attachment>? attachments)
        {
            Emails = emails;
            Email = email;
            Subject = subject;
            Body = body;
            Html = html;
            Smtp = smtp;
            Password = password;
            SSL = ssl;
            Port = port;
            Attachments = attachments;
        }

        public List<string> Emails { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool Html { get; set; }
        public string Smtp { get; set; }
        public string Password { get; set; }
        public bool SSL { get; set; }
        public int Port { get; set; }
        public List<Attachment>? Attachments { get; set; }
    }   
}
