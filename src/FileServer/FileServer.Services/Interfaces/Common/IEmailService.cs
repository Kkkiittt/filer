using System.Threading.Tasks;

namespace FileServer.Services.Interfaces.Common;

public interface IEmailService
{
	public Task<bool> SendAsync(string email, string content);
}
