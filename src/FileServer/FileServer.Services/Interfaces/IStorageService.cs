using System.Threading.Tasks;

namespace FileServer.Services.Interfaces;

public interface IStorageService
{
	public bool CreateAsync(string name);
	public bool DeleteAsync(string name);
	public Task<bool> AddAsync(string name, byte[] data);
	public Task<int> DivideAsync(string name);
	public Task<byte[]> GetPartAsync(string name, int part);
}
