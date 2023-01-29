using FileServer.Services.Interfaces.Common;

using Microsoft.AspNetCore.Http;

namespace FileServer.Services.Services.Common;

public class IdentityService : IIdentityService
{
	private readonly IHttpContextAccessor _context;

	public IdentityService(IHttpContextAccessor context)
	{
		_context = context;
	}

	public long? Id
	{
		get
		{
			var res = _context.HttpContext.User.FindFirst("Id");
			return res is not null ? long.Parse(res.Value) : null;
		}
	}

	public IHttpContextAccessor Context => _context;
}
