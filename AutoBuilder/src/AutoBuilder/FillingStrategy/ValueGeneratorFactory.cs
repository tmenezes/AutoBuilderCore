using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoBuilder.FillingStrategy
{
    internal static class ValueGeneratorFactory
    {
        // private static 
        private static readonly IValueGenerator defaultValueGenerator = new DefaultValueGenerator();
        private static readonly IDictionary<Type, IValueGenerator> _generators;

        static ValueGeneratorFactory()
        {
            var integerValueGenerator = new IntegerValueGenerator();
            var datetimeValueGenerator = new DateTimeValueGenerator();
            var booleanValueGenerator = new BooleanValueGenerator();

            _generators = new Dictionary<Type, IValueGenerator>()
            {
                { typeof(string), new StringValueGenerator() },

                { typeof(int), integerValueGenerator },
                { typeof(int?), integerValueGenerator },
                { typeof(short), integerValueGenerator },
                { typeof(short?), integerValueGenerator },
                { typeof(long), integerValueGenerator },
                { typeof(long?), integerValueGenerator },

                { typeof(DateTime), datetimeValueGenerator },
                { typeof(DateTime?), datetimeValueGenerator },

                { typeof(bool), booleanValueGenerator },
                { typeof(bool?), booleanValueGenerator },
            };
        }


        public static IValueGenerator GetValueGenerator<T>()
        {
            return GetValueGenerator(typeof(T));
        }

        public static IValueGenerator GetValueGenerator(Type type)
        {
            if (!_generators.ContainsKey(type))
            {
                AddValueGeneratorFor(type);
            }

            var valueGenerator = _generators[type] ?? defaultValueGenerator;
            return valueGenerator;
        }


        private static void AddValueGeneratorFor(Type type)
        {
            var valueGenerator = TypeManager.IsComplexType(type)
                ? new ComplexTypeValueGenerator(type)
                : TypeManager.IsEnum(type) ? new EnumValueGenerator() : defaultValueGenerator;

            lock ("lock_AddValueGeneratorFor")
            {
                if (!_generators.ContainsKey(type))
                    _generators.Add(type, valueGenerator);
            }
        }
    }
}
