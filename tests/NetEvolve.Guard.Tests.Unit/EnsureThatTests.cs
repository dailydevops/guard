namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using NetEvolve.Extensions.TUnit;

[ExcludeFromCodeCoverage]
[UnitTest]
public sealed class EnsureThatTests
{
    [Test]
    [Arguments(null)]
    [Arguments("")]
    public void That_Object_Theory_Expected(string? parameterName)
    {
        var value = new string('-', 10);
        _ = parameterName is null
            ? Assert.Throws<ArgumentNullException>(nameof(parameterName), () => _ = Ensure.That(value, parameterName!))
            : Assert.Throws<ArgumentException>(nameof(parameterName), () => _ = Ensure.That(value, parameterName!));
    }

    [Test]
    [Arguments(null)]
    [Arguments("")]
    public void That_Struct_Theory_Expected(string? parameterName)
    {
        var value = 5;
        _ = parameterName is null
            ? Assert.Throws<ArgumentNullException>(nameof(parameterName), () => _ = Ensure.That(value, parameterName!))
            : Assert.Throws<ArgumentException>(nameof(parameterName), () => _ = Ensure.That(value, parameterName!));
    }

    [Test]
    [Arguments(null)]
    [Arguments("")]
    public void That_NullableStruct_Theory_Expected(string? parameterName)
    {
        int? value = null;
        _ = parameterName is null
            ? Assert.Throws<ArgumentNullException>(nameof(parameterName), () => _ = Ensure.That(value, parameterName!))
            : Assert.Throws<ArgumentException>(nameof(parameterName), () => _ = Ensure.That(value, parameterName!));
    }
}
