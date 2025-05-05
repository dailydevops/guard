﻿#if NET7_0_OR_GREATER
namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Numerics;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if the <paramref name="value"/> corresponds to negative infinity or not.
    /// </summary>
    /// <typeparam name="T"><see cref="IFloatingPoint{TSelf}"/> compatible type.</typeparam>
    /// <param name="value">Value to be verified.</param>
    /// <exception cref="ArgumentException">When <paramref name="value"/> is negative infinity, then a <see cref="ArgumentException"/> is raised.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<T> IsNotNegativeInfinity<T>(in this EnsureContext<T> value)
        where T : IFloatingPoint<T>
    {
        if (T.IsNegativeInfinity(value.Value))
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return ref value;
    }
}
#endif
