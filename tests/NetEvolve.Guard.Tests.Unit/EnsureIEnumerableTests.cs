namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

[ExcludeFromCodeCoverage]
[UnitTest]
public class EnsureIEnumerableTests
{
    [Test]
    public void NotNullOrEmpty_Null_ArgumentNullException()
    {
        IEnumerable<string>? values = null;

        _ = Assert.Throws<ArgumentNullException>(nameof(values), () => _ = Ensure.That(values).IsNotNullOrEmpty());
    }

    [Test]
    [MethodDataSource(nameof(GetNotNullOrEmptyData))]
    public void NotNullOrEmpty_Theory_Expected(bool throwException, IEnumerable<string?> values)
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

    [Test]
    [MethodDataSource(nameof(GetNotNullOrEmptyData))]
    public void NotNullOrEmpty_TEnumerableTheory_Expected(bool throwException, IEnumerable<string?> values)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(
                nameof(values),
                () => _ = Ensure.That(values).IsNotNullOrEmpty<IEnumerable<string?>, string?>()
            );
        }
        else
        {
            _ = Ensure.That(values).IsNotNullOrEmpty<IEnumerable<string?>, string?>();
        }
    }

    [Test]
    public void NotNullOrEmpty_TEnumerable_ArgumentNullException()
    {
        IEnumerable<string>? values = null;

        _ = Assert.Throws<ArgumentNullException>(
            nameof(values),
            () => _ = Ensure.That(values).IsNotNullOrEmpty<IEnumerable<string>, string>()
        );
    }

    [Test]
    public void NotNullOrEmpty_Array_ArgumentException()
    {
        var values = Array.Empty<string>();

        _ = Assert.Throws<ArgumentException>(
            nameof(values),
            () => _ = Ensure.That(values).IsNotNullOrEmpty<string[], string>()
        );
    }

    [Test]
    public void NotNullOrEmpty_List_ArgumentException()
    {
        var values = new List<string>();

        _ = Assert.Throws<ArgumentException>(
            nameof(values),
            () => _ = Ensure.That(values).IsNotNullOrEmpty<List<string>, string>()
        );
    }

    public static TheoryData<bool, IEnumerable<string?>> GetNotNullOrEmptyData =>
        new TheoryData<bool, IEnumerable<string?>>
        {
            { true, Array.Empty<string?>() },
            { true, Enumerable.Empty<string?>() },
            { false, new string?[] { "Hello", null, "World!" } },
            { false, new string?[] { "Hello", string.Empty, "World!" } },
            { false, new string?[] { "Hello", " ", "World!" } },
        };
}
