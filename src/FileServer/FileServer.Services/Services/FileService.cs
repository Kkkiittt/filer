using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FileServer.DataAccess.Interfaces;
using FileServer.Domain.Entities;
using FileServer.Services.Interfaces;
using FileServer.Services.Interfaces.Common;
using FileServer.Services.Models.Dtos.Files;
using FileServer.Services.Models.ViewModels.Files;

using Microsoft.EntityFrameworkCore;

namespace FileServer.Services.Services;

public class FileService : IFileService
{
	private readonly IStorageService _storage;
	private readonly IFileRepository _repository;
	private readonly IIdentityService _identity;

	public FileService(IStorageService storage, IFileRepository repository, IIdentityService identity)
	{
		_storage = storage;
		_repository = repository;
		_identity = identity;
	}

	public async Task<bool> AddAsync(FileAddDto dto)
	{
		return await _storage.AddAsync(dto.Id.ToString() + ".gz", dto.Data);
	}

	public async Task<bool> CreateAsync(FileCreateDto dto)
	{
		File file = new File()
		{
			Size = dto.Size,
			Hash = dto.Hash,
			Name = dto.Name,
			UserId = _identity.Id is null ? throw new Exception("Unauthorized") : (long)_identity.Id
		};
		await _repository.AddAsync(file);
		return _storage.Create(file.Id.ToString() + ".gz");
	}

	public async Task<bool> DeleteAsync(long id)
	{
		await _repository.DeleteAsync(id);
		return _storage.Delete(id.ToString() + ".gz");
	}

	public async Task<IEnumerable<FileBaseViewModel>> GetAllAsync()
	{
		return await _repository.GetAll().Where(x => x.UserId == _identity.Id).Select(x => new FileBaseViewModel
		{
			Id = x.Id,
			Name = x.Name,
			Size = x.Size,
		}).ToListAsync();
	}

	public async Task<FileViewModel> GetAsync(long id)
	{

		File entity = await _repository.GetAsync(id);
		return new FileViewModel
		{
			Id = entity.Id,
			Name = entity.Name,
			Size = entity.Size,
			Parts = await _storage.DivideFileAsync(id.ToString() + ".gz")
		};
	}

	public async Task<byte[]> GetPartAsync(long id, int part)
	{
		return await _storage.GetPartAsync(id.ToString() + ".gz", part);
	}
}
