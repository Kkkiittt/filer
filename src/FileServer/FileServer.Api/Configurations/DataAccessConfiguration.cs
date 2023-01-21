using FileServer.DataAccess.DbContexts;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileServer.Api.Configurations;

public static class DataAccessConfiguration
{
	public static void ConfigureDataAccess(this WebApplicationBuilder builder)
	{
		string connectionString = builder.Configuration.GetConnectionString("ElephantSQL")!;
		builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
	}
}
