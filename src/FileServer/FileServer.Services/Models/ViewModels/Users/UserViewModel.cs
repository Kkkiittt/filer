using System.Collections.Generic;

using FileServer.Services.Models.ViewModels.Files;

namespace FileServer.Services.Models.ViewModels.Users;

public class UserViewModel : UserBaseViewModel
{
	public double Traffic { get; set; }
	public IList<FileBaseViewModel> Files { get; set; } = new List<FileBaseViewModel>();
}
