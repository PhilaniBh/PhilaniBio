using MailKit.Net.Smtp;
using MimeKit;
using PhilaniBiography.Models;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Pkcs;
using PhilaniBiography.Helpers;



namespace PhilaniBiography.Helpers
{
    public class Mail
    {
        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }

        public Mail(IConfiguration configuration, ILogger logger)
        {
            Configuration = configuration;
            Logger = logger;
        }

        public async Task MailRFQ(List<string> receiver_email, string Comment, ContactForm request)
        {
            try
            {
                MimeMessage message = new MimeMessage();

                MailboxAddress from = new MailboxAddress("noreply_SupportPortal@bellequipment.com", "noreply_SupportPortal@bellequipment.com");
                message.From.Add(from);



                // Create recipient list
                InternetAddressList list = new InternetAddressList();
                foreach (var receiver in receiver_email)
                {
                    if (MailboxAddress.TryParse(receiver.Trim(), out MailboxAddress mailboxAddress))
                    {
                        list.Add(mailboxAddress);
                    }
                }

                message.To.AddRange(list);

                message.Subject = "New Inquiry from Website - " + request.Name;

                // Create email body
                string body = @"Please attend to below query:<br/>" +
                              "<br/>" +
                              "User: " + request.Name + "<br/>" +
                              "Email: " + request.Email + "<br/>" +
                              "Phone: " + request.Phone + "<br/>" +
                              "Message: " + request.Message + "<br/>" +
                              "Comment: " + Comment + "<br/>";

                BodyBuilder bodyBuilder = new BodyBuilder
                {
                    HtmlBody = MailTemplate.generateTemplate(body)
                };

              

                message.Body = bodyBuilder.ToMessageBody();

                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync("mail.bell.co.za", 25, MailKit.Security.SecureSocketOptions.StartTls);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (log, rethrow, etc.)
                Console.WriteLine(ex.Message);
            }
        }

        public bool SendAdminSupportRequestMail(string email,  ContactForm request)
        {
           

            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("noreply@bellequipment.com", "noreply@bellequipment.com");
            message.From.Add(from);

            InternetAddressList list = new InternetAddressList();
            string[] receivers = email.Split(',');

            foreach (var receiver in receivers)
            {
                list.Add(new MailboxAddress(receiver, receiver));
            }

            message.To.AddRange(list);

            message.Subject = "New Inquiry from Website - " + request.Name ;

            string body = @"Please attend to below query:<br/>" +
                          "<br/>" +
                          "User : " + request.Name + "<br/>" +
                          "Email : " + request.Email + "<br/>" +
                          "Phone Number: " + request.Phone + "<br/>" +                       
                          "Message : " + request.Message + "<br/>";

            BodyBuilder bodyBuilder = new BodyBuilder
            {
                HtmlBody = MailTemplate.generateTemplate(body)
            };


            message.Body = bodyBuilder.ToMessageBody();

            using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    client.Connect("mail.bell.co.za", 25, false);
                    client.Send(message);
                    client.Disconnect(true);
                    return true; // Email sent successfully
                }
                catch (Exception ex)
                {
                    Logger.LogError("Email send failed: " + ex.Message);
                    return false; // Email sending failed
                }
            }
        }

    }


}
