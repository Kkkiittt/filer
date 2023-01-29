using FileServer.Domain.Entities;

namespace FileServer.Services.Interfaces.Common;

public interface IAuthService
{
	public string GenerateToken(User user);
}
