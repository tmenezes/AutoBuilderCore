using System;
using AutoBuilder.Extensions;

namespace AutoBuilder.FillingStrategy
{
    internal class StringValueGenerator : IValueGenerator
    {
        public object GenerateValue(BuilderContext context)
        {
            return $"{context.CurrentProperty.Name}-{Guid.NewGuid()}".SafeSubstring(context.StringMaxLength);
        }
    }
}