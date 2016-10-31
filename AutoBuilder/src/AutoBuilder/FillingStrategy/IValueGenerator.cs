namespace AutoBuilder.FillingStrategy
{
    internal interface IValueGenerator
    {
        object GenerateValue(BuilderContext context);
    }
}