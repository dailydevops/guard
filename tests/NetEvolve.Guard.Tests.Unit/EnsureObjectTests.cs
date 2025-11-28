namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class EnsureObjectTests
{
    [Test]
    [Arguments(true, null)]
    [Arguments(false, "")]
    [Arguments(false, "Hello World!")]
    public void NotNull_Theory_Expected(bool throwException, string? value)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentNullException>(nameof(value), () => _ = Ensure.That(value).IsNotNull());
        }
        else
        {
            _ = Ensure.That(value).IsNotNull();
        }
    }

    [Test]
    public void Validate_ValueNull_Exception()
    {
        List<string>? value = null;
        _ = Assert.Throws<ArgumentNullException>("condition", () => _ = Ensure.That(value).Validate(null!));
    }

    [Test]
    public void Validate_ValueInvalid_Exception()
    {
        var value = new List<string>();
        _ = Assert.Throws<ArgumentException>(
            nameof(value),
            () => _ = Ensure.That(value).IsNotNull().Validate(x => x.Count != 0)
        );
    }

    [Test]
    public void Validate_ValueInvalidAndConditionStringNull_Exception()
    {
        var value = new List<string>();
        _ = Assert.Throws<ArgumentException>(
            nameof(value),
            () => _ = Ensure.That(value).IsNotNull().Validate(x => x.Count != 0, conditionAsString: null!)
        );
    }

    [Test]
    public void Validate_ValueValue_Exception()
    {
        var value = new List<string> { "Hi" };
        _ = Ensure.That(value).IsNotNull().Validate(x => x.Count != 0);
    }
}
