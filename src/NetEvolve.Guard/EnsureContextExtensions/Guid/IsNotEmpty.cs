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
    public static ref readonly EnsureContext<Guid> IsNotEmpty(in this EnsureContext<Guid> value)
    {
        if (value.Value == Guid.Empty)
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return ref value;
    }
}
