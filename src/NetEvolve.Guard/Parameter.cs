namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

internal static class Parameter
{
    [DebuggerStepThrough]
    [StackTraceHidden]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage(
        "Style",
        "IDE0022:Use expression body for methods",
        Justification = "False Positive, because of preprocessor directives"
    )]
    public static void NotNull<T>(
        [NotNull] this T value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null
    )
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(value, parameterName);
#else
        if (value is null)
        {
            throw new ArgumentNullException(parameterName);
        }
#endif
    }

    [DebuggerStepThrough]
    [StackTraceHidden]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage(
        "Style",
        "IDE0022:Use expression body for methods",
        Justification = "False Positive, because of preprocessor directives"
    )]
    public static void NotNullOrEmpty(
        [NotNull] this string? value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = null
    )
    {
#if NET7_0_OR_GREATER
        ArgumentException.ThrowIfNullOrEmpty(value, parameterName);
#else
        if (value is null)
        {
            throw new ArgumentNullException(parameterName);
        }

        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException(null, parameterName);
        }
#endif
    }
}
