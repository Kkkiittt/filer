using FileServer.Services.Interfaces;
using FileServer.Services.Interfaces.Common;
using FileServer.Services.Services;
using FileServer.Services.Services.Common;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FileServer.Api.Configurations;

public static class ServicesConfiguration
{
	public static void ConfireServices(this WebApplicationBuilder builder)
	{
		builder.Services.AddScoped<IAuthService, AuthService>();
		builder.Services.AddScoped<IEmailService, EmailService>();
		builder.Services.AddScoped<IIdentityService, IdentityService>();
		builder.Services.AddScoped<ISecurityService, SecurityService>();
		builder.Services.AddScoped<IFileService, FileService>();
		builder.Services.AddScoped<IStorageService, StorageService>();
		builder.Services.AddScoped<IUserService, UserService>();
	}
}
