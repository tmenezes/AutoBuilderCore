using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AutoBuilder.UnitTest
{
    public class EnumSupportTests
    {
        readonly EnumTestClass instance;

        // arrange / act
        public EnumSupportTests()
        {
            instance = new Builder<EnumTestClass>().Build();
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
        public void Should_fill_enum_property_successfully()
        {
            Assert.True(Enum.IsDefined(typeof(ProgramingLanguage), instance.ProgramingLanguage));
        }

        [Fact]
        public void Should_fill_enum_nullable_property_successfully()
        {
            Assert.True(Enum.IsDefined(typeof(ProgramingLanguage), instance.SecondProgramingLanguage));
        }
    }

    internal enum ProgramingLanguage
    {
        C,
        Cpp,
        Csharp,
        Java,
    }

    internal class EnumTestClass
    {
        public string SomeProperty { get; set; }
        public ProgramingLanguage ProgramingLanguage { get; set; }
        public ProgramingLanguage? SecondProgramingLanguage { get; set; }
    }
}
