#if NET5_0_OR_GREATER
namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using NetEvolve.Extensions.TUnit;
using NetEvolve.Guard;

[ExcludeFromCodeCoverage]
[UnitTest]
public sealed class EnsureHalfTests
{
    private static Half BaseValue { get; }
    private static Half MaxValue { get; } = Half.MaxValue;
    private static Half MinValue { get; } = Half.MinValue;
    private static Half NaN { get; } = Half.NaN;
    private static Half NegativeInfinity { get; } = Half.NegativeInfinity;
    private static Half PositiveInfinity { get; } = Half.PositiveInfinity;

    [Test]
    [MethodDataSource(nameof(GetInBetweenData))]
    public void InBetween_Theory_Expected(bool throwException, Half value, Half min, Half max)
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
    public void NotBetween_Theory_Expected(bool throwException, Half value, Half min, Half max)
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
    public void GreaterThan_Theory_Expected(bool throwException, Half value, Half compareValue)
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
    public void GreaterThanOrEqual_Theory_Expected(bool throwException, Half value, Half compareValue)
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
    public void LessThan_Theory_Expected(bool throwException, Half value, Half compareValue)
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
    public void LessThanOrEqual_Theory_Expected(bool throwException, Half value, Half compareValue)
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

    [Test]
    [MethodDataSource(nameof(GetNotNaNData))]
    public void NotNaN_Theory_Expected(bool throwException, Half value)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(nameof(value), () => _ = Ensure.That(value).IsNotNaN());
        }
        else
        {
            _ = Ensure.That(value).IsNotNaN();
        }
    }

    [Test]
    [MethodDataSource(nameof(GetNotInfinityData))]
    public void NotInfinity_Theory_Expected(bool throwException, Half value)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(nameof(value), () => _ = Ensure.That(value).IsNotInfinity());
        }
        else
        {
            _ = Ensure.That(value).IsNotInfinity();
        }
    }

    [Test]
    [MethodDataSource(nameof(GetNotNegativeInfinityData))]
    public void NotNegativeInfinity_Theory_Expected(bool throwException, Half value)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(nameof(value), () => _ = Ensure.That(value).IsNotNegativeInfinity());
        }
        else
        {
            _ = Ensure.That(value).IsNotNegativeInfinity();
        }
    }

    [Test]
    [MethodDataSource(nameof(GetNotPositiveInfinityData))]
    public void NotPositiveInfinity_Theory_Expected(bool throwException, Half value)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(nameof(value), () => _ = Ensure.That(value).IsNotPositiveInfinity());
        }
        else
        {
            _ = Ensure.That(value).IsNotPositiveInfinity();
        }
    }

    public static IEnumerable<(bool, Half, Half, Half)> GetInBetweenData =>
        [
            (true, MinValue, BaseValue, MaxValue),
            (true, MaxValue, BaseValue, MinValue),
#if NET6_0_OR_GREATER
            // Known Issue for .NET 5 - https://github.com/dotnet/runtime/issues/49983
            (false, MinValue, MinValue, MaxValue),
#endif
            (false, MaxValue, MinValue, MaxValue),
            (false, BaseValue, MinValue, MaxValue),
            (false, BaseValue, MaxValue, MinValue),
        ];

    public static IEnumerable<(bool, Half, Half, Half)> GetNotBetweenData =>
        [
            (false, MinValue, BaseValue, MaxValue),
            (false, MaxValue, BaseValue, MinValue),
            (true, BaseValue, MinValue, MaxValue),
            (true, BaseValue, MaxValue, MinValue),
        ];

    public static IEnumerable<(bool, Half, Half)> GetGreaterThanData =>
        [(true, BaseValue, MaxValue), (true, BaseValue, BaseValue), (false, BaseValue, MinValue)];

    public static IEnumerable<(bool, Half, Half)> GetGreaterThanOrEqualData =>
        [(true, BaseValue, MaxValue), (false, BaseValue, BaseValue), (false, BaseValue, MinValue)];

    public static IEnumerable<(bool, Half, Half)> GetLessThanData =>
        [(true, BaseValue, MinValue), (true, BaseValue, BaseValue), (false, BaseValue, MaxValue)];

    public static IEnumerable<(bool, Half, Half)> GetLessThanOrEqualData =>
        [(true, BaseValue, MinValue), (false, BaseValue, BaseValue), (false, BaseValue, MaxValue)];

    public static IEnumerable<(bool, Half)> GetNotNaNData =>
        [(true, NaN), (false, BaseValue), (false, MaxValue), (false, MinValue)];

    public static IEnumerable<(bool, Half)> GetNotInfinityData =>
        [(true, PositiveInfinity), (true, NegativeInfinity), (false, MaxValue), (false, MinValue)];

    public static IEnumerable<(bool, Half)> GetNotNegativeInfinityData =>
        [(false, PositiveInfinity), (true, NegativeInfinity), (false, MaxValue), (false, MinValue)];

    public static IEnumerable<(bool, Half)> GetNotPositiveInfinityData =>
        [(true, PositiveInfinity), (false, NegativeInfinity), (false, MaxValue), (false, MinValue)];
}
#endif
