namespace NetEvolve.Guard.Tests.Unit;

using NetEvolve.Extensions.XUnit;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

[ExcludeFromCodeCoverage]
[UnitTest]
public class EnsureStructTests
{
    [Theory]
    [InlineData(true, default(int))]
    [InlineData(false, 5)]
    public void NotDefault_Theory_Expected(bool throwException, int value)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(
                nameof(value),
                () => _ = Ensure.That(value).IsNotDefault()
            );
        }
        else
        {
            _ = Ensure.That(value).IsNotDefault();
        }
    }

    [Theory]
    [InlineData(true, null)]
    [InlineData(false, default(int))]
    [InlineData(false, 5)]
    public void NotNull_Theory_Expected(bool throwException, int? value)
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
            var result = _ = Ensure.That(value).IsNotNull();

            _ = Assert.IsType<int>(result);
            Assert.Equal<int>(value!.Value, result);
        }
    }

    [Theory]
    [InlineData(true, null)]
    [InlineData(true, default(int))]
    [InlineData(false, 5)]
    public void NotNullOrDefault_Theory_Expected(bool throwException, int? value)
    {
        if (throwException)
        {
            _ = Assert.Throws(
                value.HasValue ? typeof(ArgumentException) : typeof(ArgumentNullException),
                () => _ = Ensure.That(value).IsNotNullOrDefault()
            );
        }
        else
        {
            var result = _ = Ensure.That(value).IsNotNullOrDefault();

            _ = Assert.IsType<int>(result);
            Assert.Equal<int>(value!.Value, result);
        }
    }
}
