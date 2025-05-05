#if !NET7_0_OR_GREATER
namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if the <paramref name="value"/> corresponds to negative infinity or not.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <exception cref="ArgumentException">When <paramref name="value"/> is negative infinity, then a <see cref="ArgumentException"/> is raised.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<double> IsNotPositiveInfinity(in this EnsureContext<double> value)
    {
        if (double.IsPositiveInfinity(value.Value))
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return ref value;
    }
}
#endif
