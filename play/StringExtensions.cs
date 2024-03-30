namespace play;

/// <summary>
/// Provides extension methods for working with strings.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Concatenates the elements of a string collection, using the specified separator between each element.
    /// </summary>
    /// <param name="strings">The collection of strings to join.</param>
    /// <param name="separator">The string to use as a separator.</param>
    /// <returns>A string that consists of the elements of the collection joined by the separator.</returns>
    public static string Join(this IEnumerable<string> strings, string separator) => string.Join(separator, strings);
}
