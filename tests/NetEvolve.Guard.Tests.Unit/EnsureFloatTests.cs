namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using NetEvolve.Extensions.XUnit;
using NetEvolve.Guard;
using Xunit;

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

    [Theory]
    [MemberData(nameof(GetInBetweenData))]
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

    [Theory]
    [MemberData(nameof(GetNotBetweenData))]
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

    [Theory]
    [MemberData(nameof(GetGreaterThanData))]
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

    [Theory]
    [MemberData(nameof(GetGreaterThanOrEqualData))]
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

    [Theory]
    [MemberData(nameof(GetLessThanData))]
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

    [Theory]
    [MemberData(nameof(GetLessThanOrEqualData))]
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

    [Theory]
    [MemberData(nameof(GetNotNaNData))]
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

    [Theory]
    [MemberData(nameof(GetNotInfinityData))]
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

    [Theory]
    [MemberData(nameof(GetNotNegativeInfinityData))]
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

    [Theory]
    [MemberData(nameof(GetNotPositiveInfinityData))]
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

    public static TheoryData<bool, float, float, float> GetInBetweenData =>
        new TheoryData<bool, float, float, float>
        {
            { true, MinValue, BaseValue, MaxValue },
            { true, MaxValue, BaseValue, MinValue },
            { false, MinValue, MinValue, MaxValue },
            { false, MaxValue, MinValue, MaxValue },
            { false, BaseValue, MinValue, MaxValue },
            { false, BaseValue, MaxValue, MinValue },
        };

    public static TheoryData<bool, float, float, float> GetNotBetweenData =>
        new TheoryData<bool, float, float, float>
        {
            { false, MinValue, BaseValue, MaxValue },
            { false, MaxValue, BaseValue, MinValue },
            { true, BaseValue, MinValue, MaxValue },
            { true, BaseValue, MaxValue, MinValue },
        };

    public static TheoryData<bool, float, float> GetGreaterThanData =>
        new TheoryData<bool, float, float>
        {
            { true, BaseValue, MaxValue },
            { true, BaseValue, BaseValue },
            { false, BaseValue, MinValue },
        };

    public static TheoryData<bool, float, float> GetGreaterThanOrEqualData =>
        new TheoryData<bool, float, float>
        {
            { true, BaseValue, MaxValue },
            { false, BaseValue, BaseValue },
            { false, BaseValue, MinValue },
        };

    public static TheoryData<bool, float, float> GetLessThanData =>
        new TheoryData<bool, float, float>
        {
            { true, BaseValue, MinValue },
            { true, BaseValue, BaseValue },
            { false, BaseValue, MaxValue },
        };

    public static TheoryData<bool, float, float> GetLessThanOrEqualData =>
        new TheoryData<bool, float, float>
        {
            { true, BaseValue, MinValue },
            { false, BaseValue, BaseValue },
            { false, BaseValue, MaxValue },
        };

    public static TheoryData<bool, float> GetNotNaNData =>
        new TheoryData<bool, float>
        {
            { true, NaN },
            { false, BaseValue },
            { false, MaxValue },
            { false, MinValue },
        };

    public static TheoryData<bool, float> GetNotInfinityData =>
        new TheoryData<bool, float>
        {
            { true, PositiveInfinity },
            { true, NegativeInfinity },
            { false, MaxValue },
            { false, MinValue },
        };

    public static TheoryData<bool, float> GetNotNegativeInfinityData =>
        new TheoryData<bool, float>
        {
            { false, PositiveInfinity },
            { true, NegativeInfinity },
            { false, MaxValue },
            { false, MinValue },
        };

    public static TheoryData<bool, float> GetNotPositiveInfinityData =>
        new TheoryData<bool, float>
        {
            { true, PositiveInfinity },
            { false, NegativeInfinity },
            { false, MaxValue },
            { false, MinValue },
        };
}
