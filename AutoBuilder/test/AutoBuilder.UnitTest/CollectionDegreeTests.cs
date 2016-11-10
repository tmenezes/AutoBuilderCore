using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AutoBuilder.UnitTest
{
    public class CollectionDegreeTests
    {
        readonly CollectionDegreeTestClass instance;
        private readonly int collectionDegree;

        // arrange / act
        public CollectionDegreeTests()
        {
            collectionDegree = 5;
            var builder = new Builder<CollectionDegreeTestClass>();

            instance = builder.WithCollectionDegree(collectionDegree)
                              .Build();
        }

        [Fact]
        public void Should_create_class_successfully()
        {
            Assert.NotNull(instance);
        }

        [Fact]
        public void Should_fill_string_property_successfully()
        {
            Assert.NotNull(instance.SomeProperty);
            Assert.NotEmpty(instance.SomeProperty);
        }

        [Fact]
        public void Should_fill_collection_property_successfully()
        {
            Assert.NotNull(instance.CollectionProperty);
            Assert.True(instance.CollectionProperty.Any());
        }

        [Fact]
        public void Collection_items_should_have_exactly_collectionDegree_value()
        {
            Assert.Equal(collectionDegree, instance.CollectionProperty.Count());
        }
    }

    internal class CollectionDegreeTestClass
    {
        public string SomeProperty { get; set; }
        public IEnumerable<int> CollectionProperty { get; set; }
    }
}