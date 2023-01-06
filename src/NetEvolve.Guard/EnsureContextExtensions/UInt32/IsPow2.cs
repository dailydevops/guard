#if NET6_0

namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Numerics;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if a <paramref name="value"/> is a power of two.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <returns>Returns <paramref name="value"/>, if a power of two.</returns>
    /// <exception cref="ArgumentException">When <paramref name="value"/> is not a power of two.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<uint> IsPow2(in this EnsureContext<uint> value)
    {
        if (!BitOperations.IsPow2(value.Value))
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return ref value;
    }
}
#endif
