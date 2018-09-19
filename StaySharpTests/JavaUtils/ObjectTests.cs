namespace StaySharpTests.JavaUtils
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using FluentAssertions;
    using StaySharp.JavaUtils;
    using Xunit;

    public class ObjectTests
    {
        [Fact]
        public void Hash_ArrayIsNull_0Returned()
        {
            // Act
            var hash = Objects.Hash(null);

            // Assert
            hash.Should().Be(0);
        }

        [Fact]
        public void Hash_ArrayIsEmpty_1Returned()
        {
            // Act
            var hash = Objects.Hash();

            // Assert
            hash.Should().Be(1);
        }

        [Fact]
        public void Hash_ArrayIsFilled_HashReturnedAndNotEqualToHashOfSingleContent()
        {
            // Arrange
            var array1 = new[] {1, 2};
            var array2 = new[] { 3, 4 };

            // Act
            var hash1 = Objects.Hash(array1);
            var hash2 = Objects.Hash(array2);

            // Assert
            hash1.Should().NotBe(1.GetHashCode());
            hash1.Should().NotBe(2.GetHashCode());
            hash1.Should().NotBe(0);
            hash1.Should().NotBe(1);
            hash1.Should().NotBe(hash2);
        }

        [Fact]
        public void RequireNonNull_ObjectIsNull_ArgumentNullExceptionThrown()
        {
            // Arrange
            object @object = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => @object.RequireNonNull());
        }

        [Fact]
        public void RequireNonNull_ObjectIsNotNull_NoExceptionThrownAndObjectReturned()
        {
            // Arrange
            var @object = new object();

            // Act
            var result = @object.RequireNonNull();

            // Assert
            result.Should().Be(@object);
        }
    }
}