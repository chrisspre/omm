
namespace Csdl.Graph;

public partial record struct NodeDef(string Url, string Doc, Property[] Properties, Association[] Associations, Element[] Elements)
{
    public readonly void Deconstruct(out string doc, out Property[] properties, out Association[] associations, out Element[] elements)
    {
        doc = Doc;
        properties = Properties ?? [];
        associations = Associations ?? [];
        elements = Elements ?? [];
    }
}


