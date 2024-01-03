namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using NetEvolve.Extensions.XUnit;
using NetEvolve.Guard;
using Xunit;

[ExcludeFromCodeCoverage]
[UnitTest]
public sealed class EnsureUInt64Tests
{
    private static ulong BaseValue { get; } = 1;
    private static ulong MaxValue { get; } = ulong.MaxValue;
    private static ulong MinValue { get; } = ulong.MinValue;

    [Theory]
    [MemberData(nameof(GetInBetweenData))]
    public void InBetween_Theory_Expected(bool throwException, ulong value, ulong min, ulong max)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(value),
                () => _ = Ensure.That(value).IsBetween(min, max)
            );
        }
        else
        {
            _ = Ensure.That(value).IsBetween(min, max);
        }
    }

    [Theory]
    [MemberData(nameof(GetNotBetweenData))]
    public void NotBetween_Theory_Expected(bool throwException, ulong value, ulong min, ulong max)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(value),
                () => _ = Ensure.That(value).IsNotBetween(min, max)
            );
        }
        else
        {
            _ = Ensure.That(value).IsNotBetween(min, max);
        }
    }

    [Theory]
    [MemberData(nameof(GetGreaterThanData))]
    public void GreaterThan_Theory_Expected(bool throwException, ulong value, ulong compareValue)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(value),
                () => _ = Ensure.That(value).IsGreaterThan(compareValue)
            );
        }
        else
        {
            _ = Ensure.That(value).IsGreaterThan(compareValue);
        }
    }

    [Theory]
    [MemberData(nameof(GetGreaterThanOrEqualData))]
    public void GreaterThanOrEqual_Theory_Expected(
        bool throwException,
        ulong value,
        ulong compareValue
    )
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(value),
                () => _ = Ensure.That(value).IsGreaterThanOrEqual(compareValue)
            );
        }
        else
        {
            _ = Ensure.That(value).IsGreaterThanOrEqual(compareValue);
        }
    }

    [Theory]
    [MemberData(nameof(GetLessThanData))]
    public void LessThan_Theory_Expected(bool throwException, ulong value, ulong compareValue)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(value),
                () => _ = Ensure.That(value).IsLessThan(compareValue)
            );
        }
        else
        {
            _ = Ensure.That(value).IsLessThan(compareValue);
        }
    }

    [Theory]
    [MemberData(nameof(GetLessThanOrEqualData))]
    public void LessThanOrEqual_Theory_Expected(
        bool throwException,
        ulong value,
        ulong compareValue
    )
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(value),
                () => _ = Ensure.That(value).IsLessThanOrEqual(compareValue)
            );
        }
        else
        {
            _ = Ensure.That(value).IsLessThanOrEqual(compareValue);
        }
    }

    public static TheoryData<bool, ulong, ulong, ulong> GetInBetweenData =>
        new TheoryData<bool, ulong, ulong, ulong>
        {
            { true, MinValue, BaseValue, MaxValue },
            { true, MaxValue, BaseValue, MinValue },
            { false, MinValue, MinValue, MaxValue },
            { false, MaxValue, MinValue, MaxValue },
            { false, BaseValue, MinValue, MaxValue },
            { false, BaseValue, MaxValue, MinValue }
        };

    public static TheoryData<bool, ulong, ulong, ulong> GetNotBetweenData =>
        new TheoryData<bool, ulong, ulong, ulong>
        {
            { false, MinValue, BaseValue, MaxValue },
            { false, MaxValue, BaseValue, MinValue },
            { true, BaseValue, MinValue, MaxValue },
            { true, BaseValue, MaxValue, MinValue }
        };

    public static TheoryData<bool, ulong, ulong> GetGreaterThanData =>
        new TheoryData<bool, ulong, ulong>
        {
            { true, BaseValue, MaxValue },
            { true, BaseValue, BaseValue },
            { false, BaseValue, MinValue }
        };

    public static TheoryData<bool, ulong, ulong> GetGreaterThanOrEqualData =>
        new TheoryData<bool, ulong, ulong>
        {
            { true, BaseValue, MaxValue },
            { false, BaseValue, BaseValue },
            { false, BaseValue, MinValue }
        };

    public static TheoryData<bool, ulong, ulong> GetLessThanData =>
        new TheoryData<bool, ulong, ulong>
        {
            { true, BaseValue, MinValue },
            { true, BaseValue, BaseValue },
            { false, BaseValue, MaxValue }
        };

    public static TheoryData<bool, ulong, ulong> GetLessThanOrEqualData =>
        new TheoryData<bool, ulong, ulong>
        {
            { true, BaseValue, MinValue },
            { false, BaseValue, BaseValue },
            { false, BaseValue, MaxValue }
        };

#if NET6_0_OR_GREATER
    [Theory]
    [MemberData(nameof(GetNotPow2Data))]
    public void NotPow2_Theory_Expected(bool throwException, ulong value)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(
                nameof(value),
                () => _ = Ensure.That(value).IsPow2()
            );
        }
        else
        {
            _ = Ensure.That(value).IsPow2();
        }
    }

    public static TheoryData<bool, ulong> GetNotPow2Data =>
        new TheoryData<bool, ulong> { { true, 63 }, { false, 64 } };
#endif
}
