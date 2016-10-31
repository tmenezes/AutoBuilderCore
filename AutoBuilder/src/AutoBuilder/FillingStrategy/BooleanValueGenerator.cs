using System;

namespace AutoBuilder.FillingStrategy
{
    internal class BooleanValueGenerator : IValueGenerator
    {
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);

        public object GenerateValue(BuilderContext context)
        {
            var value = _random.Next() % 2 == 0;

            return TypeManager.IsNullableType<bool>(context.CurrentProperty.PropertyType)
                       ? (bool?)value
                       : value;
        }
    }
}