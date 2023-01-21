using System.Linq;
using System.Threading.Tasks;

using FileServer.Domain.Entities;

namespace FileServer.DataAccess.Interfaces;

public interface IFileRepository
{
	public Task<bool> AddAsync(File entity);
	public Task<bool> DeleteAsync(long id);
	public Task<File> GetAsync(long id);
	public IQueryable<File> GetAll();
}
