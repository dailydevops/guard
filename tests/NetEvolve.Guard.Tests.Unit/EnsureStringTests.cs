namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using NetEvolve.Extensions.TUnit;

[ExcludeFromCodeCoverage]
[UnitTest]
public class EnsureStringTests
{
    [Test]
    [Arguments(true, false, null)]
    [Arguments(false, true, "")]
    [Arguments(false, false, " ")]
    [Arguments(false, false, "Hello World!")]
    public void NotNullOrEmpty_Theory_Expected(bool throwExceptionNull, bool throwException, string? value)
    {
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

    [Test]
    [Arguments(true, false, null)]
    [Arguments(false, true, "")]
    [Arguments(false, true, " ")]
    [Arguments(false, false, "Hello World!")]
    public void NotNullOrWhiteSpace_Theory_Expected(bool throwExceptionNull, bool throwException, string? value)
    {
        if (throwExceptionNull)
        {
            _ = Assert.Throws<ArgumentNullException>(
                nameof(value),
                () => _ = Ensure.That(value).IsNotNullOrWhiteSpace()
            );
        }
        else if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(nameof(value), () => _ = Ensure.That(value).IsNotNullOrWhiteSpace());
        }
        else
        {
            _ = Ensure.That(value).IsNotNullOrWhiteSpace();
        }
    }

    [Test]
    [Arguments(true, null)]
    [Arguments(
        true,
        /*language=regex*/@"^\d+"
    )]
    [Arguments(
        false,
        /*language=regex*/@"^\w+"
    )]
    public void IsMatch_Theory_Expected(bool throwException, string? pattern)
    {
        var value = "Lorum ipsum";

        if (pattern is null)
        {
            _ = Assert.Throws<ArgumentNullException>(
                nameof(pattern),
                () => _ = Ensure.That(value).IsNotNull().IsMatch(pattern!)
            );
        }
        else if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(
                nameof(value),
                () => _ = Ensure.That(value).IsNotNull().IsMatch(pattern!)
            );
        }
        else
        {
            _ = Ensure.That(value).IsNotNull().IsMatch(pattern!);
        }
    }

    [Test]
    [Arguments(true, null, RegexOptions.IgnoreCase)]
    [Arguments(
        true,
        /*language=regex*/@"^[a-z]+",
        RegexOptions.None
    )]
    [Arguments(
        false,
        /*language=regex*/@"^[a-z]+",
        RegexOptions.IgnoreCase
    )]
    public void IsMatchWithOptions_Theory_Expected(bool throwException, string? pattern, RegexOptions options)
    {
        var value = "Lorum ipsum";

        if (pattern is null)
        {
            _ = Assert.Throws<ArgumentNullException>(
                nameof(pattern),
                () => _ = Ensure.That(value).IsNotNull().IsMatch(pattern!, options)
            );
        }
        else if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(
                nameof(value),
                () => _ = Ensure.That(value).IsNotNull().IsMatch(pattern!, options)
            );
        }
        else
        {
            _ = Ensure.That(value).IsNotNull().IsMatch(pattern!, options);
        }
    }
}
