namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using NetEvolve.Extensions.TUnit;

[ExcludeFromCodeCoverage]
[UnitTest]
public class EnsureArrayTests
{
    [Test]
    public void NotNullOrEmpty_Null_ArgumentNullException()
    {
        string?[]? values = null;

        _ = Assert.Throws<ArgumentNullException>(nameof(values), () => _ = Ensure.That(values).IsNotNullOrEmpty());
    }

    [Test]
    [MethodDataSource(nameof(GetNotNullOrEmptyData))]
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

    public static IEnumerable<(bool, string?[])> GetNotNullOrEmptyData =>
        [
            (true, []),
            (false, ["Hello", null, "World!"]),
            (false, ["Hello", string.Empty, "World!"]),
            (false, ["Hello", " ", "World!"]),
        ];
}
