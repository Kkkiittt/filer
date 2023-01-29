using System.IO;
using System.Threading.Tasks;

using FileServer.DataAccess.Interfaces;

using Microsoft.AspNetCore.Hosting;

namespace FileServer.DataAccess.Repositories;

public class StorageRepository : IStorageRepository
{
	private readonly string _storagePath;
	private readonly int _capacity;

	public StorageRepository(IWebHostEnvironment environment)
	{
		_storagePath = environment.WebRootPath;
	}
	public async Task<bool> AddAsync(string name, byte[] value)
	{
		string path = Path.Combine(_storagePath, name);
		FileStream file = new FileStream(path, FileMode.Append);
		await file.WriteAsync(value, 0, value.Length);
		file.Close();
		return true;
	}

	public bool Create(string name)
	{
		string path = Path.Combine(_storagePath, name);
		File.Create(path);
		return true;
	}

	public bool Delete(string name)
	{
		string path = Path.Combine(_storagePath, name);
		File.Delete(path);
		return true;
	}

	public async Task<int> DivideFileAsync(string name)
	{
		string path = Path.Combine(_storagePath, name);
		Directory.CreateDirectory(path);
		byte[] buffer = new byte[_capacity];
		FileStream file = File.OpenRead(path);
		int parts;
		for(parts = 1; await file.ReadAsync(buffer, 0, _capacity) > 0; parts++)
		{
			string partPath = Path.Combine(path, parts.ToString() + ".txt");
			await File.WriteAllBytesAsync(partPath, buffer);
		}
		return parts;
	}

	public async Task<byte[]> GetPartAsync(string name, int part)
	{
		string path = Path.Combine(_storagePath, name, part + ".txt");
		return await File.ReadAllBytesAsync(path);
	}
}
