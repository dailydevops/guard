namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

[ExcludeFromCodeCoverage]
public class EnsureArrayTests
{
    [Fact]
    public void NotNullOrEmpty_Null_ArgumentNullException()
    {
        string?[]? values = null;

        _ = Assert.Throws<ArgumentNullException>(
            nameof(values),
            () => _ = Ensure.That(values).IsNotNullOrEmpty()
        );
    }

    [Theory]
    [MemberData(nameof(GetNotNullOrEmptyData))]
    public void NotNullOrEmpty_Theory_Expected(bool throwException, string?[] values)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(
                nameof(values),
                () => _ = Ensure.That(values).IsNotNullOrEmpty()
            );
        }
        else
        {
            _ = Ensure.That(values).IsNotNullOrEmpty();
        }
    }

    public static TheoryData GetNotNullOrEmptyData =>
        new TheoryData<bool, string?[]>
        {
            { true, Array.Empty<string?>() },
            { false, new string?[] { "Hello", null, "World!" } },
            { false, new string?[] { "Hello", string.Empty, "World!" } },
            { false, new string?[] { "Hello", " ", "World!" } },
        };
}
