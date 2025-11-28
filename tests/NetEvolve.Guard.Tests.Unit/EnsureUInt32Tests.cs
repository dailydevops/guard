namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using NetEvolve.Extensions.TUnit;
using NetEvolve.Guard;

[ExcludeFromCodeCoverage]
[UnitTest]
public sealed class EnsureUInt32Tests
{
    private static uint BaseValue { get; } = 1;
    private static uint MaxValue { get; } = uint.MaxValue;
    private static uint MinValue { get; } = uint.MinValue;

    [Test]
    [MethodDataSource(nameof(GetInBetweenData))]
    public void InBetween_Theory_Expected(bool throwException, uint value, uint min, uint max)
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
    public void NotBetween_Theory_Expected(bool throwException, uint value, uint min, uint max)
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
    public void GreaterThan_Theory_Expected(bool throwException, uint value, uint compareValue)
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
    public void GreaterThanOrEqual_Theory_Expected(bool throwException, uint value, uint compareValue)
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
    public void LessThan_Theory_Expected(bool throwException, uint value, uint compareValue)
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
    public void LessThanOrEqual_Theory_Expected(bool throwException, uint value, uint compareValue)
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

    public static IEnumerable<(bool, uint, uint, uint)> GetInBetweenData =>
        new List<(bool, uint, uint, uint)>
        {
            { (true, MinValue, BaseValue, MaxValue) },
            { (true, MaxValue, BaseValue, MinValue) },
            { (false, MinValue, MinValue, MaxValue) },
            { (false, MaxValue, MinValue, MaxValue) },
            { (false, BaseValue, MinValue, MaxValue) },
            { (false, BaseValue, MaxValue, MinValue) },
        };

    public static IEnumerable<(bool, uint, uint, uint)> GetNotBetweenData =>
        new List<(bool, uint, uint, uint)>
        {
            { (false, MinValue, BaseValue, MaxValue) },
            { (false, MaxValue, BaseValue, MinValue) },
            { (true, BaseValue, MinValue, MaxValue) },
            { (true, BaseValue, MaxValue, MinValue) },
        };

    public static IEnumerable<(bool, uint, uint)> GetGreaterThanData =>
        new List<(bool, uint, uint)>
        {
            { (true, BaseValue, MaxValue) },
            { (true, BaseValue, BaseValue) },
            { (false, BaseValue, MinValue) },
        };

    public static IEnumerable<(bool, uint, uint)> GetGreaterThanOrEqualData =>
        new List<(bool, uint, uint)>
        {
            { (true, BaseValue, MaxValue) },
            { (false, BaseValue, BaseValue) },
            { (false, BaseValue, MinValue) },
        };

    public static IEnumerable<(bool, uint, uint)> GetLessThanData =>
        new List<(bool, uint, uint)>
        {
            { (true, BaseValue, MinValue) },
            { (true, BaseValue, BaseValue) },
            { (false, BaseValue, MaxValue) },
        };

    public static IEnumerable<(bool, uint, uint)> GetLessThanOrEqualData =>
        new List<(bool, uint, uint)>
        {
            { (true, BaseValue, MinValue) },
            { (false, BaseValue, BaseValue) },
            { (false, BaseValue, MaxValue) },
        };

#if NET6_0_OR_GREATER
    [Test]
    [MethodDataSource(nameof(GetNotPow2Data))]
    public void NotPow2_Theory_Expected(bool throwException, uint value)
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

    public static IEnumerable<(bool, uint)> GetNotPow2Data => new List<(bool, uint)> { (true, 63), (false, 64) };
#endif
}
