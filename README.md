# AutoBuilderCore
AutoBuilder is a **.Net Core** library that makes easy creation of objects graphs filled of data.
It is a tool for building unit tests arranges.

## Usage
```csharp
using AutoBuilder;
// ...
var builder = new Builder<MyModel>()
    .WithStringsMaxSized(50)           // strings with max size of 50
    .WithStringsAlphabet("abcdef...")  // strings using only those specific characters
    .WithMinNumberValueOf(1)           // numbers with min value of 1
    .WithMaxNumberValueOf(10);         // numbers with max value of 10

var myClassInstance = builder.Build(); // model instance generated respecting the config above
```

## Features
1. Build a **full graph** of a class with properties filled
1. String size
1. Specific string alphabet
1. Number range
1. Circular reference protection
1. Collection support
1. Enum support

## Supported Types
1. **User defined** types
1. string (propertyname + GUID)
1. int, short, long, char, byte (random numbers)
1. float, double, decimal (random float numbers)
1. Nullable
1. bool 
1. DateTime
1. IEnumerable<T>, IList<T>, List<T>, Array
1. Enums