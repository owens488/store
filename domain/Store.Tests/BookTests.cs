using System;
using Xunit;

namespace Store.Tests
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            bool actual1 = Book.IsIsbn(null);

            Assert.False(actual1);   
        }

        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            bool actual1 = Book.IsIsbn("   ");

            Assert.False(actual1);
        }

        [Fact]
        public void IsIsbn_WithIvalidIsbn_ReturnFalse()
        {
            bool actual1 = Book.IsIsbn("ISBN 123");

            Assert.False(actual1);
        }

        [Fact]
        public void IsIsbn_WithIsbn10_ReturnTrue()
        {
            bool actual1 = Book.IsIsbn("Isbn 123-456-789 0");

            Assert.True(actual1);
        }

        [Fact]
        public void IsIsbn_WithIsbn13_ReturnTrue()
        {
            bool actual1 = Book.IsIsbn("Isbn 123-456-789 0");

            Assert.True(actual1);
        }

        [Fact]
        public void IsIsbn_WithTrashStart_ReturnFalse()
        {
            bool actual1 = Book.IsIsbn("xxx Isbn 123-456-789 0123 xxx");

            Assert.False(actual1);
        }
    }
}