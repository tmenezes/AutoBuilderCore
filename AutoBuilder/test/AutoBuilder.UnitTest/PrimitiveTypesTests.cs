using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AutoBuilder.UnitTest
{
    public class PrimitiveTypesTests
    {
        readonly PrimitiveTypeOnlyClass instance;
        readonly int stringMaxSize = 15;
        readonly string stringAlphabet = "abcde";

        // arrange / act
        public PrimitiveTypesTests()
        {
            instance = new Builder<PrimitiveTypeOnlyClass>()
                .WithStringsMaxSized(stringMaxSize)
                .WithStringsAlphabet(stringAlphabet)
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
        public void Should_respect_the_right_alphabet_for_the_string_property()
        {
            Assert.NotNull(instance.StringProperty);
            Assert.True(instance.StringProperty.All(c => stringAlphabet.Contains(c)));
        }

        [Fact]
        public void Should_fill_byte_property_successfully()
        {
            Assert.True(instance.ByteProperty > 0);
        }

        [Fact]
        public void Should_fill_byte_nullable_property_successfully()
        {
            Assert.True(instance.ByteNullableProperty > 0);
        }

        [Fact]
        public void Should_fill_byte_property_with_range_successfully()
        {
            var min = (byte)10;
            var max = (byte)100;

            var newInstance = new Builder<PrimitiveTypeOnlyClass>()
                              .WithMinNumberValueOf(min)
                              .WithMaxNumberValueOf(max)
                              .Build();

            newInstance.ByteProperty.Should().BeGreaterOrEqualTo(min);
            newInstance.ByteProperty.Should().BeLessOrEqualTo(max);
            newInstance.ByteNullableProperty.Should().BeGreaterOrEqualTo(min);
            newInstance.ByteNullableProperty.Should().BeLessOrEqualTo(max);
        }

        [Fact]
        public void Should_fill_char_property_successfully()
        {
            Assert.True(instance.CharProperty > 0);
        }

        [Fact]
        public void Should_fill_char_nullable_property_successfully()
        {
            Assert.True(instance.CharNullableProperty > 0);
        }

        [Fact]
        public void Should_fill_char_property_with_range_successfully()
        {
            var min = (char)10;
            var max = (char)100;

            var newInstance = new Builder<PrimitiveTypeOnlyClass>()
                              .WithMinNumberValueOf(min)
                              .WithMaxNumberValueOf(max)
                              .Build();

            newInstance.CharProperty.Should().BeGreaterOrEqualTo(min);
            newInstance.CharProperty.Should().BeLessOrEqualTo(max);
            Assert.True(newInstance.CharNullableProperty >= min);
            Assert.True(newInstance.CharNullableProperty <= max);
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
        public void Should_fill_int16_property_with_range_successfully()
        {
            var min = (short)100;
            var max = (short)1000;

            var newInstance = new Builder<PrimitiveTypeOnlyClass>()
                       .WithMinNumberValueOf(min)
                       .WithMaxNumberValueOf(max)
                       .Build();

            newInstance.Int16Property.Should().BeGreaterOrEqualTo(min);
            newInstance.Int16Property.Should().BeLessOrEqualTo(max);
            newInstance.Int16NullableProperty.Should().BeGreaterOrEqualTo(min);
            newInstance.Int16NullableProperty.Should().BeLessOrEqualTo(max);
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
        public void Should_fill_int32_property_with_range_successfully()
        {
            var min = short.MaxValue + 1;
            var max = min * 2;

            var newInstance = new Builder<PrimitiveTypeOnlyClass>()
                              .WithMinNumberValueOf(min)
                              .WithMaxNumberValueOf(max)
                              .Build();

            newInstance.Int32Property.Should().BeGreaterOrEqualTo(min);
            newInstance.Int32Property.Should().BeLessOrEqualTo(max);
            newInstance.Int32NullableProperty.Should().BeGreaterOrEqualTo(min);
            newInstance.Int32NullableProperty.Should().BeLessOrEqualTo(max);
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
        public void Should_fill_int64_property_with_range_successfully()
        {
            var min = short.MaxValue + 1;
            var max = min * 2;

            var newInstance = new Builder<PrimitiveTypeOnlyClass>()
                              .WithMinNumberValueOf(min)
                              .WithMaxNumberValueOf(max)
                              .Build();

            newInstance.Int64Property.Should().BeGreaterOrEqualTo(min);
            newInstance.Int64Property.Should().BeLessOrEqualTo(max);
            newInstance.Int64NullableProperty.Should().BeGreaterOrEqualTo(min);
            newInstance.Int64NullableProperty.Should().BeLessOrEqualTo(max);
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
        public void Should_fill_all_float_numbers_properties_with_range_successfully()
        {
            var min = 10;
            var max = 50;

            var newInstance = new Builder<PrimitiveTypeOnlyClass>()
                              .WithMinNumberValueOf(min)
                              .WithMaxNumberValueOf(max)
                              .Build();

            newInstance.FloatProperty.Should().BeGreaterOrEqualTo(min);
            newInstance.FloatProperty.Should().BeLessOrEqualTo(max);
            newInstance.FloatNullableProperty.Should().BeGreaterOrEqualTo(min);
            newInstance.FloatNullableProperty.Should().BeLessOrEqualTo(max);

            newInstance.DoubleProperty.Should().BeGreaterOrEqualTo(min);
            newInstance.DoubleProperty.Should().BeLessOrEqualTo(max);
            newInstance.DoubleNullableProperty.Should().BeGreaterOrEqualTo(min);
            newInstance.DoubleNullableProperty.Should().BeLessOrEqualTo(max);

            newInstance.DecimalProperty.Should().BeGreaterOrEqualTo(min);
            newInstance.DecimalProperty.Should().BeLessOrEqualTo(max);
            newInstance.DecimalNullableProperty.Should().BeGreaterOrEqualTo(min);
            newInstance.DecimalNullableProperty.Should().BeLessOrEqualTo(max);
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

        public byte ByteProperty { get; set; }
        public byte? ByteNullableProperty { get; set; }
        public char CharProperty { get; set; }
        public char? CharNullableProperty { get; set; }
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
