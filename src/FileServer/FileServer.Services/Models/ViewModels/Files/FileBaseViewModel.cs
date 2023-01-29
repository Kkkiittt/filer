using FileServer.Domain.Entities;

namespace FileServer.Services.Models.ViewModels.Files;

public class FileBaseViewModel : BaseEntity
{
	public string Name { get; set; } = string.Empty;
	public double Size { get; set; }
	public int Parts { get; set; }
}
