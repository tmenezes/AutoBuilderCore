using System;
using System.Collections.Generic;
using AutoBuilder.Helpers;

namespace AutoBuilder.FillingStrategy
{
    internal class FloatValueGenerator : IValueGenerator
    {
        private static readonly Dictionary<Type, Func<object>> _generatorFunc;

        static FloatValueGenerator()
        {
            _generatorFunc = new Dictionary<Type, Func<object>>()
            {
                { typeof(float), () => (float)RandomData.GetDouble() * float.MaxValue },
                { typeof(float?), () => (float?)RandomData.GetDouble() * float.MaxValue },
                { typeof(double), () => RandomData.GetDouble() * double.MaxValue },
                { typeof(double?), () => (double?)RandomData.GetDouble() * double.MaxValue },
                { typeof(decimal), () => (decimal)RandomData.GetDouble() * decimal.MaxValue },
                { typeof(decimal?), () => (decimal?)RandomData.GetDouble() * decimal.MaxValue },
            };
        }

        public object GenerateValue(BuilderContext context)
        {
            var type = context.CurrentValueGeneratorType;

            return _generatorFunc[type].Invoke();
        }
    }
}