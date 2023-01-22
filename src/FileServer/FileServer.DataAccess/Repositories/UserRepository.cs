using System.Threading.Tasks;

using FileServer.DataAccess.DbContexts;
using FileServer.DataAccess.Interfaces;
using FileServer.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace FileServer.DataAccess.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
	public UserRepository(AppDbContext dbContext) : base(dbContext)
	{

	}

	public async Task<bool> AddAsync(User entity)
	{
		_dbContext.Users.Add(entity);
		return await _dbContext.SaveChangesAsync() > 0;
	}

	public async Task<bool> DeleteAsync(long id)
	{
		User user = await GetAsync(id);
		_dbContext.Users.Remove(user);
		return await _dbContext.SaveChangesAsync() > 0;
	}

	public async Task<User> GetAsync(long id)
	{
		return await _dbContext.Users.FindAsync(id);
	}

	public async Task<User> GetAsync(string email)
	{
		return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
	}

	public async Task<bool> UpdateAsync(User entity)
	{
		_dbContext.Users.Update(entity);
		return await _dbContext.SaveChangesAsync() > 0;
	}
}
