namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

[ExcludeFromCodeCoverage]
public class EnsureIEnumerableTests
{
    [Fact]
    public void NotNullOrEmpty_Null_ArgumentNullException()
    {
        IEnumerable<string>? values = null;

        _ = Assert.Throws<ArgumentNullException>(
            nameof(values),
            () => _ = Ensure.That(values).IsNotNullOrEmpty()
        );
    }

    [Theory]
    [MemberData(nameof(GetNotNullOrEmptyData))]
    public void NotNullOrEmpty_Theory_Expected(bool throwException, IEnumerable<string?> values)
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
        new TheoryData<bool, IEnumerable<string?>>
        {
            { true, Array.Empty<string?>() },
            { true, Enumerable.Empty<string?>() },
            { false, new string?[] { "Hello", null, "World!" } },
            { false, new string?[] { "Hello", string.Empty, "World!" } },
            { false, new string?[] { "Hello", " ", "World!" } },
        };
}
