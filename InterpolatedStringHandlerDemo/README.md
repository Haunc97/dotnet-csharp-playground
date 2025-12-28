# InterpolatedStringHandlerDemo

A small C# demo project showing how to build a **custom interpolated
string handler** that allows expensive logging work to be skipped
*before* string formatting happens.

This pattern is useful for high-performance logging scenarios where:

- logging may be disabled at runtime
- message formatting is expensive
- allocations should be avoided when logs are filtered out

The project demonstrates:

- `[InterpolatedStringHandler]`
- `[InterpolatedStringHandlerArgument]`
- execution-time logging control
- diagnostic output to show handler behavior

---

## Key Idea

Instead of always building a log string like:

```csharp
logger.LogMessage(LogLevel.Information, $"User {user} logged in");
