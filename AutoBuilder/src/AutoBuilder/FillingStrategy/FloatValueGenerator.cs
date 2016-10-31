using System;
using System.Collections.Generic;

namespace AutoBuilder.FillingStrategy
{
    internal class FloatValueGenerator : IValueGenerator
    {
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);
        private static readonly Dictionary<Type, Func<object>> _generatorFunc;

        static FloatValueGenerator()
        {
            _generatorFunc = new Dictionary<Type, Func<object>>()
            {
                { typeof(float), () => (float)_random.NextDouble() * float.MaxValue },
                { typeof(float?), () => (float?)_random.NextDouble() * float.MaxValue },
                { typeof(double), () => _random.NextDouble() * double.MaxValue },
                { typeof(double?), () => (double?)_random.NextDouble() * double.MaxValue },
                { typeof(decimal), () => (decimal)_random.NextDouble() * decimal.MaxValue },
                { typeof(decimal?), () => (decimal?)_random.NextDouble() * decimal.MaxValue },
            };
        }

        public object GenerateValue(BuilderContext context)
        {
            var type = context.CurrentValueGeneratorType;

            return _generatorFunc[type].Invoke();
        }
    }
}