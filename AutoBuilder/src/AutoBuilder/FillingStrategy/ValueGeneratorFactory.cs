using System;
using System.Collections.Generic;

namespace AutoBuilder.FillingStrategy
{
    internal static class ValueGeneratorFactory
    {
        // private static 
        private static IValueGenerator defaultValueGenerator = new DefaultValueGenerator();
        private static Dictionary<Type, IValueGenerator> _generators;

        public static IValueGenerator GetValueGenerator<T>()
        {
            return GetValueGenerator(typeof(T));
        }

        public static IValueGenerator GetValueGenerator(Type type)
        {
            EnsureGeneratorsDictionaryCreated();

            if (!_generators.ContainsKey(type))
            {
                AddValueGeneratorFor(type);
            }

            var valueGenerator = _generators[type] ?? defaultValueGenerator;
            return valueGenerator;
        }


        private static void EnsureGeneratorsDictionaryCreated()
        {
            if (_generators != null)
                return;

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

        private static void AddValueGeneratorFor(Type type)
        {
            var valueGenerator = TypeManager.IsComplexType(type)
                ? new ComplexTypeValueGenerator(type)
                : defaultValueGenerator;

            _generators.Add(type, valueGenerator);
        }
    }
}
