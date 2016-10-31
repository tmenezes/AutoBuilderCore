using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoBuilder
{
    public static class TypeManager
    {
        private static readonly List<Type> _collections = new List<Type>() { typeof(IEnumerable<>), typeof(IEnumerable) };
        private static readonly IDictionary<Type, IEnumerable<PropertyInfo>> _properties;

        static TypeManager()
        {
            _properties = new Dictionary<Type, IEnumerable<PropertyInfo>>();
        }


        public static void LoadType(Type type)
        {
            lock (type)
            {
                if (IsAlreadyLoaded(type))
                {
                    return;
                }

                var props = type.GetRuntimeProperties().Where(p => IsWritableProperty(p)).ToList();
                var complexTypeProps = props.Where(p => IsComplexType(p.PropertyType) && !IsAlreadyLoaded(p.PropertyType)).ToList();

                _properties.Add(type, props);

                foreach (var prop in complexTypeProps)
                {
                    LoadType(prop.PropertyType);
                }
            }
        }

        public static IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            if (!IsAlreadyLoaded(type))
            {
                LoadType(type);
            }

            return _properties[type];
        }


        public static bool IsAlreadyLoaded(Type type)
        {
            return _properties.ContainsKey(type);
        }

        public static bool IsCollection(Type type)
        {
            var isString = type == typeof(string);
            var isCollection = type.GetTypeInfo().GetInterfaces().Any(i => _collections.Any(c => i == c));

            return !isString && isCollection;
        }

        public static bool IsComplexType(Type type)
        {
            var hasAnyProperty = type.GetRuntimeProperties().Any();
            var isString = type == typeof(string);
            var isDateTima = type == typeof(DateTime);
            var isNullable = Nullable.GetUnderlyingType(type) != null; //type.Namespace.Contains(typeof(Nullable).Namespace);

            return hasAnyProperty && !isString && !isDateTima && !isNullable;
        }

        public static bool IsNullableType<T>(Type type) where T : struct
        {
            return type == typeof(T?);
        }

        public static bool IsNullableTypeOfEnum(Type type)
        {
            var underlyingType = Nullable.GetUnderlyingType(type);

            return underlyingType?.GetTypeInfo().IsEnum ?? false;
        }

        public static bool IsEnum(Type type)
        {
            if (type.GetTypeInfo().IsEnum)
                return true;

            return IsNullableTypeOfEnum(type);
        }


        private static bool IsWritableProperty(PropertyInfo p)
        {
            return p.CanWrite && p.GetSetMethod(false) != null;
        }
    }
}