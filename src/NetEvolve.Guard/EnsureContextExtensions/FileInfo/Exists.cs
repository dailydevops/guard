namespace NetEvolve.Guard;

using System.Diagnostics;
using System.IO;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if <paramref name="value"/> exists.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <exception cref="FileNotFoundException">When <paramref name="value"/> not exists.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<FileInfo> Exists(in this EnsureContext<FileInfo> value)
    {
        if (!value.Value.Exists)
        {
            throw new FileNotFoundException(null, value.ParameterName);
        }

        return ref value;
    }
}
