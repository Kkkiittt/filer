using System.Collections.Generic;
using System.Threading.Tasks;

using FileServer.Services.Models.Dtos.Files;
using FileServer.Services.Models.ViewModels.Files;

namespace FileServer.Services.Interfaces;

public interface IFileService
{
	public Task<bool> CreateAsync(FileCreateDto dto);
	public Task<bool> AddAsync(FileAddDto dto);
	public Task<bool> DeleteAsync(long id);
	public Task<IEnumerable<FileBaseViewModel>> GetAllAsync();
	public Task<FileViewModel> GetAsync(long id);
	public Task<byte[]> GetPartAsync(long id, int part);
}
