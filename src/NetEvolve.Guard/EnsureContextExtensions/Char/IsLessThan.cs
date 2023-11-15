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
    [StackTraceHidden]
    public static ref readonly EnsureContext<char> IsLessThan(
        in this EnsureContext<char> value,
        char compareValue
    )
    {
        Argument.ThrowIfGreaterThanOrEqual(value.Value, compareValue, value.ParameterName);

        return ref value;
    }
}
#endif
