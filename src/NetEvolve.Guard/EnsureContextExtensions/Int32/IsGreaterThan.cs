#if !NET7_0_OR_GREATER

namespace NetEvolve.Guard;

using NetEvolve.Arguments;
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
    public static ref readonly EnsureContext<int> IsGreaterThan(
        in this EnsureContext<int> value,
        int compareValue
    )
    {
        Argument.ThrowIfLessThanOrEqual(value.Value, compareValue, value.ParameterName);

        return ref value;
    }
}
#endif
