namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class SecureContextExtensions
{
    /// <summary>
    /// Determines if the <paramref name="value"/> is <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">Type of <see langword="struct"/>.</typeparam>
    /// <param name="value">Value to be verified.</param>
    /// <returns>A not-null <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static SecureContext<T> IsNotNull<T>(in this SecureContext<T?> value) where T : struct
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(value.Value, value.ParameterName);
#else
        if (value.Value is null)
        {
            throw new ArgumentNullException(value.ParameterName);
        }
#endif

        return new SecureContext<T>(value.Value.Value, value.ParameterName);
    }
}
