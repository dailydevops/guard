namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if the <paramref name="value"/> is <see langword="null"/> or <see langword="default{T}"/>.
    /// </summary>
    /// <typeparam name="T">Type of <see langword="struct"/>.</typeparam>
    /// <param name="value">Value to be verified.</param>
    /// <returns>A not-null <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">When <paramref name="value"/> is <see langword="default{T}"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static EnsureContext<T> IsNotNullOrDefault<T>(in this EnsureContext<T?> value)
        where T : struct
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(value.Value, value.ParameterName);
#else
        if (value.Value is null)
        {
            throw new ArgumentNullException(value.ParameterName);
        }
#endif

        if (value.Value.Equals(default(T)))
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return new EnsureContext<T>(value.Value.Value, value.ParameterName);
    }
}
