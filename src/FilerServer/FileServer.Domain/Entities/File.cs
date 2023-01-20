namespace FileServer.Domain.Entities;

public class File : BaseEntity
{
	public int UserId { get; set; }
	public virtual User User { get; set; }
	public string Name { get; set; } = string.Empty;
}
