namespace NetEvolve.Guard;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public partial class EnsureContextExtensions
{
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static EnsureContext<IEnumerable<T>> IsNotNullOrEmpty<T>(
        in this EnsureContext<IEnumerable<T>?> value
    )
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(value.Value, value.ParameterName);
#else
        if (value.Value is null)
        {
            throw new ArgumentNullException(value.ParameterName);
        }
#endif

        if (!value.Value.Any())
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return new EnsureContext<IEnumerable<T>>(value.Value!, value.ParameterName);
    }

    [DebuggerStepThrough]
    [StackTraceHidden]
    public static EnsureContext<TEnumerable> IsNotNullOrEmpty<TEnumerable, TValue>(
        in this EnsureContext<TEnumerable?> value
    ) where TEnumerable : IEnumerable<TValue>
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(value.Value, value.ParameterName);
#else
        if (value.Value is null)
        {
            throw new ArgumentNullException(value.ParameterName);
        }
#endif

        if (!value.Value.Any())
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return new EnsureContext<TEnumerable>(value.Value!, value.ParameterName);
    }
}
