# Model paths

## path segments

- If a path segment is a simple identifier, it MUST be the **name of a child model element** of the preceding path part.
- If a path segment is a qualified name, the segment MUST be the **name of a type in scope**.
- if a path segment start with an at (@).
  - The at (@) character MUST be followed by a **qualified name of a term** in scope.
  - Or The at (@) character MUST be followed by a **qualified name name of a term followed by a # and a simple identifier** (the annotation qualifier ).
- if a path segments **starting with a navigation property**, then followed by an at (@) character, then followed by **the qualified name**.



```xml
<Schema xmlns="http://docs.oasis-open.org/odata/ns/edm" Alias="self" Namespace="example.org">
    <EntityType Name="Employee">
        <Key>
            <PropertyRef Name="Name" />
        </Key>
        <Property Name="Name" Type="Edm.String" Nullable="false" />
    </EntityType>
    <EntityType Name="ReportingLine">
        <Key>
            <PropertyRef Name="ReportsTo/Name" Alias="Manager" />
            <PropertyRef Name="DirectReport/Name" Alias="Subordinate" />
        </Key>
        <NavigationProperty Name="ReportsTo" Type="self.Employee"/>
        <NavigationProperty Name="DirectReport" Type="self.Employee" />
    </EntityType>
</Schema>
```

- ReportsTo/Name represents the graph path:
  - {enclosing entity type} --> ReportsTo -|Type|-> Employee --> Name
- DirectReport/Name represents the graph path:
  - {enclosing entity type} --> DirectReport -|Type|-> Employee --> Name

The general form is:
  "The value of Name is a path expression leading to a primitive property. The names of the properties in the path are joined together by forward slashes." (see [Key](https://docs.oasis-open.org/odata/odata-csdl-xml/v4.01/csprd02/odata-csdl-xml-v4.01-csprd02.html#sec_Key) )

more  formally, the path of the `Name` property is:

https://en.wikipedia.org/wiki/GraphQL


```txt
{enclosing entity type} 
  --> [Property or NavigationProperty]
    ( -|Type|-> {Entity or Complex Type} --> [Property or NavigationProperty]> )*
```

where

- each arrow `-->` indicates a containment relationship
- each arrow `-|Type|->` is the Type relationshild of properties
