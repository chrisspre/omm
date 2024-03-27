# dev notes

## Target Path Syntax rules

```EBNF
QualifiedName =  Schema '.' (ComplexType|EntityType|EnumType|PrimitiveType)

TargetPath = QualifiedName '/' (EntitySet|Singleton) ( '/' (Property | NavigationProperty | QualifiedName) )*
```
