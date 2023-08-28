#if !NET7_0_OR_GREATER

namespace NetEvolve.Guard;

using NetEvolve.Arguments;
using System;
using System.Diagnostics;
using System.Numerics;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if <paramref name="value"/> is less than or equal to <paramref name="compareValue"/>.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <param name="compareValue">The value to be used for comparison.</param>
    /// <returns>Returns <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is greater than <paramref name="compareValue"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<BigInteger> IsLessThanOrEqual(
        in this EnsureContext<BigInteger> value,
        BigInteger compareValue
    )
    {
        Argument.ThrowIfGreaterThan(value.Value, compareValue, value.ParameterName);

        return ref value;
    }
}
#endif
