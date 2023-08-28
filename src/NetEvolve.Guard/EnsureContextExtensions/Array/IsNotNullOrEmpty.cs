namespace NetEvolve.Guard;

using NetEvolve.Arguments;
using System;
using System.Diagnostics;

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
    public static EnsureContext<T[]> IsNotNullOrEmpty<T>(in this EnsureContext<T[]?> value)
    {
        Argument.ThrowIfNull(value.Value, value.ParameterName);

        if (value.Value.Length == 0)
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return new EnsureContext<T[]>(value.Value, value.ParameterName);
    }
}
