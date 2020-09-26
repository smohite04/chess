using FluentAssertions;
using System;
using Xunit;

namespace Chess.Domain.Tests
{
    public class PositionTests
    {
        [Theory]
        [InlineData("A1")]
        [InlineData("D5")]
        [InlineData("H8")]
        public void Position_should_be_able_to_accept_valid_co_ordinates_on_chess_board(string value)
        {
            var position = new Position(value);
            position.Should().NotBeNull();
        }
        [Theory]
        [InlineData("Z8")]
        [InlineData("A9")]
        [InlineData("S9")]
        [InlineData("")]
        [InlineData("H10")]
        public void Position_should_throw_exception_for_invalid_co_ordinates_on_chess_board(string value)
        {
            Action error = ()=> new Position(value);
            Assert.ThrowsAny<Exception>(error);      
        }
    }
}
