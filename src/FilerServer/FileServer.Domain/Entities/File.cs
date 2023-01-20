namespace FileServer.Domain.Entities;

public class File : BaseEntity
{
	public long UserId { get; set; }
	public virtual User User { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Hash{ get; set; } = string.Empty;
}
