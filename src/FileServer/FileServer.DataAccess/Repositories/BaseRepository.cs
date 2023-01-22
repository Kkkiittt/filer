using FileServer.DataAccess.DbContexts;

namespace FileServer.DataAccess.Repositories;

public class BaseRepository
{
	protected AppDbContext _dbContext { get; }

	public BaseRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}
}
