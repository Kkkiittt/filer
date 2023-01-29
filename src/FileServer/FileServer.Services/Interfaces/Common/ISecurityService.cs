namespace FileServer.Services.Interfaces.Common;

public interface ISecurityService
{
	public (string hash, string salt) Hash(string s);
	public bool Verify(string hash, string pasw, string salt);
}
