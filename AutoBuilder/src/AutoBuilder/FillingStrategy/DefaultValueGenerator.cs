using System;

namespace AutoBuilder.FillingStrategy
{
    internal class DefaultValueGenerator : IValueGenerator
    {
        public object GenerateValue(BuilderContext context)
        {
            return Activator.CreateInstance(context.CurrentValueGeneratorType);
        }
    }
}