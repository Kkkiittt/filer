namespace FileServer.Services.Models.Dtos.Files;

public class FileAddDto
{
	public long Id { get; set; }
	public byte[] Data { get; set; } = new byte[0];
}
