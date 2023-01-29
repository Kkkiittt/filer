namespace FileServer.Services.Models.Dtos.Users;

public class EmailConfirmDto
{
	public string Email { get; set; } = string.Empty;
	public int Code { get; set; }
}
