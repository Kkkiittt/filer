using System.Linq;
using System.Threading.Tasks;

using FileServer.DataAccess.DbContexts;
using FileServer.DataAccess.Interfaces;
using FileServer.Domain.Entities;

namespace FileServer.DataAccess.Repositories;

public class FileRepository : BaseRepository, IFileRepository
{
	public FileRepository(AppDbContext dbContext) : base(dbContext)
	{
	}

	public async Task<bool> AddAsync(File entity)
	{
		_dbContext.Files.Add(entity);
		return await _dbContext.SaveChangesAsync() > 0;
	}

	public async Task<bool> DeleteAsync(long id)
	{
		File entity = await GetAsync(id);
		_dbContext.Files.Remove(entity);
		return await _dbContext.SaveChangesAsync() > 0;
	}

	public IQueryable<File> GetAll()
	{
		return _dbContext.Files;
	}

	public async Task<File> GetAsync(long id)
	{
		return await _dbContext.Files.FindAsync(id);
	}
}
