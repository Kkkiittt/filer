using System.IO;
using System.Threading.Tasks;

using FileServer.Services.Interfaces;

using Microsoft.AspNetCore.Hosting;

namespace FileServer.Services.Services;

public class StorageService : IStorageService
{
	private readonly string _storagePath;
	private readonly int _capacity = 10485760;

	public StorageService(IWebHostEnvironment environment)
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
		_ = File.Create(path);
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
		_ = Directory.CreateDirectory(path);
		byte[] buffer = new byte[_capacity];
		FileStream file = File.OpenRead(path);
		int parts;
		string partPath;
		for(parts = 1; await file.ReadAsync(buffer, 0, _capacity) > _capacity; parts++)
		{
			partPath = Path.Combine(path, parts.ToString() + ".txt");
			await File.WriteAllBytesAsync(partPath, buffer);
		}
		byte[] last = new byte[file.Length - file.Position];
		partPath = Path.Combine(path, parts.ToString() + ".txt");
		await file.ReadAsync(last, 0, last.Length);
		await File.WriteAllBytesAsync(partPath, last);
		return parts;
	}

	public async Task<byte[]> GetPartAsync(string name, int part)
	{
		string path = Path.Combine(_storagePath, name, part + ".txt");
		return await File.ReadAllBytesAsync(path);
	}
}
