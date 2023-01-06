namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class EnsureContextExtensions
{
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static EnsureContext<T[]> IsNotNullOrEmpty<T>(in this EnsureContext<T[]?> value)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(value.Value, value.ParameterName);
#else
        if (value.Value is null)
        {
            throw new ArgumentNullException(value.ParameterName);
        }
#endif

        if (value.Value.Length == 0)
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return new EnsureContext<T[]>(value.Value, value.ParameterName);
    }
}
