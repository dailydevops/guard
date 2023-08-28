namespace NetEvolve.Guard;

using NetEvolve.Arguments;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Validates <paramref name="value"/> with the <paramref name="condition"/>. If <see langword="false"/>, an <see cref="ArgumentException"/> is raised.
    /// </summary>
    /// <typeparam name="T">Type to be checked.</typeparam>
    /// <param name="value">Value to be verified.</param>
    /// <param name="condition">Validation expression for checking the type.</param>
    /// <param name="conditionAsString">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
    /// <returns>Returns <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="condition"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">When <paramref name="condition"/> returns <see langword="false"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<T> Validate<T>(
        in this EnsureContext<T> value,
        [NotNull] Func<T, bool> condition,
        [CallerArgumentExpression(nameof(condition))] string conditionAsString = default!
    )
    {
        Argument.ThrowIfNull(condition);

        if (!condition.Invoke(value.Value))
        {
            throw new ArgumentException(
                string.IsNullOrWhiteSpace(conditionAsString)
                    ? "Condition failed"
                    : $"Condition failed: '{conditionAsString}'",
                value.ParameterName
            );
        }

        return ref value;
    }
}
