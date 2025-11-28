namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using NetEvolve.Extensions.TUnit;

[ExcludeFromCodeCoverage]
[UnitTest]
public class EnsureGuidTests
{
    [Test]
    [Arguments(true, "00000000-0000-0000-0000-000000000000")]
    [Arguments(false, "00000000-0000-0000-0000-000000000001")]
    public void NotEmpty_Theory_Expected(bool throwException, string valueString)
    {
        var value = Guid.Parse(valueString);
        if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(nameof(value), () => _ = Ensure.That(value).IsNotEmpty());
        }
        else
        {
            _ = Ensure.That(value).IsNotEmpty();
        }
    }

    [Test]
    [Arguments(true, false, null)]
    [Arguments(false, true, "00000000-0000-0000-0000-000000000000")]
    [Arguments(false, false, "00000000-0000-0000-0000-000000000001")]
    public void NotNullOrEmpty_Theory_Expected(bool throwExceptionNull, bool throwException, string? valueString)
    {
        Guid? value = valueString is not null ? Guid.Parse(valueString) : null;
        if (throwExceptionNull)
        {
            _ = Assert.Throws<ArgumentNullException>(nameof(value), () => _ = Ensure.That(value).IsNotNullOrEmpty());
        }
        else if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(nameof(value), () => _ = Ensure.That(value).IsNotNullOrEmpty());
        }
        else
        {
            _ = Ensure.That(value).IsNotNullOrEmpty();
        }
    }
}
