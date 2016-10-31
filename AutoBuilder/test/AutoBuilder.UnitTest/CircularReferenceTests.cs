using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AutoBuilder.UnitTest
{
    public class CircularReferenceTests
    {
        readonly ReferenceCircularTestClass instance;

        // arrange / act
        public CircularReferenceTests()
        {
            instance = new Builder<ReferenceCircularTestClass>().Build();
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
        public void Should_fill_first_reference_property_successfully()
        {
            Assert.NotNull(instance.AnotherReferenceCircularTestClass);
        }

        [Fact]
        public void Should_not_fill_circular_reference_property_successfully()
        {
            Assert.Null(instance.AnotherReferenceCircularTestClass.ReferenceCircularTestClass.AnotherReferenceCircularTestClass);
        }
    }

    internal class ReferenceCircularTestClass
    {
        public string SomeProperty { get; set; }
        public AnotherReferenceCircularTestClass AnotherReferenceCircularTestClass { get; set; }
    }
    internal class AnotherReferenceCircularTestClass
    {
        public string SomeProperty { get; set; }
        public ReferenceCircularTestClass ReferenceCircularTestClass { get; set; }
    }
}
