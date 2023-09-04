using System.Net;
using System.Net.Mail;

namespace PriceMonitor
{
    public interface IMailService
    {
        void SendEmail(string recommendation, string asset, decimal price);
    }

    public class MailService : IMailService
    {
        private readonly SmtpClient smtpClient;
        private readonly string senderEmail;
        private readonly string targetEmail;

        public MailService()
        {
            string smtpServer = Environment.GetEnvironmentVariable("SMTP_SERVER")
                                ?? throw new ArgumentNullException("SMTP_SERVER environment variable is not set");
            int smtpPort = int.TryParse(Environment.GetEnvironmentVariable("SMTP_PORT"), out int port)
                           ? port
                           : throw new ArgumentNullException("SMTP_PORT environment variable is not set or is not a valid integer");
            this.senderEmail = Environment.GetEnvironmentVariable("SENDER_EMAIL")
                               ?? throw new ArgumentNullException("SENDER_EMAIL environment variable is not set");
            this.targetEmail = Environment.GetEnvironmentVariable("TARGET_EMAIL")
                               ?? throw new ArgumentNullException("TARGET_EMAIL environment variable is not set");
            string senderPassword = Environment.GetEnvironmentVariable("SENDER_PASSWORD")
                                    ?? throw new ArgumentNullException("SENDER_PASSWORD environment variable is not set");

            this.smtpClient = new SmtpClient(smtpServer, smtpPort)
            {
                Credentials = new NetworkCredential(this.senderEmail, senderPassword),
                EnableSsl = true,
            };
        }

        public void SendEmail(string recommendation, string asset, decimal price)
        {
            this.smtpClient.Send(this.senderEmail, this.targetEmail,
                $"Stock Alert: {recommendation.ToUpper()} {asset}",
                $"The price for {asset} is now {price}. It is recommended to {recommendation}.");
        }
    }

}