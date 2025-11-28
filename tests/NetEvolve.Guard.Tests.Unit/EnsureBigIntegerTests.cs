namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using NetEvolve.Extensions.TUnit;
using NetEvolve.Guard;

[ExcludeFromCodeCoverage]
[UnitTest]
public sealed class EnsureBigIntegerTests
{
    private static BigInteger BaseValue { get; }
    private static BigInteger MaxValue { get; } = BigInteger.One;
    private static BigInteger MinValue { get; } = BigInteger.MinusOne;

    [Test]
    [MethodDataSource(nameof(GetInBetweenData))]
    public void InBetween_Theory_Expected(bool throwException, BigInteger value, BigInteger min, BigInteger max)
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
    public void NotBetween_Theory_Expected(bool throwException, BigInteger value, BigInteger min, BigInteger max)
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
    public void GreaterThan_Theory_Expected(bool throwException, BigInteger value, BigInteger compareValue)
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
    public void GreaterThanOrEqual_Theory_Expected(bool throwException, BigInteger value, BigInteger compareValue)
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
    public void LessThan_Theory_Expected(bool throwException, BigInteger value, BigInteger compareValue)
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
    public void LessThanOrEqual_Theory_Expected(bool throwException, BigInteger value, BigInteger compareValue)
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

    public static IEnumerable<(bool, BigInteger, BigInteger, BigInteger)> GetInBetweenData =>
        [
            (true, MinValue, BaseValue, MaxValue),
            (true, MaxValue, BaseValue, MinValue),
            (false, MinValue, MinValue, MaxValue),
            (false, MaxValue, MinValue, MaxValue),
            (false, BaseValue, MinValue, MaxValue),
            (false, BaseValue, MaxValue, MinValue),
        ];

    public static IEnumerable<(bool, BigInteger, BigInteger, BigInteger)> GetNotBetweenData =>
        [
            (false, MinValue, BaseValue, MaxValue),
            (false, MaxValue, BaseValue, MinValue),
            (true, BaseValue, MinValue, MaxValue),
            (true, BaseValue, MaxValue, MinValue),
        ];

    public static IEnumerable<(bool, BigInteger, BigInteger)> GetGreaterThanData =>
        [(true, BaseValue, MaxValue), (true, BaseValue, BaseValue), (false, BaseValue, MinValue)];

    public static IEnumerable<(bool, BigInteger, BigInteger)> GetGreaterThanOrEqualData =>
        [(true, BaseValue, MaxValue), (false, BaseValue, BaseValue), (false, BaseValue, MinValue)];

    public static IEnumerable<(bool, BigInteger, BigInteger)> GetLessThanData =>
        [(true, BaseValue, MinValue), (true, BaseValue, BaseValue), (false, BaseValue, MaxValue)];

    public static IEnumerable<(bool, BigInteger, BigInteger)> GetLessThanOrEqualData =>
        [(true, BaseValue, MinValue), (false, BaseValue, BaseValue), (false, BaseValue, MaxValue)];

#if NET6_0_OR_GREATER
    [Test]
    [MethodDataSource(nameof(GetNotPow2Data))]
    public void NotPow2_Theory_Expected(bool throwException, BigInteger value)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(nameof(value), () => _ = Ensure.That(value).IsPow2());
        }
        else
        {
            _ = Ensure.That(value).IsPow2();
        }
    }

    public static IEnumerable<(bool, BigInteger)> GetNotPow2Data => [(true, 63), (false, 64)];
#endif
}
