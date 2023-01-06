#if NET5_0 || NET6_0
namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if the <paramref name="value"/> corresponds to infinity or not.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <exception cref="ArgumentException">When <paramref name="value"/> is infinity, then a <see cref="ArgumentException"/> is raised.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<Half> IsNotInfinity(in this EnsureContext<Half> value)
    {
        if (Half.IsInfinity(value.Value))
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return ref value;
    }
}
#endif
