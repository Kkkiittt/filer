using System.Threading.Tasks;

using FileServer.Services.Models.Dtos.Users;
using FileServer.Services.Models.ViewModels.Users;

namespace FileServer.Services.Interfaces;

public interface IUserService
{
	public Task<string> LoginAsync(UserLoginDto dto);
	public Task<bool> RegisterAsync(UserRegisterDto dto);
	public Task<bool> DeleteAsync();
	public Task<bool> UpdateAsync(UserRegisterDto dto);
	public Task<bool> ConfirmAsync(EmailConfirmDto dto);
	public Task<bool> SendAsync();
	public Task<UserBaseViewModel> GetBaseAsync();
	public Task<UserViewModel> GetAsync();
}
