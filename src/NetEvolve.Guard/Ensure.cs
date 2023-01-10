namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

/// <summary>
/// Allows the validation of arguments and parameters
/// </summary>
public static class Ensure
{
    /// <summary>
    /// Returns an <see cref="SecureContext{T}"/> instance, that can be used to validate the <paramref name="value"/>.
    /// </summary>
    /// <typeparam name="T">Type of <paramref name="value"/>.</typeparam>
    /// <param name="value">Value to be verified.</param>
    /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
    /// <returns><see cref="SecureContext{T}"/> for further validations.</returns>
    /// <exception cref="ArgumentNullException">Whenn <paramref name="parameterName"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Whenn <paramref name="parameterName"/> is <see cref="string.Empty"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static SecureContext<T?> That<T>(
        T? value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = default!
    ) where T : class
    {
#if NET7_0_OR_GREATER
        ArgumentException.ThrowIfNullOrEmpty(parameterName);
#else
        if (parameterName is null)
        {
            throw new ArgumentNullException(nameof(parameterName));
        }
        if (string.IsNullOrEmpty(parameterName))
        {
            throw new ArgumentException(null, nameof(parameterName));
        }
#endif
        return new SecureContext<T?>(value, parameterName!);
    }

    /// <summary>
    /// Returns an <see cref="SecureContext{T}"/> instance, that can be used to validate the <paramref name="value"/>.
    /// </summary>
    /// <typeparam name="T">Type of <paramref name="value"/>.</typeparam>
    /// <param name="value">Value to be verified.</param>
    /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
    /// <returns><see cref="SecureContext{T}"/> for further validations.</returns>
    /// <exception cref="ArgumentNullException">Whenn <paramref name="parameterName"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Whenn <paramref name="parameterName"/> is <see cref="string.Empty"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static SecureContext<T> That<T>(
        in T value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = default!
    ) where T : struct
    {
#if NET7_0_OR_GREATER
        ArgumentException.ThrowIfNullOrEmpty(parameterName);
#else
        if (parameterName is null)
        {
            throw new ArgumentNullException(nameof(parameterName));
        }
        if (string.IsNullOrEmpty(parameterName))
        {
            throw new ArgumentException(null, nameof(parameterName));
        }
#endif

        return new SecureContext<T>(in value, parameterName!);
    }

    /// <summary>
    /// Returns an <see cref="SecureContext{T}"/> instance, that can be used to validate the <paramref name="value"/>.
    /// </summary>
    /// <typeparam name="T">Type of <paramref name="value"/>.</typeparam>
    /// <param name="value">Value to be verified.</param>
    /// <param name="parameterName">Optional parameter, this is filled in with the <see cref="CallerArgumentExpressionAttribute"/> mechanism and doesn't need to be set manually.</param>
    /// <returns><see cref="SecureContext{T}"/> for further validations.</returns>
    /// <exception cref="ArgumentNullException">Whenn <paramref name="parameterName"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Whenn <paramref name="parameterName"/> is <see cref="string.Empty"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static SecureContext<T?> That<T>(
        in T? value,
        [CallerArgumentExpression(nameof(value))] string? parameterName = default!
    ) where T : struct
    {
#if NET7_0_OR_GREATER
        ArgumentException.ThrowIfNullOrEmpty(parameterName);
#else
        if (parameterName is null)
        {
            throw new ArgumentNullException(nameof(parameterName));
        }
        if (string.IsNullOrEmpty(parameterName))
        {
            throw new ArgumentException(null, nameof(parameterName));
        }
#endif

        return new SecureContext<T?>(in value, parameterName!);
    }
}
