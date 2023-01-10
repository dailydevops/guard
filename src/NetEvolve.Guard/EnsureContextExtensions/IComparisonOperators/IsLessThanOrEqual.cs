#if NET7_0_OR_GREATER

namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Numerics;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if <paramref name="value"/> is less than or equal to <paramref name="compareValue"/>.
    /// </summary>
    /// <typeparam name="T"><see cref="IComparisonOperators{TSelf, TOther, TResult}"/> compatible type.</typeparam>
    /// <param name="value">Value to be verified.</param>
    /// <param name="compareValue">The value to be used for comparison.</param>
    /// <returns>Returns <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is greater than <paramref name="compareValue"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<T> IsLessThanOrEqual<T>(
        in this EnsureContext<T> value,
        T compareValue
    ) where T : IComparisonOperators<T, T, bool>
    {
        if (value.Value > compareValue)
        {
            throw new ArgumentOutOfRangeException(value.ParameterName, value.Value, null);
        }

        return ref value;
    }
}
#endif
