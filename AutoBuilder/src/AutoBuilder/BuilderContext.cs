using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoBuilder
{
    internal class BuilderContext
    {
        public Type TargetType { get; }
        public PropertyInfo CurrentProperty { get; private set; }
        public Type CurrentValueGeneratorType { get; private set; }
        public bool CurrentPropertyIsCollection { get; private set; }
        public Type LastBuildType { get; private set; }
        public object LastBuildValue { get; private set; }
        public int CollectionDegree { get; set; }
        public int StringMaxLength { get; set; }
        public string StringAlphabet { get; set; }
        public IList<Type> ComplexTypesBuild { get; set; }

        // constructors
        public BuilderContext(Type targetType)
        {
            TargetType = targetType;
            CollectionDegree = 3;
            StringMaxLength = 256;
            ComplexTypesBuild = new List<Type>();
        }

        public static BuilderContext From<T>() where T : class, new()
        {
            return new BuilderContext(typeof(T));
        }


        public void UpdateLastBuildType(Type type, object value)
        {
            LastBuildType = type;
            LastBuildValue = value;
        }

        public bool IsInCircularReference(Type type)
        {
            return TypeManager.IsComplexType(type) && ComplexTypesBuild.Contains(type);
        }

        public void SetCurrentProperty(PropertyInfo property)
        {
            CurrentProperty = property;
            CurrentPropertyIsCollection = TypeManager.IsCollection(property.PropertyType);
            CurrentValueGeneratorType = property.PropertyType;

            if (TypeManager.IsComplexType(property.PropertyType))
            {
                ComplexTypesBuild.Add(property.PropertyType);
            }
        }

        public void SetCurrentValueGeneratorType(Type type)
        {
            CurrentValueGeneratorType = type;

            if (TypeManager.IsComplexType(type))
            {
                ComplexTypesBuild.Add(type);
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