using System.Collections.Generic;
using System.Linq;
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
        public void Should_fill_list_of_int_property_successfully()
        {
            Assert.NotNull(instance.ListOfIntProperty);
            Assert.True(instance.ListOfIntProperty.Any());
        }

        [Fact]
        public void Should_fill_list_of_string_property_successfully()
        {
            Assert.NotNull(instance.ListOfStringProperty);
            Assert.True(instance.ListOfStringProperty.Any());
        }

        [Fact]
        public void Should_fill_list_of_double_property_successfully()
        {
            Assert.NotNull(instance.ListOfDoubleProperty);
            Assert.True(instance.ListOfDoubleProperty.Any());
        }

        [Fact]
        public void Should_fill_IList_property_successfully()
        {
            Assert.NotNull(instance.IListProperty);
            Assert.True(instance.IListProperty.Any());
        }

        [Fact]
        public void Should_fill_array_property_successfully()
        {
            Assert.NotNull(instance.ArrayProperty);
            Assert.True(instance.ArrayProperty.Any());
        }

        [Fact]
        public void Should_fill_char_array_property_successfully()
        {
            Assert.NotNull(instance.CharArrayProperty);
            Assert.True(instance.CharArrayProperty.Any());
        }

        [Fact]
        public void Should_fill_byte_array_property_successfully()
        {
            Assert.NotNull(instance.ByteArrayProperty);
            Assert.True(instance.ByteArrayProperty.Any());
        }
    }

    internal class CollectionTestClass
    {
        public string SomeProperty { get; set; }
        public IEnumerable<PrimitiveTypeOnlyClass> CollectionProperty { get; set; }
        public List<PrimitiveTypeOnlyClass> ListProperty { get; set; }
        public List<int> ListOfIntProperty { get; set; }
        public List<string> ListOfStringProperty { get; set; }
        public List<double> ListOfDoubleProperty { get; set; }
        public IList<PrimitiveTypeOnlyClass> IListProperty { get; set; }
        public PrimitiveTypeOnlyClass[] ArrayProperty { get; set; }
        public char[] CharArrayProperty { get; set; }
        public byte[] ByteArrayProperty { get; set; }
    }
}
