using System.Collections.Generic;
using System.Threading.Tasks;
using Template.CrossCutting.Notification.ViewModels;

namespace Template.CrossCutting.Notification.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(EmailViewModel message, IEnumerable<string> parameters);
        Task SendEmailAsync(EmailViewModel message, IEnumerable<string> parameters);
    }
}
