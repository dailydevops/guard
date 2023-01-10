namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if <paramref name="value"/> is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <returns>A non-<see langword="null"/> <see cref="string"/>.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">When <paramref name="value"/> is <see cref="string.Empty"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static EnsureContext<string> IsNotNullOrEmpty(in this EnsureContext<string?> value)
    {
        Parameter.NotNullOrEmpty(value.Value, value.ParameterName);

        return new EnsureContext<string>(value.Value, value.ParameterName);
    }
}
