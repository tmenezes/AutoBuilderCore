using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoBuilder.FillingStrategy
{
    internal class CollectionValueGenerator : IValueGenerator
    {
        public object GenerateValue(BuilderContext context)
        {
            var type = context.CurrentProperty.PropertyType;

            return TypeManager.IsArray(type)
                ? GenerateArrayWithValues(context)
                : GenerateIEnumerableWithValues(context);
        }

        private object GenerateIEnumerableWithValues(BuilderContext context)
        {
            var type = context.CurrentProperty.PropertyType;
            var collectionItemType = type.GetElementType() ?? type.GetTypeInfo().GenericTypeArguments.First();
            var genericListType = typeof(List<>).MakeGenericType(collectionItemType);

            var generator = ValueGeneratorFactory.GetValueGenerator(collectionItemType);
            var returnValue = (IList)Activator.CreateInstance(genericListType);

            context.SetCurrentValueGeneratorType(collectionItemType);

            for (var i = 0; i < context.CollectionDegree; i++)
            {
                returnValue.Add(generator.GenerateValue(context));
            }

            return returnValue;
        }

        private object GenerateArrayWithValues(BuilderContext context)
        {
            var type = context.CurrentProperty.PropertyType;
            var collectionItemType = type.GetElementType() ?? type.GetTypeInfo().GenericTypeArguments.First();

            var generator = ValueGeneratorFactory.GetValueGenerator(collectionItemType);
            var returnValue = Array.CreateInstance(collectionItemType, context.CollectionDegree);

            context.SetCurrentValueGeneratorType(collectionItemType);

            for (var i = 0; i < context.CollectionDegree; i++)
            {
                returnValue.SetValue(generator.GenerateValue(context), i);
            }

            return returnValue;
        }
    }
}