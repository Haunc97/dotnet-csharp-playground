using System.Runtime.CompilerServices;
using System.Text;

namespace InterpolatedStringHandlerDemo;

/// <summary>
/// Custom interpolated string handler used by Logger.
/// Demonstrates execution-time control and diagnostic output.
/// </summary>
[InterpolatedStringHandler]
public ref struct LogInterpolatedStringHandler
{
    private readonly StringBuilder? _builder;
    private readonly bool _shouldLog;

    public LogInterpolatedStringHandler(
        int literalLength,
        int formattedCount,
        Logger logger,
        LogLevel level)
    {
        Console.WriteLine(
            $"\tHandler ctor called — literalLength={literalLength}, formattedCount={formattedCount}");

        _shouldLog = level <= logger.MinimumLevel;

        if (_shouldLog)
        {
            _builder = new StringBuilder(literalLength);
            Console.WriteLine("\tLogging ENABLED — building string");
        }
        else
        {
            _builder = null!;
            Console.WriteLine("\tLogging DISABLED — skipping work");
        }
    }

    public void AppendLiteral(string s)
    {
        Console.WriteLine($"\tAppendLiteral(\"{s}\")");

        if (_shouldLog)
            _builder!.Append(s);
    }

    public void AppendFormatted<T>(T value)
    {
        Console.WriteLine($"\tAppendFormatted({value}) type={typeof(T)}");

        if (_shouldLog)
            _builder!.Append(value?.ToString());
    }

    internal string GetFormattedText() => _shouldLog ? _builder!.ToString() : string.Empty;
}