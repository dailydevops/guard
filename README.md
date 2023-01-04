# NetEvolve.Guard

Basic input validation via the `Requires` class throws an `ArgumentException`, `ArgumentNullException` or other Exception types. The second parameter `parameterName` from `Ensure.That(T value, string? parameterName = default!)` is optional and is automatically populated by .NET, based on the `CallerArgumentExpressionAttribute` functionality.

```csharp
public static bool Execute(string? directoryFolder)
{
    string directory = Ensure.That(directoryFolder).IsNotNullOrWhiteSpace();
    // or alternatively
    string directory = Ensure.That(directoryFolder, nameof(directoryFolder)).IsNotNullOrWhiteSpace();

    // Do some magic
    ...
}
```