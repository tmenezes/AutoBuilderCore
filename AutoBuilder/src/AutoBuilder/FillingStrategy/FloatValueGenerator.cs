using System;
using System.Collections.Generic;
using AutoBuilder.Helpers;

namespace AutoBuilder.FillingStrategy
{
    internal class FloatValueGenerator : IValueGenerator
    {
        private static readonly Dictionary<Type, Func<int?, int?, object>> _generatorFunc;

        static FloatValueGenerator()
        {
            _generatorFunc = new Dictionary<Type, Func<int?, int?, object>>()
            {
                { typeof(float), (min, max) => HasRangeSet(min, max) ? (float)GetDouble(min, max) : (float)RandomData.GetDouble() * float.MaxValue },
                { typeof(float?), (min, max) => HasRangeSet(min, max) ? (float?)GetDouble(min, max) : (float?)RandomData.GetDouble() * float.MaxValue },
                { typeof(double), (min, max) => HasRangeSet(min, max) ? GetDouble(min, max) : RandomData.GetDouble() * double.MaxValue },
                { typeof(double?), (min, max) => HasRangeSet(min, max) ? GetDouble(min, max) : (double?)RandomData.GetDouble() * double.MaxValue },
                { typeof(decimal), (min, max) => HasRangeSet(min, max) ? (decimal)GetDouble(min, max) : (decimal)RandomData.GetDouble() * decimal.MaxValue },
                { typeof(decimal?), (min, max) => HasRangeSet(min, max) ? (decimal?)GetDouble(min, max) : (decimal?)RandomData.GetDouble() * decimal.MaxValue },
            };
        }

        public object GenerateValue(BuilderContext context)
        {
            var type = context.CurrentValueGeneratorType;

            return _generatorFunc[type].Invoke(context.MinNumberValue, context.MaxNumberValue);
        }


        private static bool HasRangeSet(int? min, int? max) => min.HasValue || max.HasValue;

        private static double GetDouble(int? min, int? max)
        {
            return (max.GetValueOrDefault(int.MaxValue) - min.GetValueOrDefault()) * RandomData.GetDouble() + min.GetValueOrDefault();
        }
    }
}