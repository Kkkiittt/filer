using System.Collections.Generic;
using System.Linq;

using FileServer.Api.Configurations;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

builder.ConfigureDataAccess();
builder.ConfigureAuth();
builder.ConfireServices();
builder.Services.ConfigureSwaggerAuthorize();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
var lis = new List<int>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
