# CSDL meta model

## *Schema* model element

### Schema properties of primitive values

- Namespace: string required
- Alias: string required

### Schema contained model elements

    EnumType, EntityType, ComplexType, PrimitiveType, TypeDefinition  or  Term

## *TypeDefinition* model element

### TypeDefinition properties of primitive values

- Name: string required

### TypeDefinition references to other model elements (nodes)

- UnderlyingType: Reference to PrimitiveType

### TypeDefinition contained model elements

    Annotation

## *EnumType* model element

### EnumType properties of primitive values

- Name: string required

### EnumType contained model elements

    Member

## *Member* model element

### Member properties of primitive values

- Name: string required
- Value: number required

## *EntityType* model element

### EntityType properties of primitive values

- Name: string required

### EntityType references to other model elements (nodes)

- BaseType: Reference to EntityType

### EntityType contained model elements

    Property, NavigationProperty  or  Annotation

### Contained model elements under Key

PropertyRef

## *ComplexType* model element

### ComplexType properties of primitive values

- Name: string required

### ComplexType references to other model elements (nodes)

- BaseType: Reference to ComplexType

### ComplexType contained model elements

    Property, NavigationProperty  or  Annotation

## *Property* model element

### Property properties of primitive values

- Name: string required
- Nullable: boolean optional

### Property references to other model elements (nodes)

- Type: Reference to ComplexType, EnumType  or  PrimitiveType

### Property contained model elements

    Annotation

## *NavigationProperty* model element

### NavigationProperty properties of primitive values

- Name: string required
- ContainsTarget: boolean optional

### NavigationProperty references to other model elements (nodes)

- Type: Reference to EntityType

### NavigationProperty contained model elements

    Annotation

## *PropertyRef* model element

### PropertyRef properties of primitive values

- Alias: string required

### PropertyRef references to other model elements (nodes)

- Name: Path following NavigationProperty; Property

## *NavigationPropertyBinding* model element

## *PrimitiveType* model element

### PrimitiveType properties of primitive values

- Name: string required

### PrimitiveType contained model elements

    Annotation

## *Term* model element

### Term properties of primitive values

- Name: string required
- Nullable: boolean optional
- DefaultValue: string optional
- AppliesTo: string optional

### Term references to other model elements (nodes)

- Type: Reference to ComplexType, EnumType  or  PrimitiveType
- BaseTerm: Reference to Term

### Term contained model elements

    Annotation

## *Annotation* model element

### Annotation properties of primitive values

- Qualifier: string optional

### Annotation references to other model elements (nodes)

- Term: Reference to Term

