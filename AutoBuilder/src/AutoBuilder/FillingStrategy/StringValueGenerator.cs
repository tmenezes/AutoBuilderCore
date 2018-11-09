using System;
using System.Text;
using AutoBuilder.Extensions;
using AutoBuilder.Helpers;

namespace AutoBuilder.FillingStrategy
{
    internal class StringValueGenerator : IValueGenerator
    {
        public object GenerateValue(BuilderContext context)
        {
            var useSpecificAlphabet = !context.StringAlphabet.IsNullOrEmpty();
            if (!useSpecificAlphabet)
            {
                return $"{context.CurrentProperty.Name}-{Guid.NewGuid()}".Truncate(context.StringMaxLength);
            }

            // generate string based on specific alphabet
            var builder = new StringBuilder(context.StringMaxLength, context.StringMaxLength);
            for (var i = 0; i < context.StringMaxLength; i++)
            {
                builder.Append(context.StringAlphabet[RandomData.GetInt(context.StringAlphabet.Length)]);
            }
            return builder.ToString();
        }
    }
}