using Application.Interface;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.TaskManageraOpi;

namespace Application.Email
{
    public class SendGridEmail(ISendGridServices sendGridServices) : ISendGrid
    {
        private readonly ISendGridServices _sendGridServices = sendGridServices;

        public async Task Message(string body, string receives)
        {
            await _sendGridServices.SendEmail("sandra.ramosm@opitech.com.co", receives, "Ensayo de prueba", body, null);
        }
    }
}
