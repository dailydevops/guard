﻿namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using NetEvolve.Extensions.XUnit;
using Xunit;

[ExcludeFromCodeCoverage]
[UnitTest]
public class EnsureArrayTests
{
    [Fact]
    public void NotNullOrEmpty_Null_ArgumentNullException()
    {
        string?[]? values = null;

        _ = Assert.Throws<ArgumentNullException>(nameof(values), () => _ = Ensure.That(values).IsNotNullOrEmpty());
    }

    [Theory]
    [MemberData(nameof(GetNotNullOrEmptyData))]
    public void NotNullOrEmpty_Theory_Expected(bool throwException, string?[] values)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(nameof(values), () => _ = Ensure.That(values).IsNotNullOrEmpty());
        }
        else
        {
            _ = Ensure.That(values).IsNotNullOrEmpty();
        }
    }

    public static TheoryData<bool, string?[]> GetNotNullOrEmptyData =>
        new TheoryData<bool, string?[]>
        {
            { true, Array.Empty<string?>() },
            { false, new string?[] { "Hello", null, "World!" } },
            { false, new string?[] { "Hello", string.Empty, "World!" } },
            { false, new string?[] { "Hello", " ", "World!" } },
        };
}
