#if NET6_0_OR_GREATER

namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if <paramref name="value"/> is greater than <paramref name="compareValue"/>.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <param name="compareValue">The value to be used for comparison.</param>
    /// <returns>Returns <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is greater than <paramref name="compareValue"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<DateOnly> IsGreaterThan(
        in this EnsureContext<DateOnly> value,
        DateOnly compareValue
    )
    {
        if (value.Value <= compareValue)
        {
            throw new ArgumentOutOfRangeException(value.ParameterName, value.Value, null);
        }

        return ref value;
    }
}
#endif
