#if NET6_0_OR_GREATER
namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using NetEvolve.Extensions.TUnit;
using NetEvolve.Guard;

[ExcludeFromCodeCoverage]
[UnitTest]
public sealed class EnsureDateOnlyTests
{
    private static DateOnly BaseValue { get; } = DateOnly.FromDateTime(DateTime.UtcNow);
    private static DateOnly MaxValue { get; } = DateOnly.MaxValue;
    private static DateOnly MinValue { get; } = DateOnly.MinValue;

    [Test]
    [MethodDataSource(nameof(GetInBetweenData))]
    public void InBetween_Theory_Expected(bool throwException, DateOnly value, DateOnly min, DateOnly max)
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

    [Test]
    [MethodDataSource(nameof(GetNotBetweenData))]
    public void NotBetween_Theory_Expected(bool throwException, DateOnly value, DateOnly min, DateOnly max)
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

    [Test]
    [MethodDataSource(nameof(GetGreaterThanData))]
    public void GreaterThan_Theory_Expected(bool throwException, DateOnly value, DateOnly compareValue)
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

    [Test]
    [MethodDataSource(nameof(GetGreaterThanOrEqualData))]
    public void GreaterThanOrEqual_Theory_Expected(bool throwException, DateOnly value, DateOnly compareValue)
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

    [Test]
    [MethodDataSource(nameof(GetLessThanData))]
    public void LessThan_Theory_Expected(bool throwException, DateOnly value, DateOnly compareValue)
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

    [Test]
    [MethodDataSource(nameof(GetLessThanOrEqualData))]
    public void LessThanOrEqual_Theory_Expected(bool throwException, DateOnly value, DateOnly compareValue)
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

    public static IEnumerable<(bool, DateOnly, DateOnly, DateOnly)> GetInBetweenData =>
        [
            (true, MinValue, BaseValue, MaxValue),
            (true, MaxValue, BaseValue, MinValue),
            (false, MinValue, MinValue, MaxValue),
            (false, MaxValue, MinValue, MaxValue),
            (false, BaseValue, MinValue, MaxValue),
            (false, BaseValue, MaxValue, MinValue),
        ];

    public static IEnumerable<(bool, DateOnly, DateOnly, DateOnly)> GetNotBetweenData =>
        [
            (false, MinValue, BaseValue, MaxValue),
            (false, MaxValue, BaseValue, MinValue),
            (true, BaseValue, MinValue, MaxValue),
            (true, BaseValue, MaxValue, MinValue),
        ];

    public static IEnumerable<(bool, DateOnly, DateOnly)> GetGreaterThanData =>
        [(true, BaseValue, MaxValue), (true, BaseValue, BaseValue), (false, BaseValue, MinValue)];

    public static IEnumerable<(bool, DateOnly, DateOnly)> GetGreaterThanOrEqualData =>
        [(true, BaseValue, MaxValue), (false, BaseValue, BaseValue), (false, BaseValue, MinValue)];

    public static IEnumerable<(bool, DateOnly, DateOnly)> GetLessThanData =>
        [(true, BaseValue, MinValue), (true, BaseValue, BaseValue), (false, BaseValue, MaxValue)];

    public static IEnumerable<(bool, DateOnly, DateOnly)> GetLessThanOrEqualData =>
        [(true, BaseValue, MinValue), (false, BaseValue, BaseValue), (false, BaseValue, MaxValue)];
}

#endif
