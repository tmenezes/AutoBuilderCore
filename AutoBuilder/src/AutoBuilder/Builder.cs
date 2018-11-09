using AutoBuilder.FillingStrategy;

namespace AutoBuilder
{
    public class Builder<T> where T : class, new()
    {
        readonly BuilderContext _builderContext;

        // constructor
        public Builder()
        {
            _builderContext = BuilderContext.From<T>();
        }


        public Builder<T> WithCollectionDegree(int collectionDegree)
        {
            _builderContext.CollectionDegree = collectionDegree;
            return this;
        }

        public Builder<T> WithStringsMaxSized(int maxLength)
        {
            _builderContext.StringMaxLength = maxLength;
            return this;
        }

        public Builder<T> WithStringsAlphabet(string alphabet)
        {
            _builderContext.StringAlphabet = alphabet;
            return this;
        }

        public T Build()
        {
            return ValueGeneratorFactory.GetValueGenerator<T>()
                                        .GenerateValue(_builderContext) as T;
        }
    }
}