#if NET5_0_OR_GREATER
namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using NetEvolve.Extensions.XUnit;
using NetEvolve.Guard;
using Xunit;

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

    [Theory]
    [MemberData(nameof(GetInBetweenData))]
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

    [Theory]
    [MemberData(nameof(GetNotBetweenData))]
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

    [Theory]
    [MemberData(nameof(GetGreaterThanData))]
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

    [Theory]
    [MemberData(nameof(GetGreaterThanOrEqualData))]
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

    [Theory]
    [MemberData(nameof(GetLessThanData))]
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

    [Theory]
    [MemberData(nameof(GetLessThanOrEqualData))]
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

    [Theory]
    [MemberData(nameof(GetNotNaNData))]
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

    [Theory]
    [MemberData(nameof(GetNotInfinityData))]
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

    [Theory]
    [MemberData(nameof(GetNotNegativeInfinityData))]
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

    [Theory]
    [MemberData(nameof(GetNotPositiveInfinityData))]
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

    public static TheoryData<bool, Half, Half, Half> GetInBetweenData =>
        new TheoryData<bool, Half, Half, Half>
        {
            { true, MinValue, BaseValue, MaxValue },
            { true, MaxValue, BaseValue, MinValue },
#if NET6_0_OR_GREATER
            // Known Issue for .NET 5 - https://github.com/dotnet/runtime/issues/49983
            { false, MinValue, MinValue, MaxValue },
#endif
            { false, MaxValue, MinValue, MaxValue },
            { false, BaseValue, MinValue, MaxValue },
            { false, BaseValue, MaxValue, MinValue },
        };

    public static TheoryData<bool, Half, Half, Half> GetNotBetweenData =>
        new TheoryData<bool, Half, Half, Half>
        {
            { false, MinValue, BaseValue, MaxValue },
            { false, MaxValue, BaseValue, MinValue },
            { true, BaseValue, MinValue, MaxValue },
            { true, BaseValue, MaxValue, MinValue },
        };

    public static TheoryData<bool, Half, Half> GetGreaterThanData =>
        new TheoryData<bool, Half, Half>
        {
            { true, BaseValue, MaxValue },
            { true, BaseValue, BaseValue },
            { false, BaseValue, MinValue },
        };

    public static TheoryData<bool, Half, Half> GetGreaterThanOrEqualData =>
        new TheoryData<bool, Half, Half>
        {
            { true, BaseValue, MaxValue },
            { false, BaseValue, BaseValue },
            { false, BaseValue, MinValue },
        };

    public static TheoryData<bool, Half, Half> GetLessThanData =>
        new TheoryData<bool, Half, Half>
        {
            { true, BaseValue, MinValue },
            { true, BaseValue, BaseValue },
            { false, BaseValue, MaxValue },
        };

    public static TheoryData<bool, Half, Half> GetLessThanOrEqualData =>
        new TheoryData<bool, Half, Half>
        {
            { true, BaseValue, MinValue },
            { false, BaseValue, BaseValue },
            { false, BaseValue, MaxValue },
        };

    public static TheoryData<bool, Half> GetNotNaNData =>
        new TheoryData<bool, Half>
        {
            { true, NaN },
            { false, BaseValue },
            { false, MaxValue },
            { false, MinValue },
        };

    public static TheoryData<bool, Half> GetNotInfinityData =>
        new TheoryData<bool, Half>
        {
            { true, PositiveInfinity },
            { true, NegativeInfinity },
            { false, MaxValue },
            { false, MinValue },
        };

    public static TheoryData<bool, Half> GetNotNegativeInfinityData =>
        new TheoryData<bool, Half>
        {
            { false, PositiveInfinity },
            { true, NegativeInfinity },
            { false, MaxValue },
            { false, MinValue },
        };

    public static TheoryData<bool, Half> GetNotPositiveInfinityData =>
        new TheoryData<bool, Half>
        {
            { true, PositiveInfinity },
            { false, NegativeInfinity },
            { false, MaxValue },
            { false, MinValue },
        };
}
#endif
