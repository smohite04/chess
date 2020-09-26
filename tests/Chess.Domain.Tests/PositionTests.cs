using FluentAssertions;
using System;
using Xunit;

namespace Chess.Domain.Tests
{
    public class PositionTests
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(7, 7)]
        [InlineData(4, 5)]
        public void Position_should_be_able_to_accept_valid_co_ordinates_on_chess_board(int row, int column)
        {
            var position = new Position(row, column);
            position.Should().NotBeNull();
        }
        [Theory]
        [InlineData(-1, 0)]
        [InlineData(7, 8)]
        [InlineData(0, 8)]
        public void Position_should_throw_exception_for_invalid_co_ordinates_on_chess_board(int row, int column)
        {
            Action error = ()=> new Position(row, column);
            Assert.Throws<ArgumentOutOfRangeException>(error);        
        }
    }
}
