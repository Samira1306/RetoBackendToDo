using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskManageraOpi
{
    public interface ISendGridServices
    {
        Task SendEmail(string trasnmitter, string receiver, string subject, string body, string html);
    }
}
