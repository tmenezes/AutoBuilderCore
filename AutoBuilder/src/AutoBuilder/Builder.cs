using AutoBuilder.FillingStrategy;

namespace AutoBuilder
{
    public class Builder<T> where T : class, new()
    {
        public T Build()
        {
            return ValueGeneratorFactory.GetValueGenerator<T>()
                                        .GenerateValue(BuilderContext.From<T>()) as T;
        }
    }
}