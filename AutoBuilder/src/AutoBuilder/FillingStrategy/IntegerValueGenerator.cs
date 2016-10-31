using System;
using System.Collections.Generic;

namespace AutoBuilder.FillingStrategy
{
    internal class IntegerValueGenerator : IValueGenerator
    {
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);
        private static readonly Dictionary<Type, Func<object>> _generatorFunc;

        static IntegerValueGenerator()
        {
            _generatorFunc = new Dictionary<Type, Func<object>>()
            {
                { typeof(short), () => (short)_random.Next(short.MaxValue) },
                { typeof(short?), () => (short?)_random.Next(short.MaxValue) },
                { typeof(int), () => _random.Next() },
                { typeof(int?), () => (int?)_random.Next() },
                { typeof(long), () => (long)_random.Next() + int.MaxValue },
                { typeof(long?), () => (long?)_random.Next() + int.MaxValue },
            };
        }

        public object GenerateValue(BuilderContext context)
        {
            var type = context.GetCurrentPropertyReflectedType();

            return _generatorFunc[type].Invoke();
        }
    }
}