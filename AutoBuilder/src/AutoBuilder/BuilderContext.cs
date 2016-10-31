using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoBuilder
{
    internal class BuilderContext
    {
        public Type TargeType { get; }
        public PropertyInfo CurrentProperty { get; private set; }
        public Type LastBuildedType { get; private set; }
        public object LastBuildedValue { get; private set; }
        public int CollectionDegree { get; set; }
        public IList<Type> ComplexTypesBuilded { get; set; }

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

        public bool IsCircularReference(Type type)
        {
            return TypeManager.IsComplexType(type) && ComplexTypesBuilded.Contains(type);
        }

        public void SetCurrentProperty(PropertyInfo property)
        {
            CurrentProperty = property;

            if (TypeManager.IsComplexType(property.PropertyType))
            {
                ComplexTypesBuilded.Add(property.PropertyType);
            }
        }
    }
}