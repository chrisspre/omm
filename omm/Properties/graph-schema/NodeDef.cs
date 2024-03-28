
namespace Csdl.Graph;

public partial record struct NodeDef(string Url, string Description, Property[] Properties, Association[] Associations, Element[] Elements)
{
    public readonly void Deconstruct(out string doc, out Property[] properties, out Association[] associations, out Element[] elements)
    {
        doc = Description;
        properties = Properties ?? [];
        associations = Associations ?? [];
        elements = Elements ?? [];
    }
}


