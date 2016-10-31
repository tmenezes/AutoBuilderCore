using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AutoBuilder.UnitTest
{
    public class CollectionSupportTests
    {
        readonly CollectionTestClass instance;

        // arrange / act
        public CollectionSupportTests()
        {
            instance = new Builder<CollectionTestClass>().Build();
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
        public void Should_fill_list_property_successfully()
        {
            Assert.NotNull(instance.ListProperty);
            Assert.True(instance.ListProperty.Any());
        }

        [Fact]
        public void Should_fill_array_property_successfully()
        {
            Assert.NotNull(instance.ArrayProperty);
            Assert.True(instance.ArrayProperty.Any());
        }
    }

    internal class CollectionTestClass
    {
        public string SomeProperty { get; set; }
        public IEnumerable<PrimitiveTypeOnlyClass> CollectionProperty { get; set; }
        public IList<PrimitiveTypeOnlyClass> ListProperty { get; set; }
        public PrimitiveTypeOnlyClass[] ArrayProperty { get; set; }
    }
}
