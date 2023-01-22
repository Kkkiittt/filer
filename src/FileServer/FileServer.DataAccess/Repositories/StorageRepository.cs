using System.IO;
using System.Threading.Tasks;

using FileServer.DataAccess.Interfaces;

using Microsoft.AspNetCore.Hosting;

namespace FileServer.DataAccess.Repositories;

public class StorageRepository : IStorageRepository
{
	private readonly string _storagePath;
	public StorageRepository(IWebHostEnvironment environment)
	{
		_storagePath = environment.ContentRootPath;
	}
	public async Task<bool> AddAsync(string name, byte[] value)
	{
		string path = Path.Combine(_storagePath, name);
		FileStream file = new FileStream(path, FileMode.Append);
		await file.WriteAsync(value, 0, value.Length);
		file.Close();
		return true;
	}

	public bool CreateAsync(string name)
	{
		string path = Path.Combine(_storagePath, name);
		File.Create(path);
		return true;
	}

	public bool DeleteAsync(string name)
	{
		string path = Path.Combine(_storagePath, name);
		File.Delete(path);
		return true;
	}
}
