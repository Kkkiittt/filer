using System.Threading.Tasks;

namespace FileServer.DataAccess.Interfaces;

public interface IStorageRepository
{
	public bool CreateAsync(string name);
	public Task<bool> AddAsync(string name, byte[] value);
	public bool DeleteAsync(string name);
}
