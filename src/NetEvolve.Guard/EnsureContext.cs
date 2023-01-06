namespace NetEvolve.Guard;

using System.ComponentModel;

public readonly ref struct EnsureContext<T>
{
    internal T Value { get; }
    internal string ParameterName { get; }

    internal EnsureContext(T value, string parameterName)
    {
        Value = value;
        ParameterName = parameterName;
    }

    internal EnsureContext(in T value, string parameterName)
    {
        Value = value;
        ParameterName = parameterName;
    }

    /// <summary>Gets the value of an argument.</summary>
    /// <param name="context">The argument whose value to return.</param>
    /// <returns><see cref="Value" />.</returns>
    public static implicit operator T(EnsureContext<T> context) => context.Value;

    /// <summary>Gets the value of an argument.</summary>
    /// <returns><see cref="Value" />.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public T ToT() => Value;
}
