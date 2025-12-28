using InterpolatedStringHandlerDemo;

var logger = new Logger { MinimumLevel = LogLevel.Information };

Console.WriteLine("Log at Trace (will NOT print body):");

logger.LogMessage(LogLevel.Trace, $"Trace log with value = {42}");

Console.WriteLine();

Console.WriteLine("Log at Error (will execute handler):");
logger.LogMessage(LogLevel.Error,  $"An error occurred at {DateTime.Now}");