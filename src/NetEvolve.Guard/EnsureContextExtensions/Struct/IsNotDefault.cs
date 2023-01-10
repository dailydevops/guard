namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if the <paramref name="value"/> is <see langword="default{T}"/>.
    /// </summary>
    /// <typeparam name="T">Type of <see langword="struct"/>.</typeparam>
    /// <param name="value">Value to be verified.</param>
    /// <exception cref="ArgumentException">When <paramref name="value"/> is <see langword="default{T}"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<T> IsNotDefault<T>(in this EnsureContext<T> value)
        where T : struct
    {
        if (value.Value.Equals(default(T)))
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return ref value;
    }
}
