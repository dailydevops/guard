namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if a value is <see cref="Guid.Empty"/>.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <exception cref="ArgumentException">When <paramref name="value"/> is <see cref="Guid.Empty"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static EnsureContext<Guid> IsNotNullOrEmpty(in this EnsureContext<Guid?> value)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(value.Value, value.ParameterName);
#else
        if (value.Value is null)
        {
            throw new ArgumentNullException(value.ParameterName);
        }
#endif

        if (value.Value.Value == Guid.Empty)
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return new EnsureContext<Guid>(value.Value.Value, value.ParameterName);
    }
}
