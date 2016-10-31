using System;

namespace AutoBuilder.FillingStrategy
{
    internal class ComplexTypeValueGenerator : IValueGenerator
    {
        private readonly Type _type;

        public ComplexTypeValueGenerator(Type type)
        {
            _type = type;
        }

        public object GenerateValue(BuilderContext context)
        {
            var properties = TypeManager.GetProperties(_type);
            var returnValue = Activator.CreateInstance(_type);

            foreach (var prop in properties)
            {
                context.CurrentProperty = prop;

                var generator = ValueGeneratorFactory.GetValueGenerator(prop.PropertyType);
                var value = generator.GenerateValue(context);

                prop.SetValue(returnValue, value);

                context.UpdateLastBuidedType(prop.PropertyType, value);
            }

            return returnValue;
        }
    }
}
