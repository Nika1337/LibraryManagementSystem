
using Nika1337.Library.Application.Abstractions;
using NLog;


namespace Nika1337.Library.Infrastructure.Logging;

internal class NLogLoggerManager : ILoggerManager
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    public void LogInfo(string message) => logger.Info(message);

    public void LogWarn(string message) => logger.Warn(message);

    public void LogDebug(string message) => logger.Debug(message);
    public void LogError(string message) => logger.Error(message);
}
