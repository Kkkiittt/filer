namespace FileServer.Services.Models.Dtos.Files;

public class FileCreateDto
{
	public string Name { get; set; } = string.Empty;
	public string Hash { get; set; } = string.Empty;
	public double Size { get; set; }
}
