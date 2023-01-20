namespace FileServer.Domain.Entities;

public class User : BaseEntity
{
	public string Name { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public string Salt { get; set; } = string.Empty;
	public long MegaBytes { get; set; }
	public virtual IEnumerable<File> Files { get; set; } = new List<File>();
}
