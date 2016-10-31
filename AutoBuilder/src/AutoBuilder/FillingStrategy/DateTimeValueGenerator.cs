using System;

namespace AutoBuilder.FillingStrategy
{
    internal class DateTimeValueGenerator : IValueGenerator
    {
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);
        
        public object GenerateValue(BuilderContext context)
        {
            var year = _random.Next(1900, 2099);
            var month = _random.Next(1, 12);
            var day = _random.Next(1, 28);
            var hour = _random.Next(0, 23);
            var minute = _random.Next(0, 59);
            var second = _random.Next(0, 59);
            var milisecond = _random.Next(0, 59);

            var datetime = new DateTime(year, month, day, hour, minute, second, milisecond);

            return TypeManager.IsNullableType<DateTime>(context.GetCurrentPropertyReflectedType())
                ? (DateTime?)datetime
                : datetime;
        }
    }
}