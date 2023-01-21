using System;
using System.Collections.Generic;

namespace FileServer.Domain.Entities;

public class User : BaseEntity
{
	public string Name { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public double Traffic { get; set; }
	public DateTime LastUpdate { get; set; }
	public bool EmailVerified { get; set; }
	public IEnumerable<File> Files { get; set; } = default!;
}
