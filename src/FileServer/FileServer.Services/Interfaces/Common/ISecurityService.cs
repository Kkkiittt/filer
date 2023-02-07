namespace FileServer.Services.Interfaces.Common;

public interface ISecurityService
{
	public string Hash(string s, string salt);
	public bool Verify(string hash, string pasw, string salt);
}
