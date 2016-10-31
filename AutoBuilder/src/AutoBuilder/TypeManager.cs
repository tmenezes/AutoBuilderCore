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
            lock ("lock_LoadType")
            {
                if (IsAlreadyLoaded(type))
                {
                    return;
                }

                var props = type.GetRuntimeProperties().Where(p => IsWritableProperty(p)).ToList();

                _properties.Add(type, props);

                LoadComplexTypes(props);
                LoadCollectionTypes(props);
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
            var isNullable = Nullable.GetUnderlyingType(type) != null;
            var isCollection = IsCollection(type);

            return hasAnyProperty && !isString && !isDateTima && !isNullable && !isCollection;
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

        public static bool IsArray(Type type)
        {
            return IsCollection(type) && type.GetElementType() != null;
        }


        private static bool IsWritableProperty(PropertyInfo p)
        {
            return p.CanWrite && p.GetSetMethod(false) != null;
        }

        private static void LoadComplexTypes(IEnumerable<PropertyInfo> props)
        {
            var complexTypes = props.Where(p => IsComplexType(p.PropertyType))
                                    .Where(p => !IsAlreadyLoaded(p.PropertyType))
                                    .Select(p => p.PropertyType)
                                    .ToList();

            foreach (var prop in complexTypes)
            {
                LoadType(prop);
            }
        }

        private static void LoadCollectionTypes(IEnumerable<PropertyInfo> props)
        {
            var collectionTypes = props.Where(p => IsCollection(p.PropertyType) && !IsArray(p.PropertyType)).Select(p => p.PropertyType.GetTypeInfo().GenericTypeArguments.FirstOrDefault());
            var arrayTypes = props.Where(p => IsCollection(p.PropertyType)).Select(p => p.PropertyType.GetElementType()).Where(t => t != null);

            var typesToLoad = collectionTypes.Union(arrayTypes)
                                             .Where(t => t != null)
                                             .Where(t => !IsAlreadyLoaded(t))
                                             .Where(t => IsComplexType(t))
                                             .ToList();

            foreach (var prop in typesToLoad)
            {
                LoadType(prop);
            }
        }
    }
}