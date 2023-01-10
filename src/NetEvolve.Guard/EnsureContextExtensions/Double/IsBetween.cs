#if !NET7_0_OR_GREATER

namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if <paramref name="value"/> is in between <paramref name="minValue"/> and <paramref name="maxValue"/>.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <param name="minValue">The minimal value for the comparison.</param>
    /// <param name="maxValue">The maximal value for the comparison.</param>
    /// <returns>Returns <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is not between <paramref name="minValue"/> and <paramref name="maxValue"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<double> IsBetween(
        in this EnsureContext<double> value,
        double minValue,
        double maxValue
    )
    {
        if ((minValue <= value.Value) != (value.Value <= maxValue))
        {
            throw new ArgumentOutOfRangeException(value.ParameterName, value.Value, null);
        }

        return ref value;
    }
}
#endif
