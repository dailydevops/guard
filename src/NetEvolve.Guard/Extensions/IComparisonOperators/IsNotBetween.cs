#if NET7_0_OR_GREATER

namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Numerics;

public partial class SecureContextExtensions
{
    /// <summary>
    /// Determines if <paramref name="value"/> is not in between <paramref name="minValue"/> and <paramref name="maxValue"/>.
    /// </summary>
    /// <typeparam name="T"><see cref="IComparisonOperators{TSelf, TOther, TResult}"/> compatible type.</typeparam>
    /// <param name="value">Value to be verified.</param>
    /// <param name="minValue">The minimal value for the comparison.</param>
    /// <param name="maxValue">The maximal value for the comparison.</param>
    /// <returns>Returns <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is not between <paramref name="minValue"/> and <paramref name="maxValue"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly SecureContext<T> IsNotBetween<T>(
        in this SecureContext<T> value,
        T minValue,
        T maxValue
    ) where T : IComparisonOperators<T, T, bool>
    {
        if ((minValue <= value.Value) == (value.Value <= maxValue))
        {
            throw new ArgumentOutOfRangeException(value.ParameterName, value.Value, null);
        }

        return ref value;
    }
}
#endif
