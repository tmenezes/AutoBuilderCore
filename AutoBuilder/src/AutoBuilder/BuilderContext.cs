using System;
using System.Reflection;

namespace AutoBuilder
{
    internal class BuilderContext
    {
        public Type TargeType { get; }
        public PropertyInfo CurrentProperty { get; internal set; }
        public Type LastBuildedType { get; private set; }
        public object LastBuildedValue { get; private set; }


        public BuilderContext(Type targeType)
        {
            TargeType = targeType;
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
    }
}