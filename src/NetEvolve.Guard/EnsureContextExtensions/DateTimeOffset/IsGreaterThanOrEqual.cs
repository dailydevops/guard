﻿namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using NetEvolve.Arguments;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if <paramref name="value"/> is greater than or equal to <paramref name="compareValue"/>.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <param name="compareValue">The value to be used for comparison.</param>
    /// <returns>Returns <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is greater than <paramref name="compareValue"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<DateTimeOffset> IsGreaterThanOrEqual(
        in this EnsureContext<DateTimeOffset> value,
        DateTimeOffset compareValue
    )
    {
        Argument.ThrowIfLessThan(value.Value, compareValue, value.ParameterName);

        return ref value;
    }
}
