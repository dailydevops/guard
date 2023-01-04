namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Xunit;

[ExcludeFromCodeCoverage]
public class EnsureStringTests
{
    [Theory]
    [InlineData(true, false, null)]
    [InlineData(false, true, "")]
    [InlineData(false, false, " ")]
    [InlineData(false, false, "Hello World!")]
    public void NotNullOrEmpty_Theory_Expected(
        bool throwExceptionNull,
        bool throwException,
        string? value
    )
    {
        if (throwExceptionNull)
        {
            _ = Assert.Throws<ArgumentNullException>(
                nameof(value),
                () => _ = Ensure.That(value).IsNotNullOrEmpty()
            );
        }
        else if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(
                nameof(value),
                () => _ = Ensure.That(value).IsNotNullOrEmpty()
            );
        }
        else
        {
            _ = Ensure.That(value).IsNotNullOrEmpty();
        }
    }

    [Theory]
    [InlineData(true, false, null)]
    [InlineData(false, true, "")]
    [InlineData(false, true, " ")]
    [InlineData(false, false, "Hello World!")]
    public void NotNullOrWhiteSpace_Theory_Expected(
        bool throwExceptionNull,
        bool throwException,
        string? value
    )
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
            _ = Assert.Throws<ArgumentException>(
                nameof(value),
                () => _ = Ensure.That(value).IsNotNullOrWhiteSpace()
            );
        }
        else
        {
            _ = Ensure.That(value).IsNotNullOrWhiteSpace();
        }
    }

    [Theory]
    [InlineData(true, null)]
    [InlineData(
        true,
        /*language=regex*/@"^\d+"
    )]
    [InlineData(
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

    [Theory]
    [InlineData(true, null, RegexOptions.IgnoreCase)]
    [InlineData(
        true,
        /*language=regex*/@"^[a-z]+",
        RegexOptions.None
    )]
    [InlineData(
        false,
        /*language=regex*/@"^[a-z]+",
        RegexOptions.IgnoreCase
    )]
    public void IsMatchWithOptions_Theory_Expected(
        bool throwException,
        string? pattern,
        RegexOptions options
    )
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
