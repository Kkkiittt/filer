using System.Threading.Tasks;

namespace FileServer.Services.Interfaces;

public interface IStorageService
{
	public bool Create(string name);
	public Task<bool> AddAsync(string name, byte[] value);
	public bool Delete(string name);
	public Task<int> DivideFileAsync(string name);
	public Task<byte[]> GetPartAsync(string name, int part);
}
