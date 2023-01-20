﻿using FileServer.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace FileServer.DataAccess.DbContexts;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}
	public virtual DbSet<User> Users { get; set; } = default!;
	public virtual DbSet<Domain.Entities.File> Files { get; set; } = default!;
}
