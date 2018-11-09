using System;
using AutoBuilder.Helpers;

namespace AutoBuilder.FillingStrategy
{
    internal class DateTimeValueGenerator : IValueGenerator
    {
        public object GenerateValue(BuilderContext context)
        {
            var year = RandomData.GetInt(1900, 2099);
            var month = RandomData.GetInt(1, 12);
            var day = RandomData.GetInt(1, 28);
            var hour = RandomData.GetInt(0, 23);
            var minute = RandomData.GetInt(0, 59);
            var second = RandomData.GetInt(0, 59);
            var millisecond = RandomData.GetInt(0, 59);

            var datetime = new DateTime(year, month, day, hour, minute, second, millisecond);

            return TypeManager.IsNullableType<DateTime>(context.CurrentValueGeneratorType)
                ? (DateTime?)datetime
                : datetime;
        }
    }
}