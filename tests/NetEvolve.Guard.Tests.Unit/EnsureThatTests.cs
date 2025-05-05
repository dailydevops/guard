namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using NetEvolve.Extensions.XUnit;
using Xunit;

[ExcludeFromCodeCoverage]
[UnitTest]
public sealed class EnsureThatTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void That_Object_Theory_Expected(string? parameterName)
    {
        var value = new string('-', 10);
        _ = parameterName is null
            ? Assert.Throws<ArgumentNullException>(nameof(parameterName), () => _ = Ensure.That(value, parameterName!))
            : Assert.Throws<ArgumentException>(nameof(parameterName), () => _ = Ensure.That(value, parameterName!));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void That_Struct_Theory_Expected(string? parameterName)
    {
        var value = 5;
        _ = parameterName is null
            ? Assert.Throws<ArgumentNullException>(nameof(parameterName), () => _ = Ensure.That(value, parameterName!))
            : Assert.Throws<ArgumentException>(nameof(parameterName), () => _ = Ensure.That(value, parameterName!));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void That_NullableStruct_Theory_Expected(string? parameterName)
    {
        int? value = null;
        _ = parameterName is null
            ? Assert.Throws<ArgumentNullException>(nameof(parameterName), () => _ = Ensure.That(value, parameterName!))
            : Assert.Throws<ArgumentException>(nameof(parameterName), () => _ = Ensure.That(value, parameterName!));
    }
}
