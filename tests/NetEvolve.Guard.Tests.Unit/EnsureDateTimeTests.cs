﻿namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using NetEvolve.Extensions.XUnit;
using NetEvolve.Guard;
using Xunit;

[ExcludeFromCodeCoverage]
[UnitTest]
public sealed class EnsureDateTimeTests
{
    private static DateTime BaseValue { get; } = DateTime.UtcNow;
    private static DateTime MaxValue { get; } = DateTime.MaxValue;
    private static DateTime MinValue { get; } = DateTime.MinValue;

    [Theory]
    [MemberData(nameof(GetInBetweenData))]
    public void InBetween_Theory_Expected(bool throwException, DateTime value, DateTime min, DateTime max)
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
    public void NotBetween_Theory_Expected(bool throwException, DateTime value, DateTime min, DateTime max)
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
    public void GreaterThan_Theory_Expected(bool throwException, DateTime value, DateTime compareValue)
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
    public void GreaterThanOrEqual_Theory_Expected(bool throwException, DateTime value, DateTime compareValue)
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
    public void LessThan_Theory_Expected(bool throwException, DateTime value, DateTime compareValue)
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
    public void LessThanOrEqual_Theory_Expected(bool throwException, DateTime value, DateTime compareValue)
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

    public static TheoryData<bool, DateTime, DateTime, DateTime> GetInBetweenData =>
        new TheoryData<bool, DateTime, DateTime, DateTime>
        {
            { true, MinValue, BaseValue, MaxValue },
            { true, MaxValue, BaseValue, MinValue },
            { false, MinValue, MinValue, MaxValue },
            { false, MaxValue, MinValue, MaxValue },
            { false, BaseValue, MinValue, MaxValue },
            { false, BaseValue, MaxValue, MinValue },
        };

    public static TheoryData<bool, DateTime, DateTime, DateTime> GetNotBetweenData =>
        new TheoryData<bool, DateTime, DateTime, DateTime>
        {
            { false, MinValue, BaseValue, MaxValue },
            { false, MaxValue, BaseValue, MinValue },
            { true, BaseValue, MinValue, MaxValue },
            { true, BaseValue, MaxValue, MinValue },
        };

    public static TheoryData<bool, DateTime, DateTime> GetGreaterThanData =>
        new TheoryData<bool, DateTime, DateTime>
        {
            { true, BaseValue, MaxValue },
            { true, BaseValue, BaseValue },
            { false, BaseValue, MinValue },
        };

    public static TheoryData<bool, DateTime, DateTime> GetGreaterThanOrEqualData =>
        new TheoryData<bool, DateTime, DateTime>
        {
            { true, BaseValue, MaxValue },
            { false, BaseValue, BaseValue },
            { false, BaseValue, MinValue },
        };

    public static TheoryData<bool, DateTime, DateTime> GetLessThanData =>
        new TheoryData<bool, DateTime, DateTime>
        {
            { true, BaseValue, MinValue },
            { true, BaseValue, BaseValue },
            { false, BaseValue, MaxValue },
        };

    public static TheoryData<bool, DateTime, DateTime> GetLessThanOrEqualData =>
        new TheoryData<bool, DateTime, DateTime>
        {
            { true, BaseValue, MinValue },
            { false, BaseValue, BaseValue },
            { false, BaseValue, MaxValue },
        };
}
