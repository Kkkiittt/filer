using FileServer.DataAccess.DbContexts;

using Microsoft.EntityFrameworkCore;

namespace FilerServer.Api.Configurations;

public static class DataAccessConfiguration
{
	public static void ConfigureDataAcces(this WebApplicationBuilder builder)
	{
		string connectionString = builder.Configuration.GetConnectionString("ElephantSQL");
		builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));
	}
}
