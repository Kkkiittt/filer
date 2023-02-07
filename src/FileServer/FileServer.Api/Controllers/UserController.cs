using System.Threading.Tasks;

using FileServer.Services.Interfaces;
using FileServer.Services.Models.Dtos.Users;
using FileServer.Services.Models.ViewModels.Users;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileServer.Api.Controllers;

[Route("users")]
[ApiController]
public class UserController : ControllerBase
{
	private readonly IUserService _service;

	public UserController(IUserService service)
	{
		_service = service;
	}
	[HttpPost("login"), AllowAnonymous]
	public async Task<IActionResult> LoginAsync(UserLoginDto dto)
	{
		return Ok(await _service.LoginAsync(dto));
	}
	[HttpPost("register"), AllowAnonymous]
	public async Task<IActionResult> RegisterAsync(UserRegisterDto dto)
	{
		return Ok(await _service.RegisterAsync(dto));
	}
	[HttpDelete, Authorize]
	public async Task<IActionResult> DeleteAsync()
	{
		return Ok(await _service.DeleteAsync());
	}
	[HttpPut, Authorize]
	public async Task<IActionResult> UpdateAsync(UserRegisterDto dto)
	{
		return Ok(await _service.UpdateAsync(dto));
	}
	[HttpPost("confirm"), AllowAnonymous]
	public async Task<IActionResult> ConfirmAsync(EmailConfirmDto dto)
	{
		return Ok(await _service.ConfirmAsync(dto));
	}
	[HttpGet("base"), Authorize]
	public async Task<IActionResult> GetBaseAsync()
	{
		return Ok(await _service.GetBaseAsync());
	}
	[HttpGet, Authorize]
	public async Task<IActionResult> GetAsync()
	{
		return Ok(await _service.GetAsync());
	}
}
