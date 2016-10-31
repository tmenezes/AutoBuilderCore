using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoBuilder
{
    internal class BuilderContext
    {
        public Type TargeType { get; }
        public PropertyInfo CurrentProperty { get; private set; }
        public Type CurrentValueGeneratorType { get; private set; }
        public bool CurrentPropertyIsCollection { get; private set; }
        public Type LastBuildedType { get; private set; }
        public object LastBuildedValue { get; private set; }
        public int CollectionDegree { get; set; }
        public IList<Type> ComplexTypesBuilded { get; set; }

        // constructors
        public BuilderContext(Type targeType)
        {
            TargeType = targeType;
            CollectionDegree = 3;
            ComplexTypesBuilded = new List<Type>();
        }

        public static BuilderContext From<T>() where T : class, new()
        {
            return new BuilderContext(typeof(T));
        }


        public void UpdateLastBuidedType(Type type, object value)
        {
            LastBuildedType = type;
            LastBuildedValue = value;
        }

        public bool IsInCircularReference(Type type)
        {
            return TypeManager.IsComplexType(type) && ComplexTypesBuilded.Contains(type);
        }

        public void SetCurrentProperty(PropertyInfo property)
        {
            CurrentProperty = property;
            CurrentPropertyIsCollection = TypeManager.IsCollection(property.PropertyType);

            if (TypeManager.IsComplexType(property.PropertyType))
            {
                ComplexTypesBuilded.Add(property.PropertyType);
            }
        }

        public Type GetCurrentPropertyReflectedType()
        {
            return CurrentPropertyIsCollection
                ? TypeManager.GetCollectionItemType(CurrentProperty.PropertyType)
                : CurrentProperty.PropertyType;
        }
    }
}