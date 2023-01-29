using System;

using FileServer.Domain.Constants;

namespace FileServer.Services.Helpers;

public static class TimeHelper
{
	public static DateTime GetCurrentTime()
	{
		return DateTime.UtcNow.AddHours(TimeConstants.TimeZone);
	}
}
