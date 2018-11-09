using AutoBuilder.Helpers;

namespace AutoBuilder.FillingStrategy
{
    internal class BooleanValueGenerator : IValueGenerator
    {
        public object GenerateValue(BuilderContext context)
        {
            var value = RandomData.GetBool();

            return TypeManager.IsNullableType<bool>(context.CurrentValueGeneratorType)
                       ? (bool?)value
                       : value;
        }
    }
}