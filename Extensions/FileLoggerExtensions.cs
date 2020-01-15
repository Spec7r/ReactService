using Microsoft.Extensions.Logging;
using ReactService.Logger;

namespace ReactService.Extensions
{
	public static class FileLoggerExtensions
	{
		 public static ILoggerFactory AddFile(this ILoggerFactory loggerFactory, string filePath)
		{
			loggerFactory?.AddProvider(new FileLoggerProvider(filePath));
			return loggerFactory;
		}
	}
}
