using System;
using Xunit;

namespace AutoBuilder.UnitTest
{
    public class PrimitiveTypesTests
    {
        readonly PrimitiveTypeOnlyClass instance;
        readonly int stringMaxSize = 15;

        // arrange / act
        public PrimitiveTypesTests()
        {
            instance = new Builder<PrimitiveTypeOnlyClass>()
                .WithStringsMaxSized(stringMaxSize)
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
            Assert.NotNull(instance.StringProperty);
            Assert.NotEmpty(instance.StringProperty);
        }

        [Fact]
        public void Should_have_the_right_size_for_the_string_property()
        {
            Assert.NotNull(instance.StringProperty);
            Assert.True(instance.StringProperty.Length <= stringMaxSize);
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
        public void Should_fill_float_property_successfully()
        {
            Assert.True(instance.FloatProperty > 0);
        }

        [Fact]
        public void Should_fill_float_nullable_property_successfully()
        {
            Assert.True(instance.FloatNullableProperty > 0);
        }

        [Fact]
        public void Should_fill_double_property_successfully()
        {
            Assert.True(instance.DoubleProperty > 0);
        }

        [Fact]
        public void Should_fill_double_nullable_property_successfully()
        {
            Assert.True(instance.DoubleNullableProperty > 0);
        }

        [Fact]
        public void Should_fill_decimal_property_successfully()
        {
            Assert.True(instance.DecimalProperty > 0);
        }

        [Fact]
        public void Should_fill_decimal_nullable_property_successfully()
        {
            Assert.True(instance.DecimalNullableProperty > 0);
        }

        [Fact]
        public void Should_fill_DateTime_property_successfully()
        {
            Assert.NotNull(instance.DateTimeProperty);
            Assert.True(instance.DateTimeProperty.Year > 0);
            Assert.True(instance.DateTimeProperty.Month > 0);
            Assert.True(instance.DateTimeProperty.Day > 0);
            Assert.True(instance.DateTimeProperty.Hour >= 0 && instance.DateTimeProperty.Hour <= 23);
            Assert.True(instance.DateTimeProperty.Minute >= 0 && instance.DateTimeProperty.Minute <= 59);
            Assert.True(instance.DateTimeProperty.Second >= 0 && instance.DateTimeProperty.Second <= 59);
            Assert.True(instance.DateTimeProperty.Millisecond >= 0 && instance.DateTimeProperty.Millisecond <= 999);
        }

        [Fact]
        public void Should_fill_DateTime_nullable_property_successfully()
        {
            Assert.True(instance.DateTimeNullableProperty.HasValue);
            Assert.True(instance.DateTimeNullableProperty.Value.Year > 0);
            Assert.True(instance.DateTimeNullableProperty.Value.Month > 0);
            Assert.True(instance.DateTimeNullableProperty.Value.Day > 0);
            Assert.True(instance.DateTimeNullableProperty.Value.Hour >= 0 && instance.DateTimeNullableProperty.Value.Hour <= 23);
            Assert.True(instance.DateTimeNullableProperty.Value.Minute >= 0 && instance.DateTimeNullableProperty.Value.Minute <= 59);
            Assert.True(instance.DateTimeNullableProperty.Value.Second >= 0 && instance.DateTimeNullableProperty.Value.Second <= 59);
            Assert.True(instance.DateTimeNullableProperty.Value.Millisecond >= 0 && instance.DateTimeNullableProperty.Value.Millisecond <= 999);
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

        public float FloatProperty { get; set; }
        public float? FloatNullableProperty { get; set; }
        public double DoubleProperty { get; set; }
        public double? DoubleNullableProperty { get; set; }
        public decimal DecimalProperty { get; set; }
        public decimal? DecimalNullableProperty { get; set; }

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
