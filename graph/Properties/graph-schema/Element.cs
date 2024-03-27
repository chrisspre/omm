
namespace Csdl.Graph;

/// <summary>
/// Represents a (child, owned) element in a labeled property graph schema.
/// </summary>
public sealed partial record Element(string Name, string[] Types)
{
    /// <summary>
    /// Implicitly converts an <see cref="Element"/> to a tuple of <see cref="Name"/> and <see cref="Types"/>.
    /// </summary>
    /// <param name="value">The <see cref="Element"/> to convert.</param>
    /// <returns>A tuple representing the <see cref="Element"/>.</returns>
    public static implicit operator (string Name, string[] Types)(Element value)
    {
        return (value.Name, value.Types);
    }

    /// <summary>
    /// Implicitly converts a tuple of <see cref="Name"/> and <see cref="Types"/> to an <see cref="Element"/>.
    /// </summary>
    /// <param name="value">The tuple to convert.</param>
    /// <returns>An <see cref="Element"/> object.</returns>
    public static implicit operator Element((string Name, string[] Types) value)
    {
        return new Element(value.Name, value.Types);
    }
}

