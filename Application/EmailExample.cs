using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class EmailExample
    {
        private static void Main()
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("E7c671MXQP-G0O32kb8IgA.ggmpnvloPaOqnu9svn4w0-QxFWFe5z6ar5gj0HwxWN0");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("sandra.ramosm@opitech.com.co", "Task Manager");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("andresfelipem.91@hotmail.com", "Apreciad@");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
