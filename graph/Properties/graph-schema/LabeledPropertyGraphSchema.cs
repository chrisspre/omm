
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks.Dataflow;

namespace Csdl.Graph;

public partial class LabeledPropertyGraphSchema // : IEnumerable
{
    public static readonly LabeledPropertyGraphSchema Default = new()
    {
        ["Schema"] = new NodeDef
        {
            Url = "https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_Schema",
            Description = "Schemas describe the entity model exposed by an OData service.",
            Properties = ["Namespace", "Alias"],
            Elements = [("Elements", ["EnumType", "EntityType", "ComplexType", "PrimitiveType", "TypeDefinition", "Term"])]
        },
        ["TypeDefinition"] = new NodeDef
        {
            Url = "https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_TypeDefinition",
            Description = "A type definition defines a new type that is based on a primitive type, a complex type, or an enumeration type.",
            Properties = ["Name"],
            Associations = [new Reference("UnderlyingType", ["PrimitiveType"])],
            Elements = [("Elements", ["Annotation"])]
        },
        ["EnumType"] = new NodeDef
        {
            Url = "https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_EnumType",
            Description = "An enumeration type defines a set of named values.",
            Properties = ["Name"],
            Elements = [("Members", ["Member"])]
        },
        ["Member"] = new NodeDef
        {
            Url = "https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_Member",
            Description = "A member defines a named value of an enumeration type.",
            Properties = ["Name", ("Value", PropertyType.Int, false)],
        },
        ["EntityType"] = new NodeDef
        {
            Url = "https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_EntityType",
            Description = "An entity type defines the structure of an entity.",
            Properties = ["Name"],
            Associations = [new Reference("BaseType", null, ["EntityType"])],
            Elements = [("Properties", ["Property", "NavigationProperty", "Annotation"]), ("Key", ["PropertyRef"])]
        },
        ["ComplexType"] = new NodeDef
        {
            Url = "https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_ComplexType",
            Description = "A complex type defines a structured value.",
            Properties = ["Name"],
            Associations = [new Reference("BaseType", ["ComplexType"])],
            Elements = [("Properties", ["Property", "NavigationProperty", "Annotation"])]
        },
        ["Property"] = new NodeDef
        {
            Url = "https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_Property",
            Description = "A property defines a typed value that can be part of an entity or a complex type.",
            Properties = ["Name", ("Nullable", PropertyType.Bool, false)],
            Associations = [new Reference("Type", ["ComplexType", "EnumType", "PrimitiveType"])],
            Elements = [("Annotations", ["Annotation"])],
        },
        ["NavigationProperty"] = new NodeDef
        {
            Url = "https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_NavigationProperty",
            Description = "A navigation property defines a relationship between two entity types.",
            Properties = ["Name", ("ContainsTarget", PropertyType.Bool, false)],
            Associations = [new Reference("Type", ["EntityType"])],
            Elements = [("Annotations", ["Annotation"])],
        },
        ["PropertyRef"] = new NodeDef
        {
            Url = "https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_Key",
            Description = "A property reference identifies a property that is part of the key of an entity type.",
            Properties = ["Alias"],
            Associations = [
            // The value of Name is a path expression leading to a primitive property. The names of the properties in the path are joined together by forward slashes.
            new PathReference("Name", 1, ["NavigationProperty", "Property"])
        ],
        },

        ["PrimitiveType"] = new NodeDef
        {
            Url = "https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#_Toc486522885",
            Description = "Primitive types define the built-in data types supported by OData.",
            Properties = ["Name"],
            Elements = [("Annotations", ["Annotation"])],
        },
        ["Term"] = new NodeDef
        {
            Url = "https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/odata-csdl-xml-v4.01.html#_Toc38530405",
            Description = "Terms define reusable vocabulary for annotating elements in an entity model.",
            Properties = [
                ("Name", PropertyType.String, true),
                    ("Nullable", PropertyType.Bool, false),
                     ("DefaultValue", PropertyType.String,false),
                     ("AppliesTo", PropertyType.String, false)
            ],
            Associations = [new Reference("Type", ["ComplexType", "EnumType", "PrimitiveType"]), new Reference("BaseTerm", ["Term"])],
            Elements = [("Annotations", ["Annotation"])],
        },
        // https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/odata-csdl-xml-v4.01.html#_Toc38530405
        ["Annotation"] = new NodeDef
        {
            Url = "https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/odata-csdl-xml-v4.01.html#_Toc38530405",
            Description = "Annotations provide additional information about elements in an entity model.",
            Properties = [("Qualifier", PropertyType.String, false)],
            Associations = [new Reference("Term", ["Term"])],
        },

        ["EntitySet"] = new NodeDef
        {
            Url = "https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_EntitySet",
            Description = "An entity set is a container for a collection of entity instances.",
        },
        ["Singleton"] = new NodeDef
        {
            Url = "https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_Singleton",
            Description = "A singleton is a container for a single entity instance.",
        },
        ["NavigationPropertyBinding"] = new NodeDef
        {
            Url = "https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_NavigationPropertyBinding",
            Description = "A navigation property binding specifies the entity set or singleton that a navigation property targets.",
            Associations = [
                new PathReference("Path", null, ["NavigationProperty"]),
                new Reference("Target", ["EntitySet", "singleton", "NavigationProperty"])
            ]
        },
    };

