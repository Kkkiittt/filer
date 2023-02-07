using System;
using System.Linq;
using System.Threading.Tasks;

using FileServer.DataAccess.Interfaces;
using FileServer.Domain.Entities;
using FileServer.Services.Interfaces;
using FileServer.Services.Interfaces.Common;
using FileServer.Services.Models.Dtos.Users;
using FileServer.Services.Models.ViewModels.Files;
using FileServer.Services.Models.ViewModels.Users;

using Microsoft.Extensions.Caching.Memory;

namespace FileServer.Services.Services;

public class UserService : IUserService
{
	private readonly IMemoryCache _cache;
	private readonly IUserRepository _repository;
	private readonly IIdentityService _identity;
	private readonly IEmailService _email;
	private readonly ISecurityService _security;
	private readonly IAuthService _auth;

	public UserService(IMemoryCache cache, IUserRepository repository, IIdentityService identity, IEmailService email, ISecurityService security, IAuthService auth)
	{
		_cache = cache;
		_repository = repository;
		_identity = identity;
		_email = email;
		_security = security;
		_auth = auth;
	}

	public async Task<bool> ConfirmAsync(EmailConfirmDto dto)
	{
		if(_cache.TryGetValue(dto.Email, out var code))
		{
			if(dto.Code == (int)code)
			{
				User user = await _repository.GetAsync(dto.Email);
				user.EmailVerified = true;
				return await _repository.UpdateAsync(user);
			}
			else
			{
				throw new Exception("Code incorrect");
			}
		}
		else
		{
			throw new Exception("Not found code");
		}
	}

	public async Task<bool> DeleteAsync()
	{
		long id = _identity.Id is null ? throw new Exception("Unauthorized") : (long)_identity.Id;
		return await _repository.DeleteAsync(id);
	}

	public async Task<UserViewModel> GetAsync()
	{
		long id = _identity.Id is null ? throw new Exception("Unauthorized") : (long)_identity.Id;
		User user = await _repository.GetAsync(id);
		return new UserViewModel()
		{
			Id = id,
			Email = user.Email,
			Files = user.Files.Select(file => new FileBaseViewModel()
			{
				Size = file.Size,
				Id = file.Id,
				Name = file.Name,
			}
			).ToList(),
			Name = user.Name,
			Traffic = user.Traffic,
		};
	}

	public async Task<UserBaseViewModel> GetBaseAsync()
	{
		long id = _identity.Id is null ? throw new Exception("Unauthorized") : (long)_identity.Id;
		User user = await _repository.GetAsync(id);
		return new UserBaseViewModel()
		{
			Email = user.Email,
			Id = id,
			Name = user.Name,
		};
	}

	public async Task<string> LoginAsync(UserLoginDto dto)
	{
		User user = await _repository.GetAsync(dto.Email);
		if(_security.Verify(user.Password, dto.Password, user.Email) && user.EmailVerified)
		{
			return _auth.GenerateToken(user);
		}
		throw new Exception("Password incorrect");
	}

	public async Task<bool> RegisterAsync(UserRegisterDto dto)
	{
		User user = new User()
		{
			Email = dto.Email,
			EmailVerified = false,
			LastUpdate = DateTime.UtcNow,
			Name = dto.Name,
			Traffic = 0,
		};
		user.Password = _security.Hash(dto.Password, dto.Email);
		await SendAsync(dto.Email);
		return await _repository.UpdateAsync(user);
	}

	public async Task<bool> SendAsync(string email)
	{
		int code = new Random().Next(999999, 1_000_000);
		_cache.Set(email, code);
		return await _email.SendAsync(email, code.ToString());
	}

	public Task<bool> SendAsync()
	{
		throw new NotImplementedException();
	}

	public async Task<bool> UpdateAsync(UserRegisterDto dto)
	{
		User user = new User()
		{
			Email = dto.Email,
			Name = dto.Name,
		};
		user.Password = _security.Hash(dto.Password, dto.Email);
		return await _repository.UpdateAsync(user);
	}
}
