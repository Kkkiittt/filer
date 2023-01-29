using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using FileServer.Domain.Entities;
using FileServer.Services.Helpers;
using FileServer.Services.Interfaces.Common;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FileServer.Services.Services.Common;

public class AuthService : IAuthService
{
	public readonly IConfiguration _config;

	public AuthService(IConfiguration config)
	{
		_config = config.GetSection("Jwt");
	}

	public string GenerateToken(User user)
	{
		Claim[] claims = new Claim[]
		{
			new("Id", user.Id.ToString())
		};
		SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_config["SecretKey"]));
		SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);
		JwtSecurityToken tokenDescriptor = new(_config["Issuer"], _config["Audience"], claims, expires: TimeHelper.GetCurrentTime().AddDays(int.Parse(_config["Lifetime"])), signingCredentials: credentials);
		return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

	}
}
