using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

using FileServer.Services.Interfaces.Common;

using Microsoft.Extensions.Configuration;

namespace FileServer.Services.Services.Common;

public class EmailService : IEmailService
{
	private readonly IConfiguration _config;

	public EmailService(IConfiguration config)
	{
		_config = config.GetSection("Email");
	}

	public async Task<bool> SendAsync(string email, string content)
	{
		MailAddress from = new(_config["Email"], "Filer");
		MailAddress to = new(email);
		MailMessage message = new(from, to);
		message.Subject = "Verification code for Filer";
		message.Body = $"<h2>{content}</h2>";
		message.IsBodyHtml = true;
		SmtpClient client = new(_config["Host"], int.Parse(_config["Port"]))
		{
			Credentials = new NetworkCredential(_config["Email"], _config["Password"])
		};
		await client.SendMailAsync(message);
		return true;
	}
}
