using System.Threading.Tasks;

namespace FileServer.DataAccess.Interfaces;

public interface IStorageRepository
{
	public bool Create(string name);
	public Task<bool> AddAsync(string name, byte[] value);
	public bool Delete(string name);
	public Task<int> DivideFileAsync(string name);
	public Task<byte[]> GetPartAsync(string name, int part);
}
