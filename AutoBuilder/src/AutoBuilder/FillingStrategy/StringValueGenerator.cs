using System;

namespace AutoBuilder.FillingStrategy
{
    internal class StringValueGenerator : IValueGenerator
    {
        public object GenerateValue(BuilderContext context)
        {
            return $"{context.CurrentProperty.Name}-{Guid.NewGuid()}";
        }
    }
}