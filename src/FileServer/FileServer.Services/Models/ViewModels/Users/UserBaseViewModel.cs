using FileServer.Domain.Entities;

namespace FileServer.Services.Models.ViewModels.Users;

public class UserBaseViewModel : BaseEntity
{
	public string Name { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
}
