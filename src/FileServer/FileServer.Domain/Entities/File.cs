namespace FileServer.Domain.Entities;

public class File : BaseEntity
{
	public long UserId { get; set; }
	public User User { get; set; } = default!;
	public string Name { get; set; } = string.Empty;
	public double Size { get; set; }
	public string Hash { get; set; } = string.Empty;
}
