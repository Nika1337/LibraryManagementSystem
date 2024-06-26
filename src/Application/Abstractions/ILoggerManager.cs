

namespace Nika1337.Library.Application.Abstractions;

/// <summary>
/// This type eliminates the need to depend directly on the ASP.NET Core logging types.
/// </summary>
public interface ILoggerManager
{
    void LogInfo(string message);
    void LogWarn(string message);
    void LogDebug(string message);
    void LogError(string message);
}