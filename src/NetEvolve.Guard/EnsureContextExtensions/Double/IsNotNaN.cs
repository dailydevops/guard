#if !NET7_0_OR_GREATER
namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if the <paramref name="value"/> is not a number or not.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <exception cref="ArgumentException">When <paramref name="value"/> is not a number, then a <see cref="ArgumentException"/> is raised.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<double> IsNotNaN(in this EnsureContext<double> value)
    {
        if (double.IsNaN(value.Value))
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return ref value;
    }
}
#endif
