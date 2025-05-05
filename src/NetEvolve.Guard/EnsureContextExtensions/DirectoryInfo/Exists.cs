namespace NetEvolve.Guard;

using System.Diagnostics;
using System.IO;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if <paramref name="value"/> exists.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <exception cref="DirectoryNotFoundException">When <paramref name="value"/> not exists.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<DirectoryInfo> Exists(in this EnsureContext<DirectoryInfo> value)
    {
        if (!value.Value.Exists)
        {
            throw new DirectoryNotFoundException();
        }

        return ref value;
    }
}
