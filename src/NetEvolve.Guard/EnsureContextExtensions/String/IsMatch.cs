namespace NetEvolve.Guard;

using NetEvolve.Arguments;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if the <paramref name="value"/> matches the regex <paramref name="pattern"/>.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <param name="pattern">The regular expression pattern to match.</param>
    /// <returns>Returns <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="pattern"/> is <see langword="null"/></exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> doesn't match the regex <paramref name="pattern"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<string> IsMatch(
        in this EnsureContext<string> value,
        [StringSyntax(StringSyntaxAttribute.Regex)] string pattern
    )
    {
        Argument.ThrowIfNull(pattern);

        if (!Regex.IsMatch(value.Value, pattern, RegexOptions.None, TimeSpan.FromMilliseconds(200)))
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return ref value;
    }

    /// <summary>
    /// Determines if the <paramref name="value"/> matches the regex <paramref name="pattern"/>.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <param name="pattern">The regular expression pattern to match.</param>
    /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
    /// <returns>Returns <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="pattern"/> is <see langword="null"/></exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> doesn't match the regex <paramref name="pattern"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<string> IsMatch(
        in this EnsureContext<string> value,
        [StringSyntax(StringSyntaxAttribute.Regex, nameof(options))] string pattern,
        RegexOptions options
    )
    {
        Argument.ThrowIfNull(value.Value, value.ParameterName);

        if (!Regex.IsMatch(value.Value, pattern, options, TimeSpan.FromMilliseconds(200)))
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return ref value;
    }
}
