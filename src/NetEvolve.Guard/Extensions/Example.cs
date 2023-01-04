#if EXAMPLE
namespace NetEvolve.Guard;

using System.Diagnostics;

public partial class SecureContextExtensions
{
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly SecureContext<T> Example<T>(in this SecureContext<T> value)
    {
        return ref value;
    }
}
#endif
