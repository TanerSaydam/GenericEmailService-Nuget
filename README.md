# Dependency

This library was created by .Net 7.0

## Install

```bash
dotnet add package GenericEmailService --version 1.0.0
```

## Use

```CSharp
SendEmailModel sendEmailModel = new(
    List<string> emails, 
    string email, 
    string password,
    string subject, 
    string body, 
    string smtp, 
    bool html,
    bool ssl, 
    int port, 
    List<Attachment>? attachments
)
```

```CSharp
await EmailService.SendEmailAsync(sendEmailModel);
```

## Methods

This library have one methods and one class.

invoke
```Csharp
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
```

```Csharp
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
```