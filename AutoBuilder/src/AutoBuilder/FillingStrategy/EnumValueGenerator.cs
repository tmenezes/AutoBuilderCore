using System;
using AutoBuilder.Helpers;

namespace AutoBuilder.FillingStrategy
{
    internal class EnumValueGenerator : IValueGenerator
    {
        public object GenerateValue(BuilderContext context)
        {
            var enumType = TypeManager.IsNullableTypeOfEnum(context.CurrentValueGeneratorType)
                ? Nullable.GetUnderlyingType(context.CurrentValueGeneratorType)
                : context.CurrentValueGeneratorType;

            var enumValues = Enum.GetValues(enumType);
            var index = RandomData.GetInt(enumValues.Length - 1);

            return enumValues.GetValue(index);
        }
    }
}