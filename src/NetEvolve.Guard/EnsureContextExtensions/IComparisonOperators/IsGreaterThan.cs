#if NET7_0_OR_GREATER

namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Numerics;
using NetEvolve.Arguments;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if <paramref name="value"/> is greater than <paramref name="compareValue"/>.
    /// </summary>
    /// <typeparam name="T"><see cref="IComparisonOperators{TSelf, TOther, TResult}"/> compatible type.</typeparam>
    /// <param name="value">Value to be verified.</param>
    /// <param name="compareValue">The value to be used for comparison.</param>
    /// <returns>Returns <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is greater than <paramref name="compareValue"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<T> IsGreaterThan<T>(in this EnsureContext<T> value, T compareValue)
        where T : IComparisonOperators<T, T, bool>, IComparable<T>
    {
        Argument.ThrowIfLessThanOrEqual(value.Value, compareValue, value.ParameterName);

        return ref value;
    }
}
#endif
