namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if <paramref name="value"/> is not <see langword="null"/> or whitespace.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <returns>A non-<see langword="null"/> <see cref="string"/>.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">When <paramref name="value"/> is <see cref="string.Empty"/> or whitespace.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static EnsureContext<string> IsNotNullOrWhiteSpace(in this EnsureContext<string?> value)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(value.Value, value.ParameterName);
#else
        if (value.Value is null)
        {
            throw new ArgumentNullException(value.ParameterName);
        }
#endif
        if (IsWhiteSpace(value.Value))
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return new EnsureContext<string>(value.Value, value.ParameterName);
    }

    [DebuggerStepThrough]
    [StackTraceHidden]
    private static bool IsWhiteSpace(string value)
    {
        for (var i = 0; i < value.Length; i++)
        {
            if (!char.IsWhiteSpace(value[i]))
            {
                return false;
            }
        }

        return true;
    }
}
