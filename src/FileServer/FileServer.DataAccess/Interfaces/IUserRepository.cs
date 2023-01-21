using System.Threading.Tasks;

using FileServer.Domain.Entities;

namespace FileServer.DataAccess.Interfaces;

public interface IUserRepository
{
	public Task<bool> AddAsync(User entity);
	public Task<bool> UpdateAsync(User entity);
	public Task<bool> DeleteAsync(long id);
	public Task<User> GetAsync(long id);
	public Task<User> GetAsync(string email);
}
