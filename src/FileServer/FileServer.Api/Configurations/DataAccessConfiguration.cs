using FileServer.DataAccess.DbContexts;
using FileServer.DataAccess.Interfaces;
using FileServer.DataAccess.Repositories;
using FileServer.Services.Interfaces;

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
		builder.Services.AddScoped<IFileRepository, FileRepository>();
		builder.Services.AddScoped<IUserRepository, UserRepository>();
		builder.Services.AddScoped<IStorageService, StorageRepository>();
	}
}
