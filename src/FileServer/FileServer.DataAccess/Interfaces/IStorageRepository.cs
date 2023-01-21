using System.Threading.Tasks;

namespace FileServer.DataAccess.Interfaces;

public interface IStorageRepository
{
	public Task<bool> CreateAsync(string name);
	public Task<bool> AddAsync(string name, byte[] value);
	public Task<bool> DeleteAsync(string name);
}
