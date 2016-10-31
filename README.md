# AutoBuilderCore
AutoBuilder is a **.Net Core** library that makes easy creation of objects graphs filled of data.
It is a tool for building unit tests arranges.

## Simplest Usage
```csharp
using AutoBuilder;
// ...
var myClassInstance = new Builder<MyClass>().Build();
```

## Features
1. Build a **full graph** of a class with properties filled
1. Circular reference protection
1. Collection support
1. Enum support

## Types supporteds
1. string (propertyname + GUID)
1. int, short, long (random numbers)
1. float, double, decimal (random float numbers)
1. Nullable
1. bool 
1. DateTime
1. IEnumerable<T>, IList<T>, List<T>, Array
1. User defined types
1. Enums