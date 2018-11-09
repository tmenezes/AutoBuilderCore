using System;
using System.Collections.Generic;
using AutoBuilder.Helpers;

namespace AutoBuilder.FillingStrategy
{
    internal class IntegerValueGenerator : IValueGenerator
    {
        private static readonly Dictionary<Type, Func<int?, int?, object>> _generatorFunc;

        static IntegerValueGenerator()
        {
            _generatorFunc = new Dictionary<Type, Func<int?, int?, object>>()
            {
                { typeof(short), (min, max) => GetShort(min, max) },
                { typeof(short?), (min, max) => (short?)GetShort(min, max) },
                { typeof(int), (min, max) => GetInt(min, max) },
                { typeof(int?), (min, max) => (int?)GetInt(min, max) },
                { typeof(long), (min, max) => GetLong(min, max) },
                { typeof(long?), (min, max) => (long?)GetLong(min, max) },
            };
        }

        public object GenerateValue(BuilderContext context)
        {
            var type = context.CurrentValueGeneratorType;

            return _generatorFunc[type].Invoke(context.MinNumberValue, context.MaxNumberValue);
        }

        // private
        private static short GetShort(int? min, int? max)
        {
            return (short)RandomData.GetInt(
                min.GetValueOrDefault() > short.MaxValue ? 0 : min.GetValueOrDefault(),
                max.GetValueOrDefault() > short.MaxValue ? short.MaxValue : max ?? short.MaxValue
            );
        }

        private static int GetInt(int? min, int? max)
        {
            return RandomData.GetInt(min.GetValueOrDefault(), max ?? int.MaxValue);
        }

        private static long GetLong(int? min, int? max)
        {
            var hasSetRange = min.HasValue || max.HasValue;
            if (hasSetRange)
            {
                return GetInt(min, max);
            }
            return (long)RandomData.GetInt() + int.MaxValue;
        }
    }
}