    public Dictionary<String, NodeDef> Definitions { get; } = [];

    public LabeledPropertyGraphSchema()
    {
    }

    public NodeDef this[string key]
    {
        get => Definitions[key];
        set => Definitions[key] = value;
    }

    // IEnumerator IEnumerable.GetEnumerator() =>
    //     Definitions.GetEnumerator();

    public void Display(TextWriter w)
    {
        w.WriteLine("# CSDL meta model");
        w.WriteLine();

        foreach (var (name, def) in Definitions)
        {
            DisplayModelElement(w, name, def);
        }
    }

    private static void DisplayModelElement(TextWriter w, string name, NodeDef def)
    {
        w.WriteLine("## {0} model element", name);
        w.WriteLine();
        w.WriteLine("{0} [OData CSDL XML Version 4.01]({1})", def.Description, def.Url);
        // One or more schemas describe the entity model exposed by an OData service.
        w.WriteLine();

        if (def.Properties?.Length > 0)
        {
            {
                foreach (var (i, p) in def.Properties.WidthIndex())
                {
                    if (i == 0)
                    {
                        w.WriteLine("### Properties of `{0}`", name);
                        w.WriteLine();
                    }

                    w.WriteLine("- {0}: {1} {2}", p.Name, p.Type.Name(), p.IsRequired ? "required" : "optional");
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
                    w.WriteLine("### Contained elements of `{0}`", name);
                    w.WriteLine();
                }

                var alternatives = child.Types.Select(t => $"[{t}](#{t.ToLower()}-model-element)").Join(", ", " or ");
                var prefix = def.Elements?.Length == 1 ? "" : i == 0 ? "directly: " : $"sub-key `{child.Name}`: ";
                w.WriteLine("- {0}{1}", prefix, alternatives);
                w.WriteLine();
            }
        }

        if (def.Associations?.Length > 0)
        {
            foreach (var (i, assoc) in def.Associations.WidthIndex())
            {
                if (i == 0)
                {
                    w.WriteLine("### Referenced elements of {0}", name);
                    w.WriteLine();
                }
                switch (assoc)
                {
                    case Reference reference:
                        var alts = reference.Types.Select(t => $"[{t}](#{t.ToLower()}-model-element)").Join(", ", " or ");

                        w.WriteLine("- {0}: Reference to {1}", assoc.Name, alts);
                        break;

                    case PathReference path:
                        w.WriteLine("- {0}: a Path of {1}", assoc.Name, string.Join(", ", path.Types));
                        break;
                }
            }
            w.WriteLine();
        }
    }

    public override string ToString()
    {
        var writer = new StringWriter();
        Display(writer);
        return writer.ToString();
    }

    internal void JsonSerialize(FileStream stream)
    {
        JsonSerializer.Serialize(stream, this, SerializeOnlyLabeledPropertyGraphSchemOnlyContext.Default.LabeledPropertyGraphSchema);
    }

    internal void JsonSerialize(string path)
    {
        using var stream = File.Create(path);
        JsonSerializer.Serialize(stream, this, SerializeOnlyLabeledPropertyGraphSchemOnlyContext.Default.LabeledPropertyGraphSchema);
    }

    [JsonSourceGenerationOptions(WriteIndented = true, UseStringEnumConverter = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonSerializable(typeof(LabeledPropertyGraphSchema))]
    [JsonSerializable(typeof(NodeDef))]
    [JsonSerializable(typeof(Element))]
    [JsonSerializable(typeof(Property))]
    [JsonDerivedType(typeof(Association))]
    internal partial class SerializeOnlyLabeledPropertyGraphSchemOnlyContext : JsonSerializerContext
    {
    }
}
