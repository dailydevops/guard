namespace NetEvolve.Guard;

public readonly ref struct SecureContext<T>
{
    internal T Value { get; }
    internal string ParameterName { get; }

    internal SecureContext(T value, string parameterName)
    {
        Value = value;
        ParameterName = parameterName;
    }

    internal SecureContext(in T value, string parameterName)
    {
        Value = value;
        ParameterName = parameterName;
    }

    /// <summary>Gets the value of an argument.</summary>
    /// <param name="context">The argument whose value to return.</param>
    /// <returns><see cref="Value" />.</returns>
    public static implicit operator T(SecureContext<T> context) => context.Value;
}
