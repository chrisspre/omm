using System.Text.Json.Serialization;

namespace omm;

/// <summary>
/// Represents an association in a labeled property graph schema.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "Kind")]
[JsonDerivedType(typeof(Reference), typeDiscriminator: "reference")]
[JsonDerivedType(typeof(PathReference), typeDiscriminator: "path")]
public abstract partial record Association(string Name);

