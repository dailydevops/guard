using NetEvolve.Guard;

namespace NetEvolve.Guard.Tests.Unit;

using NetEvolve.Guard;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

[ExcludeFromCodeCoverage]
public sealed class EnsureUInt8Tests
{
    private static byte BaseValue { get; } = 1;
    private static byte MaxValue { get; } = byte.MaxValue;
    private static byte MinValue { get; } = byte.MinValue;

    [Theory]
    [MemberData(nameof(GetInBetweenData))]
    public void InBetween_Theory_Expected(bool throwException, byte value, byte min, byte max)
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
    public void NotBetween_Theory_Expected(bool throwException, byte value, byte min, byte max)
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
    public void GreaterThan_Theory_Expected(bool throwException, byte value, byte compareValue)
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
        byte value,
        byte compareValue
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
    public void LessThan_Theory_Expected(bool throwException, byte value, byte compareValue)
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
    public void LessThanOrEqual_Theory_Expected(bool throwException, byte value, byte compareValue)
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
        new TheoryData<bool, byte, byte, byte>
        {
            { true, MinValue, BaseValue, MaxValue },
            { true, MaxValue, BaseValue, MinValue },
            { false, MinValue, MinValue, MaxValue },
            { false, MaxValue, MinValue, MaxValue },
            { false, BaseValue, MinValue, MaxValue },
            { false, BaseValue, MaxValue, MinValue }
        };

    public static TheoryData GetNotBetweenData =>
        new TheoryData<bool, byte, byte, byte>
        {
            { false, MinValue, BaseValue, MaxValue },
            { false, MaxValue, BaseValue, MinValue },
            { true, BaseValue, MinValue, MaxValue },
            { true, BaseValue, MaxValue, MinValue }
        };

    public static TheoryData GetGreaterThanData =>
        new TheoryData<bool, byte, byte>
        {
            { true, BaseValue, MaxValue },
            { true, BaseValue, BaseValue },
            { false, BaseValue, MinValue }
        };

    public static TheoryData GetGreaterThanOrEqualData =>
        new TheoryData<bool, byte, byte>
        {
            { true, BaseValue, MaxValue },
            { false, BaseValue, BaseValue },
            { false, BaseValue, MinValue }
        };

    public static TheoryData GetLessThanData =>
        new TheoryData<bool, byte, byte>
        {
            { true, BaseValue, MinValue },
            { true, BaseValue, BaseValue },
            { false, BaseValue, MaxValue }
        };

    public static TheoryData GetLessThanOrEqualData =>
        new TheoryData<bool, byte, byte>
        {
            { true, BaseValue, MinValue },
            { false, BaseValue, BaseValue },
            { false, BaseValue, MaxValue }
        };

#if NET6_0_OR_GREATER
    [Theory]
    [MemberData(nameof(GetNotPow2Data))]
    public void NotPow2_Theory_Expected(bool throwException, byte value)
    {
        if (throwException)
        {
            _ = Assert.Throws<ArgumentException>(
                nameof(value),
                () => _ = Ensure.That(value).IsPow2()
            );
        }
        else
        {
            _ = Ensure.That(value).IsPow2();
        }
    }

    public static TheoryData GetNotPow2Data =>
        new TheoryData<bool, byte> { { true, 63 }, { false, 64 } };
#endif
}
