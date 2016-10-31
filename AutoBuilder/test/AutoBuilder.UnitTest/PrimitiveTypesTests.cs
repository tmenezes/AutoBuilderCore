using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AutoBuilder.UnitTest
{
    public class PrimitiveTypesTests
    {
        readonly PrimitiveTypeOnlyClass instance;

        // arrange / act
        public PrimitiveTypesTests()
        {
            instance = new Builder<PrimitiveTypeOnlyClass>().Build();
        }


        [Fact]
        public void Should_create_class_successfully()
        {
            Assert.NotNull(instance);
        }

        [Fact]
        public void Should_fill_string_property_successfully()
        {
            Assert.NotNull(instance.StringProperty);
            Assert.NotEmpty(instance.StringProperty);
        }

        [Fact]
        public void Should_fill_int16_property_successfully()
        {
            Assert.True(instance.Int16Property > 0);
        }

        [Fact]
        public void Should_fill_int16_nullable_property_successfully()
        {
            Assert.True(instance.Int16NullableProperty > 0);
        }

        [Fact]
        public void Should_fill_int32_property_successfully()
        {
            Assert.True(instance.Int32Property > 0);
        }

        [Fact]
        public void Should_fill_int32_nullable_property_successfully()
        {
            Assert.True(instance.Int32NullableProperty > 0);
        }

        [Fact]
        public void Should_fill_int64_property_successfully()
        {
            Assert.True(instance.Int64Property > 0);
        }

        [Fact]
        public void Should_fill_int64_nullable_property_successfully()
        {
            Assert.True(instance.Int64NullableProperty > 0);
        }

        [Fact]
        public void Should_fill_DateTime_property_successfully()
        {
            Assert.NotNull(instance.DateTimeProperty);
            Assert.True(instance.DateTimeProperty.Year > 0);
            Assert.True(instance.DateTimeProperty.Month > 0);
            Assert.True(instance.DateTimeProperty.Day > 0);
            Assert.True(instance.DateTimeProperty.Hour > 0);
            Assert.True(instance.DateTimeProperty.Minute > 0);
            Assert.True(instance.DateTimeProperty.Second > 0);
            Assert.True(instance.DateTimeProperty.Millisecond > 0);
        }

        [Fact]
        public void Should_fill_DateTime_nullable_property_successfully()
        {
            Assert.True(instance.DateTimeNullableProperty.HasValue);
            Assert.True(instance.DateTimeNullableProperty.Value.Year > 0);
            Assert.True(instance.DateTimeNullableProperty.Value.Month > 0);
            Assert.True(instance.DateTimeNullableProperty.Value.Day > 0);
            Assert.True(instance.DateTimeNullableProperty.Value.Hour > 0);
            Assert.True(instance.DateTimeNullableProperty.Value.Minute > 0);
            Assert.True(instance.DateTimeNullableProperty.Value.Second > 0);
            Assert.True(instance.DateTimeNullableProperty.Value.Millisecond > 0);
        }

        [Fact]
        public void Should_fill_Boolean_property_successfully()
        {
            Assert.True(instance.BooleanPropertyWasSet);
        }

        [Fact]
        public void Should_fill_Boolean_nullable_property_successfully()
        {
            Assert.True(instance.BooleanNullableProperty.HasValue);
        }
    }

    internal class PrimitiveTypeOnlyClass
    {
        private bool _booleanProperty;

        public string StringProperty { get; set; }

        public short Int16Property { get; set; }
        public short? Int16NullableProperty { get; set; }
        public int Int32Property { get; set; }
        public int? Int32NullableProperty { get; set; }
        public long Int64Property { get; set; }
        public long? Int64NullableProperty { get; set; }

        public DateTime DateTimeProperty { get; set; }
        public DateTime? DateTimeNullableProperty { get; set; }

        public bool BooleanProperty
        {
            get { return _booleanProperty; }
            set { _booleanProperty = value; BooleanPropertyWasSet = true; }
        }
        public bool? BooleanNullableProperty { get; set; }
        public bool BooleanPropertyWasSet { get; private set; }
    }

}
