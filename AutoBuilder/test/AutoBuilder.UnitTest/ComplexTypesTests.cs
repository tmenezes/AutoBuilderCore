using Xunit;

namespace AutoBuilder.UnitTest
{
    public class ComplexTypesTests
    {
        readonly ComplexTypeClass instance;

        // arrange / act
        public ComplexTypesTests()
        {
            instance = new Builder<ComplexTypeClass>().Build();
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
        public void Should_fill_nested_class_property_successfully()
        {
            Assert.NotNull(instance.NestedClassProperty);
            Assert.NotEmpty(instance.NestedClassProperty.SomeProperty);

            Assert.NotNull(instance.NestedClassProperty.PrimitiveTypeOnlyClassProperty);
            Assert.NotEmpty(instance.NestedClassProperty.PrimitiveTypeOnlyClassProperty.StringProperty);
        }
    }

    internal class ComplexTypeClass
    {
        public string SomeProperty { get; set; }
        public NestedComplexTypeClass NestedClassProperty { get; set; }
    }

    internal class NestedComplexTypeClass
    {
        public string SomeProperty { get; set; }
        public PrimitiveTypeOnlyClass PrimitiveTypeOnlyClassProperty { get; set; }
    }
}