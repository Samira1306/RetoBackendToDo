using Application.TaskManageraOpi;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SendGridServices(string api): ISendGridServices
    {
        private readonly string _api = api;
        public async Task SendEmail(string trasnmitter, string receiver, string subject, string body, string html)
        {
            SendGridClient client = new(_api);
            EmailAddress from = new(trasnmitter);
            EmailAddress to = new EmailAddress(receiver);
            SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, subject,body, html);
            Response response = await client.SendEmailAsync(msg);
        }
       
    }
}
