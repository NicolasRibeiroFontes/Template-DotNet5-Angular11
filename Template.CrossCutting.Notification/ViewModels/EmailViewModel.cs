using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace Template.CrossCutting.Notification.ViewModels
{
	public class EmailViewModel
	{
		public List<MailboxAddress> Recipients { get; set; }
		public string Subject { get; set; }
		public string Code { get; set; }

		public EmailViewModel(IEnumerable<string> to, string subject, string code)
		{
			Recipients = new List<MailboxAddress>();

			Recipients.AddRange(to.Select(x => new MailboxAddress("", x)));

			Subject = subject;
			Code = code;
		}
	}
}
