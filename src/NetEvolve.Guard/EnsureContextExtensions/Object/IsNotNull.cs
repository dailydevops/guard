namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if <paramref name="value"/> is <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">Type of <see langword="object"/>.</typeparam>
    /// <param name="value">Value to be verified.</param>
    /// <returns>A non-<see langword="null"/> <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static EnsureContext<T> IsNotNull<T>(in this EnsureContext<T?> value) where T : class
    {
        Parameter.NotNull(value.Value, value.ParameterName);

        return new EnsureContext<T>(value.Value!, value.ParameterName);
    }
}
