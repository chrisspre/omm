
namespace Csdl.Graph;

public partial record Property(string Name, PropertyType Type, bool IsRequired)
{
    public static implicit operator (string Name, PropertyType Type, bool IsRequired)(Property value)
    {
        return (value.Name, value.Type, value.IsRequired);
    }

    public static implicit operator Property((string Name, PropertyType Type, bool IsRequired) value)
    {
        return new Property(value.Name, value.Type, value.IsRequired);
    }

    public static implicit operator Property(string Name)
    {
        return new Property(Name, PropertyType.String, true);
    }
}

