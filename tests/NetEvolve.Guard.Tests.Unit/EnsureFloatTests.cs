namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using NetEvolve.Extensions.TUnit;
using NetEvolve.Guard;

[ExcludeFromCodeCoverage]
[UnitTest]
public sealed class EnsureFloatTests
{
    private static float BaseValue { get; }
    private static float MaxValue { get; } = float.MaxValue;
    private static float MinValue { get; } = float.MinValue;
    private static float NaN { get; } = float.NaN;
    private static float NegativeInfinity { get; } = float.NegativeInfinity;
    private static float PositiveInfinity { get; } = float.PositiveInfinity;

    [Test]
    [MethodDataSource(nameof(GetInBetweenData))]
    public void InBetween_Theory_Expected(bool throwException, float value, float min, float max)
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
    public void NotBetween_Theory_Expected(bool throwException, float value, float min, float max)
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
    public void GreaterThan_Theory_Expected(bool throwException, float value, float compareValue)
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
    public void GreaterThanOrEqual_Theory_Expected(bool throwException, float value, float compareValue)
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
    public void LessThan_Theory_Expected(bool throwException, float value, float compareValue)
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
    public void LessThanOrEqual_Theory_Expected(bool throwException, float value, float compareValue)
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
    public void NotNaN_Theory_Expected(bool throwException, float value)
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
    public void NotInfinity_Theory_Expected(bool throwException, float value)
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
    public void NotNegativeInfinity_Theory_Expected(bool throwException, float value)
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
    public void NotPositiveInfinity_Theory_Expected(bool throwException, float value)
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

    public static IEnumerable<(bool, float, float, float)> GetInBetweenData =>
        new[]
        {
            (true, MinValue, BaseValue, MaxValue),
            (true, MaxValue, BaseValue, MinValue),
            (false, MinValue, MinValue, MaxValue),
            (false, MaxValue, MinValue, MaxValue),
            (false, BaseValue, MinValue, MaxValue),
            (false, BaseValue, MaxValue, MinValue),
        };

    public static IEnumerable<(bool, float, float, float)> GetNotBetweenData =>
        new[]
        {
            (false, MinValue, BaseValue, MaxValue),
            (false, MaxValue, BaseValue, MinValue),
            (true, BaseValue, MinValue, MaxValue),
            (true, BaseValue, MaxValue, MinValue),
        };

    public static IEnumerable<(bool, float, float)> GetGreaterThanData =>
        new[] { (true, BaseValue, MaxValue), (true, BaseValue, BaseValue), (false, BaseValue, MinValue) };

    public static IEnumerable<(bool, float, float)> GetGreaterThanOrEqualData =>
        new[] { (true, BaseValue, MaxValue), (false, BaseValue, BaseValue), (false, BaseValue, MinValue) };

    public static IEnumerable<(bool, float, float)> GetLessThanData =>
        new[] { (true, BaseValue, MinValue), (true, BaseValue, BaseValue), (false, BaseValue, MaxValue) };

    public static IEnumerable<(bool, float, float)> GetLessThanOrEqualData =>
        new[] { (true, BaseValue, MinValue), (false, BaseValue, BaseValue), (false, BaseValue, MaxValue) };

    public static IEnumerable<(bool, float)> GetNotNaNData =>
        new[] { (true, NaN), (false, BaseValue), (false, MaxValue), (false, MinValue) };

    public static IEnumerable<(bool, float)> GetNotInfinityData =>
        new[] { (true, PositiveInfinity), (true, NegativeInfinity), (false, MaxValue), (false, MinValue) };

    public static IEnumerable<(bool, float)> GetNotNegativeInfinityData =>
        new[] { (false, PositiveInfinity), (true, NegativeInfinity), (false, MaxValue), (false, MinValue) };

    public static IEnumerable<(bool, float)> GetNotPositiveInfinityData =>
        new[] { (true, PositiveInfinity), (false, NegativeInfinity), (false, MaxValue), (false, MinValue) };
}
