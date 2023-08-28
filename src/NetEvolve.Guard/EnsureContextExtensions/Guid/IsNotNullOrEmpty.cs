namespace NetEvolve.Guard;

using NetEvolve.Arguments;
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
        Argument.ThrowIfNull(value.Value, value.ParameterName);

        if (value.Value.Value == Guid.Empty)
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return new EnsureContext<Guid>(value.Value.Value, value.ParameterName);
    }
}
