namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using NetEvolve.Extensions.TUnit;
using NetEvolve.Guard;

[ExcludeFromCodeCoverage]
[UnitTest]
public sealed class EnsureDoubleTests
{
    private static double BaseValue { get; }
    private static double MaxValue { get; } = double.MaxValue;
    private static double MinValue { get; } = double.MinValue;
    private static double NaN { get; } = double.NaN;
    private static double NegativeInfinity { get; } = double.NegativeInfinity;
    private static double PositiveInfinity { get; } = double.PositiveInfinity;

    [Test]
    [MethodDataSource(nameof(GetInBetweenData))]
    public void InBetween_Theory_Expected(bool throwException, double value, double min, double max)
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
    public void NotBetween_Theory_Expected(bool throwException, double value, double min, double max)
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
    public void GreaterThan_Theory_Expected(bool throwException, double value, double compareValue)
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
    public void GreaterThanOrEqual_Theory_Expected(bool throwException, double value, double compareValue)
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
    public void LessThan_Theory_Expected(bool throwException, double value, double compareValue)
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
    public void LessThanOrEqual_Theory_Expected(bool throwException, double value, double compareValue)
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
    public void NotNaN_Theory_Expected(bool throwException, double value)
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
    public void NotInfinity_Theory_Expected(bool throwException, double value)
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
    public void NotNegativeInfinity_Theory_Expected(bool throwException, double value)
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
    public void NotPositiveInfinity_Theory_Expected(bool throwException, double value)
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

    public static TheoryData<bool, double, double, double> GetInBetweenData =>
        new TheoryData<bool, double, double, double>
        {
            { true, MinValue, BaseValue, MaxValue },
            { true, MaxValue, BaseValue, MinValue },
            { false, MinValue, MinValue, MaxValue },
            { false, MaxValue, MinValue, MaxValue },
            { false, BaseValue, MinValue, MaxValue },
            { false, BaseValue, MaxValue, MinValue },
        };

    public static TheoryData<bool, double, double, double> GetNotBetweenData =>
        new TheoryData<bool, double, double, double>
        {
            { false, MinValue, BaseValue, MaxValue },
            { false, MaxValue, BaseValue, MinValue },
            { true, BaseValue, MinValue, MaxValue },
            { true, BaseValue, MaxValue, MinValue },
        };

    public static TheoryData<bool, double, double> GetGreaterThanData =>
        new TheoryData<bool, double, double>
        {
            { true, BaseValue, MaxValue },
            { true, BaseValue, BaseValue },
            { false, BaseValue, MinValue },
        };

    public static TheoryData<bool, double, double> GetGreaterThanOrEqualData =>
        new TheoryData<bool, double, double>
        {
            { true, BaseValue, MaxValue },
            { false, BaseValue, BaseValue },
            { false, BaseValue, MinValue },
        };

    public static TheoryData<bool, double, double> GetLessThanData =>
        new TheoryData<bool, double, double>
        {
            { true, BaseValue, MinValue },
            { true, BaseValue, BaseValue },
            { false, BaseValue, MaxValue },
        };

    public static TheoryData<bool, double, double> GetLessThanOrEqualData =>
        new TheoryData<bool, double, double>
        {
            { true, BaseValue, MinValue },
            { false, BaseValue, BaseValue },
            { false, BaseValue, MaxValue },
        };

    public static TheoryData<bool, double> GetNotNaNData =>
        new TheoryData<bool, double>
        {
            { true, NaN },
            { false, BaseValue },
            { false, MaxValue },
            { false, MinValue },
        };

    public static TheoryData<bool, double> GetNotInfinityData =>
        new TheoryData<bool, double>
        {
            { true, PositiveInfinity },
            { true, NegativeInfinity },
            { false, MaxValue },
            { false, MinValue },
        };

    public static TheoryData<bool, double> GetNotNegativeInfinityData =>
        new TheoryData<bool, double>
        {
            { false, PositiveInfinity },
            { true, NegativeInfinity },
            { false, MaxValue },
            { false, MinValue },
        };

    public static TheoryData<bool, double> GetNotPositiveInfinityData =>
        new TheoryData<bool, double>
        {
            { true, PositiveInfinity },
            { false, NegativeInfinity },
            { false, MaxValue },
            { false, MinValue },
        };
}
