﻿using System;
using System.Collections;
using System.Collections.Generic;

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
            var floatValueGenerator = new FloatValueGenerator();
            var datetimeValueGenerator = new DateTimeValueGenerator();
            var booleanValueGenerator = new BooleanValueGenerator();

            _generators = new Dictionary<Type, IValueGenerator>()
            {
                { typeof(string), new StringValueGenerator() },

                { typeof(int), integerValueGenerator },
                { typeof(int?), integerValueGenerator },
                { typeof(short), integerValueGenerator },
                { typeof(short?), integerValueGenerator },
                { typeof(char), integerValueGenerator },
                { typeof(char?), integerValueGenerator },
                { typeof(byte), integerValueGenerator },
                { typeof(byte?), integerValueGenerator },
                { typeof(long), integerValueGenerator },
                { typeof(long?), integerValueGenerator },

                { typeof(float), floatValueGenerator },
                { typeof(float?), floatValueGenerator },
                { typeof(double), floatValueGenerator },
                { typeof(double?), floatValueGenerator },
                { typeof(decimal), floatValueGenerator },
                { typeof(decimal?), floatValueGenerator },

                { typeof(DateTime), datetimeValueGenerator },
                { typeof(DateTime?), datetimeValueGenerator },

                { typeof(bool), booleanValueGenerator },
                { typeof(bool?), booleanValueGenerator },

                { typeof(IEnumerable), new CollectionValueGenerator() },
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
            lock ("lock_AddValueGeneratorFor")
            {
                var valueGenerator = TypeManager.IsComplexType(type) ? new ComplexTypeValueGenerator(type)
                    : TypeManager.IsEnum(type) ? new EnumValueGenerator()
                    : TypeManager.IsCollection(type) ? new CollectionValueGenerator() : defaultValueGenerator;


                if (!_generators.ContainsKey(type))
                    _generators.Add(type, valueGenerator);
            }
        }
    }
}
