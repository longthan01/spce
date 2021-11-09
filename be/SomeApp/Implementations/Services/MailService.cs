using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using SomeApp.Abstractions.Services;
using SomeApp.Models;

namespace SomeApp.Implementations.Services
{
	public class MailService : IMailService
	{
		private readonly ISendGridClient _sendGridClient;
		private readonly ILogger _logger;

		public MailService(ISendGridClient sendGridClient, ILogger<MailService> logger)
		{
			_sendGridClient = sendGridClient;
			_logger = logger;
		}
		public async Task Send(MailRequest request)
		{
			var from = new EmailAddress("temp1.smalldragon@gmail.com", "Some App");
			var to = new EmailAddress(request.To, request.Username);
			var msg = new SendGridMessage
			{
				From = from,
				Subject = request.Subject
			};
			msg.AddContent(MimeType.Html, request.Content);
			msg.AddTo(to);
			var response = await _sendGridClient.SendEmailAsync(msg).ConfigureAwait(false);
			if (response.StatusCode != HttpStatusCode.Accepted)
			{
				_logger.LogError("Mail sending failed", response);
				throw new Exception("Mail sending failed");
			}
		}
	}
}