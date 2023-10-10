# NetEvolve.Guard

This library provides a set of guard clauses to validate method parameters and object states in a fluent manner. For this purpose, the library provides the `Ensure`-class, which is a static class with a set of extension methods.
The usage is very simple and intuitive. The following example shows the basic usage of the `Ensure`-class.

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
As you can see, the second parameter `parameterName` is optional and is automatically populated by .NET, based on the `CallerArgumentExpressionAttribute` functionality. This reduces the amount of code you have to write and makes the code more readable.

## Compatibility
The following .NET TargetFrameworks are supported:
- .NET Standard 2.0
- .NET 5.0
- .NET 6.0
- .NET 7.0
- .NET 8.0