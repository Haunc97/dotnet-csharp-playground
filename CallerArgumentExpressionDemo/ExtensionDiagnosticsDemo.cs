using System.Runtime.CompilerServices;

namespace CallerArgumentExpressionDemo;

public static class ExtensionDiagnosticsDemo
{
    /// <summary>
    /// Extension method that captures the original expression passed by caller.
    /// </summary>
    public static void EnsureHasAtLeast<T>(
        this IEnumerable<T> source,
        int minimum,
        [CallerArgumentExpression(nameof(source))] string? expression = null)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        if (minimum < 0)
            throw new ArgumentOutOfRangeException(nameof(minimum));

        // Enumerate only as far as needed
        if (source.Take(minimum).Count() < minimum)
        {
            throw new ArgumentException(
                $"Sequence does not contain enough elements: {expression}",
                nameof(source));
        }
    }

    /// <summary>
    /// Demo scenario showing diagnostics in extension methods.
    /// </summary>
    public static void Run()
    {
        var countries = new List<string>
        {
            "Vietnam", "Korea", "Japan", "China"
        };

        countries.EnsureHasAtLeast(1);   // OK

        // Uncomment to see diagnostic message:
        countries.EnsureHasAtLeast(10);
        //
        // Exception will show:
        //   "Sequence does not contain enough elements: countries"
    }
}
