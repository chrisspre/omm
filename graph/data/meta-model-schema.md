# CSDL meta model

## Schema model element

Schemas describe the entity model exposed by an OData service. [OData CSDL XML Version 4.01](https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_Schema)

### Properties of `Schema`

- Namespace: string required
- Alias: string required

### Contained elements of `Schema`

- [EnumType](#enumtype-model-element), [EntityType](#entitytype-model-element), [ComplexType](#complextype-model-element), [PrimitiveType](#primitivetype-model-element), [TypeDefinition](#typedefinition-model-element)  or  [Term](#term-model-element)

## TypeDefinition model element

A type definition defines a new type that is based on a primitive type, a complex type, or an enumeration type. [OData CSDL XML Version 4.01](https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_TypeDefinition)

### Properties of `TypeDefinition`

- Name: string required

### Contained elements of `TypeDefinition`

- [Annotation](#annotation-model-element)

### Referenced elements of TypeDefinition

- UnderlyingType: Reference to [PrimitiveType](#primitivetype-model-element)

## EnumType model element

An enumeration type defines a set of named values. [OData CSDL XML Version 4.01](https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_EnumType)

### Properties of `EnumType`

- Name: string required

### Contained elements of `EnumType`

- [Member](#member-model-element)

## Member model element

A member defines a named value of an enumeration type. [OData CSDL XML Version 4.01](https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_Member)

### Properties of `Member`

- Name: string required
- Value: integer optional

## EntityType model element

An entity type defines the structure of an entity. [OData CSDL XML Version 4.01](https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_EntityType)

### Properties of `EntityType`

- Name: string required

### Contained elements of `EntityType`

- directly: [Property](#property-model-element), [NavigationProperty](#navigationproperty-model-element)  or  [Annotation](#annotation-model-element)

- sub-key `Key`: [PropertyRef](#propertyref-model-element)

### Referenced elements of EntityType

- BaseType: Reference to [EntityType](#entitytype-model-element)

## ComplexType model element

A complex type defines a structured value. [OData CSDL XML Version 4.01](https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_ComplexType)

### Properties of `ComplexType`

- Name: string required

### Contained elements of `ComplexType`

- [Property](#property-model-element), [NavigationProperty](#navigationproperty-model-element)  or  [Annotation](#annotation-model-element)

### Referenced elements of ComplexType

- BaseType: Reference to [ComplexType](#complextype-model-element)

## Property model element

A property defines a typed value that can be part of an entity or a complex type. [OData CSDL XML Version 4.01](https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_Property)

### Properties of `Property`

- Name: string required
- Nullable: boolean optional

### Contained elements of `Property`

- [Annotation](#annotation-model-element)

### Referenced elements of Property

- Type: Reference to [ComplexType](#complextype-model-element), [EnumType](#enumtype-model-element)  or  [PrimitiveType](#primitivetype-model-element)

## NavigationProperty model element

A navigation property defines a relationship between two entity types. [OData CSDL XML Version 4.01](https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_NavigationProperty)

### Properties of `NavigationProperty`

- Name: string required
- ContainsTarget: boolean optional

### Contained elements of `NavigationProperty`

- [Annotation](#annotation-model-element)

### Referenced elements of NavigationProperty

- Type: Reference to [EntityType](#entitytype-model-element)

## PropertyRef model element

A property reference identifies a property that is part of the key of an entity type. [OData CSDL XML Version 4.01](https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_Key)

### Properties of `PropertyRef`

- Alias: string required

### Referenced elements of PropertyRef

- Name: a Path of NavigationProperty, Property

## PrimitiveType model element

Primitive types define the built-in data types supported by OData. [OData CSDL XML Version 4.01](https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#_Toc486522885)

### Properties of `PrimitiveType`

- Name: string required

### Contained elements of `PrimitiveType`

- [Annotation](#annotation-model-element)

## Term model element

Terms define reusable vocabulary for annotating elements in an entity model. [OData CSDL XML Version 4.01](https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/odata-csdl-xml-v4.01.html#_Toc38530405)

### Properties of `Term`

- Name: string required
- Nullable: boolean optional
- DefaultValue: string optional
- AppliesTo: string optional

### Contained elements of `Term`

- [Annotation](#annotation-model-element)

### Referenced elements of Term

- Type: Reference to [ComplexType](#complextype-model-element), [EnumType](#enumtype-model-element)  or  [PrimitiveType](#primitivetype-model-element)
- BaseTerm: Reference to [Term](#term-model-element)

## Annotation model element

Annotations provide additional information about elements in an entity model. [OData CSDL XML Version 4.01](https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/odata-csdl-xml-v4.01.html#_Toc38530405)

### Properties of `Annotation`

- Qualifier: string optional

### Referenced elements of Annotation

- Term: Reference to [Term](#term-model-element)

## EntitySet model element

An entity set is a container for a collection of entity instances. [OData CSDL XML Version 4.01](https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_EntitySet)

## Singleton model element

A singleton is a container for a single entity instance. [OData CSDL XML Version 4.01](https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_Singleton)

## NavigationPropertyBinding model element

A navigation property binding specifies the entity set or singleton that a navigation property targets. [OData CSDL XML Version 4.01](https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_NavigationPropertyBinding)

### Referenced elements of NavigationPropertyBinding

- Path: a Path of NavigationProperty
- Target: Reference to [EntitySet](#entityset-model-element), [singleton](#singleton-model-element)  or  [NavigationProperty](#navigationproperty-model-element)

