using System.Collections.Generic;
using System.Threading.Tasks;

using FileServer.Services.Models.Dtos.Files;
using FileServer.Services.Models.ViewModels.Files;

namespace FileServer.Services.Interfaces;

public interface IFileService
{
	public Task<int> CreateAsync(FileCreateDto dto);
	public Task<bool> AddAsync(int id, byte[] data);
	public Task<bool> GetPartAsync(int id, int part);
	public Task<bool> DeleteAsync(int id);
	public Task<IEnumerable<FileBaseViewModel>> GetAsync();
	public Task<int> GetAsync(int id);
}
