using System.Runtime.CompilerServices;

namespace InterpolatedStringHandlerDemo;

public enum LogLevel
{
    Off,
    Critical,
    Error,
    Warning,
    Information,
    Trace
}

public class Logger
{
    // Only messages <= this level will be logged
    public LogLevel MinimumLevel { get; init; } = LogLevel.Warning;

    public void LogMessage(
        LogLevel level,
        [InterpolatedStringHandlerArgument("", "level")]
        LogInterpolatedStringHandler handler)
    {
        // If logging was disabled, handler skipped work
        if (level > MinimumLevel)
            return;

        Console.WriteLine(handler.GetFormattedText());
    }
}
