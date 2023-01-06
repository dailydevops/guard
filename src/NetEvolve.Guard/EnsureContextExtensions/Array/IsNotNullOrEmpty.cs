namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class EnsureContextExtensions
{
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static EnsureContext<T[]> IsNotNullOrEmpty<T>(in this EnsureContext<T[]?> value)
    {
        Parameter.NotNull(value.Value, value.ParameterName);

        if (value.Value.Length == 0)
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return new EnsureContext<T[]>(value.Value, value.ParameterName);
    }
}
