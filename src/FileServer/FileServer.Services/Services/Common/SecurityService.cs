using System;
using System.Security.Cryptography;
using System.Text;

using FileServer.Services.Interfaces.Common;

namespace FileServer.Services.Services.Common;

public class SecurityService : ISecurityService
{
	private readonly SHA256 _engine;

	public SecurityService()
	{
		_engine = SHA256.Create();
	}
	public string Hash(string s, string salt)
	{
		return ComputeHash(s, salt);
	}

	private string ComputeHash(string s, string salt)
	{
		byte[] inBytes = Encoding.UTF8.GetBytes(s + salt);
		byte[] hash = _engine.ComputeHash(inBytes);
		return Convert.ToBase64String(hash);
	}

	public bool Verify(string hash, string pasw, string salt)
	{
		return hash == ComputeHash(pasw, salt);
	}
}
