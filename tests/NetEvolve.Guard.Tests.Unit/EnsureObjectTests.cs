namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

[ExcludeFromCodeCoverage]
public class EnsureObjectTests
{
    [Theory]
    [InlineData(true, null)]
    [InlineData(false, "")]
    [InlineData(false, "Hello World!")]
    public void NotNull_Theory_Expected(bool throwException, string? value)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentNullException>(
                nameof(value),
                () => _ = Ensure.That(value).IsNotNull()
            );
        }
        else
        {
            _ = Ensure.That(value).IsNotNull();
        }
    }

    [Fact]
    public void Validate_ValueNull_Exception()
    {
        List<string>? value = null;
        _ = Assert.Throws<ArgumentNullException>(
            "condition",
            () => _ = Ensure.That(value).Validate(null!)
        );
    }

    [Fact]
    public void Validate_ValueInvalid_Exception()
    {
        var value = new List<string>();
        _ = Assert.Throws<ArgumentException>(
            nameof(value),
            () => _ = Ensure.That(value).IsNotNull().Validate(x => x.Any())
        );
    }

    [Fact]
    public void Validate_ValueInvalidAndConditionStringNull_Exception()
    {
        var value = new List<string>();
        _ = Assert.Throws<ArgumentException>(
            nameof(value),
            () =>
                _ = Ensure.That(value).IsNotNull().Validate(x => x.Any(), conditionAsString: null!)
        );
    }

    [Fact]
    public void Validate_ValueValue_Exception()
    {
        var value = new List<string> { "Hi" };
        _ = Ensure.That(value).IsNotNull().Validate(x => x.Any());
    }
}
