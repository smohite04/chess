using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Chess.Domain.Tests
{
    public class DirectionTests
    {
        [Fact]
        public void GetEastDirections_when_valid_maxlimit_is_defined_and_its_within_uppar_limit_of_chessboard_should_give_valid_positions()
        {
            var direction = new Direction();
            var values = direction.GetEastPositions(new Position("A1"), 3);
            values.Count.Should().Be(3);
            var positions = values.Select(x => x.CellPosition).ToList();
            positions.Should().Contain(new List<string> { "A2", "A3", "A4" });
        }
        [Fact]
        public void GetEastDirections_when_valid_maxlimit_is_defined_should_give_valid_positions_till_the_limit_is_exhausted()
        {
            var direction = new Direction();
            var values = direction.GetEastPositions(new Position("A6"), 3);
            values.Count.Should().Be(2);
            var positions = values.Select(x => x.CellPosition).ToList();
            positions.Should().Contain(new List<string> { "A7", "A8" });
        }
        [Fact]
        public void GetEastDirections_when_initial_postion_is_last_position_do_not_return_any_values()
        {
            var direction = new Direction();
            var values = direction.GetEastPositions(new Position("A8"),Constants.ChessBoardUpperLimit);
            values.Count.Should().Be(0);
        }
    }
}
