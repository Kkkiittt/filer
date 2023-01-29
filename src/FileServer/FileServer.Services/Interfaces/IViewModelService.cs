using FileServer.Domain.Entities;
using FileServer.Services.Models.ViewModels.Files;
using FileServer.Services.Models.ViewModels.Users;

namespace FileServer.Services.Interfaces;

public interface IViewModelService
{
	public UserBaseViewModel ToBase(User entity);
	public UserViewModel To(User entity);
	public FileBaseViewModel ToBase(File entity);
}
