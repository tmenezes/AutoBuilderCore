using System;
using System.Collections.Generic;
using AutoBuilder.Helpers;

namespace AutoBuilder.FillingStrategy
{
    internal class IntegerValueGenerator : IValueGenerator
    {
        private static readonly Dictionary<Type, Func<object>> _generatorFunc;

        static IntegerValueGenerator()
        {
            _generatorFunc = new Dictionary<Type, Func<object>>()
            {
                { typeof(short), () => (short)RandomData.GetInt(short.MaxValue) },
                { typeof(short?), () => (short?)RandomData.GetInt(short.MaxValue) },
                { typeof(int), () => RandomData.GetInt() },
                { typeof(int?), () => (int?)RandomData.GetInt() },
                { typeof(long), () => (long)RandomData.GetInt() + int.MaxValue },
                { typeof(long?), () => (long?)RandomData.GetInt() + int.MaxValue },
            };
        }

        public object GenerateValue(BuilderContext context)
        {
            var type = context.CurrentValueGeneratorType;

            return _generatorFunc[type].Invoke();
        }
    }
}