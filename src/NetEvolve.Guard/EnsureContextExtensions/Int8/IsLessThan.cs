#if !NET7_0_OR_GREATER

namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using NetEvolve.Arguments;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if <paramref name="value"/> is less than <paramref name="compareValue"/>.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <param name="compareValue">The value to be used for comparison.</param>
    /// <returns>Returns <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is greater than <paramref name="compareValue"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<byte> IsLessThan(
        in this EnsureContext<byte> value,
        byte compareValue
    )
    {
        Argument.ThrowIfGreaterThanOrEqual(value.Value, compareValue, value.ParameterName);

        return ref value;
    }
}
#endif
