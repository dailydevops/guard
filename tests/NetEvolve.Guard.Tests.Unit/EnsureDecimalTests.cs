namespace NetEvolve.Guard.Tests.Unit;

using NetEvolve.Extensions.XUnit;
using NetEvolve.Guard;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

[ExcludeFromCodeCoverage]
[UnitTest]
public sealed class EnsureDecimalTests
{
    private static decimal BaseValue { get; }
    private static decimal MaxValue { get; } = decimal.MaxValue;
    private static decimal MinValue { get; } = decimal.MinValue;

    [Theory]
    [MemberData(nameof(GetInBetweenData))]
    public void InBetween_Theory_Expected(
        bool throwException,
        decimal value,
        decimal min,
        decimal max
    )
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
    public void NotBetween_Theory_Expected(
        bool throwException,
        decimal value,
        decimal min,
        decimal max
    )
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
    public void GreaterThan_Theory_Expected(
        bool throwException,
        decimal value,
        decimal compareValue
    )
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
        decimal value,
        decimal compareValue
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
    public void LessThan_Theory_Expected(bool throwException, decimal value, decimal compareValue)
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
        decimal value,
        decimal compareValue
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

    public static TheoryData GetInBetweenData =>
        new TheoryData<bool, decimal, decimal, decimal>
        {
            { true, MinValue, BaseValue, MaxValue },
            { true, MaxValue, BaseValue, MinValue },
            { false, MinValue, MinValue, MaxValue },
            { false, MaxValue, MinValue, MaxValue },
            { false, BaseValue, MinValue, MaxValue },
            { false, BaseValue, MaxValue, MinValue }
        };

    public static TheoryData GetNotBetweenData =>
        new TheoryData<bool, decimal, decimal, decimal>
        {
            { false, MinValue, BaseValue, MaxValue },
            { false, MaxValue, BaseValue, MinValue },
            { true, BaseValue, MinValue, MaxValue },
            { true, BaseValue, MaxValue, MinValue }
        };

    public static TheoryData GetGreaterThanData =>
        new TheoryData<bool, decimal, decimal>
        {
            { true, BaseValue, MaxValue },
            { true, BaseValue, BaseValue },
            { false, BaseValue, MinValue }
        };

    public static TheoryData GetGreaterThanOrEqualData =>
        new TheoryData<bool, decimal, decimal>
        {
            { true, BaseValue, MaxValue },
            { false, BaseValue, BaseValue },
            { false, BaseValue, MinValue }
        };

    public static TheoryData GetLessThanData =>
        new TheoryData<bool, decimal, decimal>
        {
            { true, BaseValue, MinValue },
            { true, BaseValue, BaseValue },
            { false, BaseValue, MaxValue }
        };

    public static TheoryData GetLessThanOrEqualData =>
        new TheoryData<bool, decimal, decimal>
        {
            { true, BaseValue, MinValue },
            { false, BaseValue, BaseValue },
            { false, BaseValue, MaxValue }
        };
}
