﻿namespace NetEvolve.Guard;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NetEvolve.Arguments;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if <paramref name="value"/> is not <see langword="null"/> and has elements.
    /// </summary>
    /// <typeparam name="T">Unrestricted type</typeparam>
    /// <param name="value">Value to be verified.</param>
    /// <returns>Returns <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">When <paramref name="value"/> has no elements.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static EnsureContext<IEnumerable<T>> IsNotNullOrEmpty<T>(in this EnsureContext<IEnumerable<T>?> value)
    {
        Argument.ThrowIfNull(value.Value, value.ParameterName);

        if (!value.Value.Any())
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return new EnsureContext<IEnumerable<T>>(value.Value!, value.ParameterName);
    }

    /// <summary>
    /// Determines if <paramref name="value"/> is not <see langword="null"/> and has elements.
    /// </summary>
    /// <typeparam name="TEnumerable"><see cref="IEnumerable{T}"/> compatible type.</typeparam>
    /// <typeparam name="TValue">Unrestricted type</typeparam>
    /// <param name="value">Value to be verified.</param>
    /// <returns>Returns <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">When <paramref name="value"/> has no elements.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static EnsureContext<TEnumerable> IsNotNullOrEmpty<TEnumerable, TValue>(
        in this EnsureContext<TEnumerable?> value
    )
        where TEnumerable : IEnumerable<TValue>
    {
        Argument.ThrowIfNull(value.Value, value.ParameterName);

        if (!value.Value.Any())
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return new EnsureContext<TEnumerable>(value.Value!, value.ParameterName);
    }
}
