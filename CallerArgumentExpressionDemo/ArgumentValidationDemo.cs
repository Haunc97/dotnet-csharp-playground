using System.Runtime.CompilerServices;

namespace CallerArgumentExpressionDemo;

public static class ArgumentValidationDemo
{
    /// <summary>
    /// Uses CallerArgumentExpression to capture the failing argument expression.
    /// </summary>
    private static void ValidateArgument(
        string parameterName,
        bool condition,
        [CallerArgumentExpression(nameof(condition))] string? expression = null)
    {
        if (!condition)
        {
            throw new ArgumentException(
                $"Argument failed validation: <{expression}>",
                parameterName);
        }
    }

    private static void Execute(Action action)
    {
        ValidateArgument(nameof(action), action is not null);
        action!();
    }

    /// <summary>
    /// Demo scenario showing improved diagnostics for argument validation.
    /// </summary>
    public static void Run()
    {
        var print = () => Console.WriteLine("Hello world!");
        Execute(print);

        // Uncomment to see captured expression in exception message:
        //Action? bad = null;
        //Execute(bad!);
    }
}
