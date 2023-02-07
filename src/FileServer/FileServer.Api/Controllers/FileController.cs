using System.Threading.Tasks;

using FileServer.Services.Interfaces;
using FileServer.Services.Models.Dtos.Files;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileServer.Api.Controllers;

[Route("files"), Authorize]
[ApiController]
public class FileController : ControllerBase
{
	private readonly IFileService _service;

	public FileController(IFileService service)
	{
		_service = service;
	}
	[HttpPost]
	public async Task<IActionResult> CreateAsync(FileCreateDto dto)
	{
		return Ok(await _service.CreateAsync(dto));
	}
	[HttpPost("add")]
	public async Task<IActionResult> AddAsync(FileAddDto dto)
	{
		return Ok(await _service.AddAsync(dto));
	}
	[HttpDelete]
	public async Task<IActionResult> DeleteAsync([FromQuery] long id)
	{
		return Ok(await _service.DeleteAsync(id));
	}
	[HttpGet]
	public async Task<IActionResult> GetAsync()
	{
		return Ok(await _service.GetAllAsync());
	}
	[HttpGet("{id}")]
	public async Task<IActionResult> GetAsync(long id)
	{
		return Ok(await _service.GetAsync(id));
	}
	[HttpGet("part")]
	public async Task<IActionResult> GetPartAsync([FromQuery] long id, [FromQuery] int part)
	{
		return Ok(await _service.GetPartAsync(id, part));
	}
}
