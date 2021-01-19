using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.CrossCutting.Notification.Interfaces;
using Template.CrossCutting.Notification.ViewModels;

namespace Template.CrossCutting.Notification.Services
{
    public class EmailSender : IEmailSender
	{
		private readonly EmailConfiguration _emailConfig;

		public EmailSender(EmailConfiguration emailConfig)
		{
			_emailConfig = emailConfig;
		}

		private string GetMessage(string code)
		{
			return code switch
			{
				"ACCOUNT-CREATED" => "Welcome {0} <br/><br/> Your account has been created successfully.<br/>" +
	"Please, activate it in the link below: {1}<br/><br/><b>Template</b>",
				"FORGOT-PASSWORD" => "Hi {0} <br/><br/> The code to change the password is: <b>{1}</ b><br/><br/><b>Template</b>",
				"PASSWORD-CHANGED" => "Hi {0} <br/><br/> Your password has been changed successfully.<br/><br/><b> Template </b> ",
				_ => "",
			};
		}

		public void SendEmail(EmailViewModel message, IEnumerable<string> parameters)
		{
			var emailMessage = CreateEmailMessage(message, parameters);

			Send(emailMessage);
		}

		public async Task SendEmailAsync(EmailViewModel message, IEnumerable<string> parameters)
		{
			var mailMessage = CreateEmailMessage(message, parameters);

			await SendAsync(mailMessage);
		}

		private MimeMessage CreateEmailMessage(EmailViewModel message, IEnumerable<string> parameters)
		{
			var emailMessage = new MimeMessage();
			emailMessage.From.Add(new MailboxAddress("Template", _emailConfig.From));
			emailMessage.To.AddRange(message.Recipients);
			emailMessage.Subject = message.Subject;

			string bodyFormatted = string.Format(GetMessage(message.Code), parameters.Select(x => x.ToString()).ToArray());

			var bodyBuilder = new BodyBuilder { HtmlBody = bodyFormatted };

			emailMessage.Body = bodyBuilder.ToMessageBody();
			return emailMessage;
		}

		private void Send(MimeMessage mailMessage)
		{
			using var client = new SmtpClient();
			try
			{
				client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
				client.AuthenticationMechanisms.Remove("XOAUTH2");
				client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

				client.Send(mailMessage);
			}
			catch (Exception ex)
			{

			}
			finally
			{
				client.Disconnect(true);
				client.Dispose();
			}
		}

		private async Task SendAsync(MimeMessage mailMessage)
		{
			using var client = new SmtpClient();
			try
			{
				await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
				client.AuthenticationMechanisms.Remove("XOAUTH2");
				await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

				await client.SendAsync(mailMessage);
			}
			catch (Exception ex)
			{

			}
			finally
			{
				await client.DisconnectAsync(true);
				client.Dispose();
			}
		}
	}
}
