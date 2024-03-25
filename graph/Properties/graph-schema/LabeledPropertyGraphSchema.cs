
using System.Threading.Tasks.Dataflow;

namespace Csdl.Graph;

public class LabeledPropertyGraphSchema : IEnumerable
{
    private readonly Dictionary<String, NodeDef> dictionary = [];

    public LabeledPropertyGraphSchema()
    {
    }

    public NodeDef this[string key]
    {
        get => dictionary[key];
        set => dictionary[key] = value;
    }

    IEnumerator IEnumerable.GetEnumerator() =>
        dictionary.GetEnumerator();

    public void Display(TextWriter w)
    {
        w.WriteLine("# CSDL meta model");
        w.WriteLine();

        foreach (var (name, def) in dictionary)
        {
            w.WriteLine("## *{0}* model element", name);
            w.WriteLine();

            if (def.Properties?.Length > 0)
            {
                {
                    foreach (var (i, p) in def.Properties.WidthIndex())
                    {
                        if (i == 0)
                        {
                            w.WriteLine("### {0} properties of primitive values", name);
                            w.WriteLine();
                        }

                        w.WriteLine("- {0}: {1} {2}", p.Name, p.Type.Name(), p.IsRequired ? "required" : "optional");
                    }
                }
                w.WriteLine();
            }

            if (def.Associations?.Length > 0)
            {
                foreach (var (i, assoc) in def.Associations.WidthIndex())
                {
                    if (i == 0)
                    {
                        w.WriteLine("### {0} references to other model elements (nodes)", name);
                        w.WriteLine();
                    }
                    switch (assoc)
                    {
                        case Reference reference:
                            w.WriteLine("- {0}: Reference to {1}", assoc.Name, reference.TypeAlternatives.Join(", ", " or "));
                            break;

                        case PathReference path:
                            w.WriteLine("- {0}: Path following {1}", assoc.Name, string.Join("; ", path.Types));
                            break;
                    }
                }
                w.WriteLine();
            }

            if (def.Elements?.Length > 0)
            {
                foreach (var (i, child) in def.Elements.WidthIndex())
                {
                    if (i == 0)
                    {
                        w.WriteLine("### {0} contained model elements", name);
                        w.WriteLine();
                        w.WriteLine("    {1}", child.Name, child.TypeAlternatives.Join(", ", " or "));
                        w.WriteLine();
                    }
                    else
                    {
                        w.WriteLine("### Contained model elements under {0}", child.Name);
                        w.WriteLine();
                        w.WriteLine("{0}", child.TypeAlternatives.Join(", ", " or "));
                        w.WriteLine();
                    }
                }
            }
        }
    }

    public override string ToString()
    {
        var writer = new StringWriter();
        Display(writer);
        return writer.ToString();
    }
}
