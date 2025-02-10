using System;
using System.Net;
using System.Net.Mail;
using MimeKit;
using MailKit.Net.Smtp;
using System.Windows.Forms;

public class EmailHelper
{
    private string smtpServer = "smtp.gmail.com"; 
    private int smtpPort = 587;
    private string senderEmail = "your_email@gmail.com";
    private string senderPassword = "generated_gmail_app_password ";

    public bool SendEmail(string recipientEmail, string subject, string body, string attachmentPath)
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Industrial Reports", senderEmail));
            message.To.Add(new MailboxAddress("", recipientEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder { TextBody = body };
            if (!string.IsNullOrEmpty(attachmentPath))
            {
                bodyBuilder.Attachments.Add(attachmentPath);
            }

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                Console.WriteLine("Connecting to SMTP server...");
                client.Connect(smtpServer, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                Console.WriteLine("Connected successfully!");

                Console.WriteLine("Authenticating...");
                client.Authenticate(senderEmail, senderPassword);
                Console.WriteLine("Authentication successful!");

                Console.WriteLine("Sending email...");
                client.Send(message);
                Console.WriteLine("Email sent successfully!");

                client.Disconnect(true);
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Email sending failed: {ex.Message}");
            MessageBox.Show($"Email sending failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

}
