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
        [Theory]
        [InlineData("A1",3,3,"A2,A3,A4")]
        [InlineData("A6", 3, 2, "A7,A8")]
        [InlineData("A8", Constants.ChessBoardUpperLimit, 0, "")]
        [InlineData("H8", Constants.ChessBoardUpperLimit, 0, "")]
        public void GetEastDirections_when_valid_maxlimit_is_defined_and_its_within_uppar_limit_of_chessboard_should_give_valid_positions(string initialPosition, uint MaxMovementRequested, int expectedOutcomeCount, string expectedPositionsStr)
        {
            var direction = new Direction();
            var values = direction.GetEastPositions(new Position(initialPosition), MaxMovementRequested);
            values.Count.Should().Be(expectedOutcomeCount);
            var positions = values.Select(x => x.CellPosition).ToList();
            var expectedPossibleOutcomes = expectedPositionsStr.Split(",",StringSplitOptions.RemoveEmptyEntries);
            if(expectedPossibleOutcomes.Length>0)
                positions.Should().Contain(expectedPossibleOutcomes);
        }       
        [Theory]
        [InlineData("A4", 3, 3, "A3,A2,A1")]
        [InlineData("A3", 3, 2, "A2,A1")]
        [InlineData("A1", Constants.ChessBoardUpperLimit, 0, "")]
        [InlineData("H1", Constants.ChessBoardUpperLimit, 0, "")]
        public void GetWestDirections_when_valid_maxlimit_is_defined_and_its_within_uppar_limit_of_chessboard_should_give_valid_positions(string initialPosition, uint MaxMovementRequested, int expectedOutcomeCount, string expectedPositionsStr)
        {
            var direction = new Direction();
            var values = direction.GetWestPositions(new Position(initialPosition), MaxMovementRequested);
            values.Count.Should().Be(expectedOutcomeCount);
            var positions = values.Select(x => x.CellPosition).ToList();
            var expectedPossibleOutcomes = expectedPositionsStr.Split(",", StringSplitOptions.RemoveEmptyEntries);
            if (expectedPossibleOutcomes.Length > 0)
                positions.Should().Contain(expectedPossibleOutcomes);
        }

        [Theory]
        [InlineData("C4", 3, 3, "D4,E4,F4")]
        [InlineData("F6", 3, 2, "G6,H6")]
        [InlineData("H8", Constants.ChessBoardUpperLimit, 0, "")]
        [InlineData("H1", Constants.ChessBoardUpperLimit, 0, "")]
        public void GetNorthDirections_when_valid_maxlimit_is_defined_and_its_within_uppar_limit_of_chessboard_should_give_valid_positions(string initialPosition, uint MaxMovementRequested, int expectedOutcomeCount, string expectedPositionsStr)
        {
            var direction = new Direction();
            var values = direction.GetNorthPositions(new Position(initialPosition), MaxMovementRequested);
            values.Count.Should().Be(expectedOutcomeCount);
            var positions = values.Select(x => x.CellPosition).ToList();
            var expectedPossibleOutcomes = expectedPositionsStr.Split(",", StringSplitOptions.RemoveEmptyEntries);
            if (expectedPossibleOutcomes.Length > 0)
                positions.Should().Contain(expectedPossibleOutcomes);
        }
        [Theory]
        [InlineData("D4", 3, 3, "C4,B4,A4")]
        [InlineData("C6", 3, 2, "B6,A6")]
        [InlineData("A8", Constants.ChessBoardUpperLimit, 0, "")]
        [InlineData("A1", Constants.ChessBoardUpperLimit, 0, "")]
        public void GetSouthDirections_when_valid_maxlimit_is_defined_and_its_within_uppar_limit_of_chessboard_should_give_valid_positions(string initialPosition, uint MaxMovementRequested, int expectedOutcomeCount, string expectedPositionsStr)
        {
            var direction = new Direction();
            var values = direction.GetSouthPositions(new Position(initialPosition), MaxMovementRequested);
            values.Count.Should().Be(expectedOutcomeCount);
            var positions = values.Select(x => x.CellPosition).ToList();
            var expectedPossibleOutcomes = expectedPositionsStr.Split(",", StringSplitOptions.RemoveEmptyEntries);
            if (expectedPossibleOutcomes.Length > 0)
                positions.Should().Contain(expectedPossibleOutcomes);
        }
        [Theory]
        [InlineData("A1", 3, 3, "B2,C3,D4")]
        [InlineData("F6", 3, 2, "G7,H8")]
        [InlineData("A8", Constants.ChessBoardUpperLimit, 0, "")]
        [InlineData("H1", Constants.ChessBoardUpperLimit, 0, "")]
        public void GetNorthEastDirections_when_valid_maxlimit_is_defined_and_its_within_uppar_limit_of_chessboard_should_give_valid_positions(string initialPosition, uint MaxMovementRequested, int expectedOutcomeCount, string expectedPositionsStr)
        {
            var direction = new Direction();
            var values = direction.GetNorthEastPositions(new Position(initialPosition), MaxMovementRequested);
            values.Count.Should().Be(expectedOutcomeCount);
            var positions = values.Select(x => x.CellPosition).ToList();
            var expectedPossibleOutcomes = expectedPositionsStr.Split(",", StringSplitOptions.RemoveEmptyEntries);
            if (expectedPossibleOutcomes.Length > 0)
                positions.Should().Contain(expectedPossibleOutcomes);
        }
        [Theory]
        [InlineData("A8", 3, 3, "B7,C6,D5")]
        [InlineData("F3", 3, 2, "G2,H1")]
        [InlineData("H8", Constants.ChessBoardUpperLimit, 0, "")]
        [InlineData("H1", Constants.ChessBoardUpperLimit, 0, "")]
        public void GetNorthWestDirections_when_valid_maxlimit_is_defined_and_its_within_uppar_limit_of_chessboard_should_give_valid_positions(string initialPosition, uint MaxMovementRequested, int expectedOutcomeCount, string expectedPositionsStr)
        {
            var direction = new Direction();
            var values = direction.GetNorthWestPositions(new Position(initialPosition), MaxMovementRequested);
            values.Count.Should().Be(expectedOutcomeCount);
            var positions = values.Select(x => x.CellPosition).ToList();
            var expectedPossibleOutcomes = expectedPositionsStr.Split(",", StringSplitOptions.RemoveEmptyEntries);
            if (expectedPossibleOutcomes.Length > 0)
                positions.Should().Contain(expectedPossibleOutcomes);
        }
        [Theory]
        [InlineData("H1", 3, 3, "G2,F3,E4")]
        [InlineData("D7", 3, 1, "C8")]
        [InlineData("F6", 7, 2, "E7,D8")]
        [InlineData("A8", Constants.ChessBoardUpperLimit, 0, "")]
        [InlineData("H8", Constants.ChessBoardUpperLimit, 0, "")]
        public void GetSouthEastDirections_when_valid_maxlimit_is_defined_and_its_within_uppar_limit_of_chessboard_should_give_valid_positions(string initialPosition, uint MaxMovementRequested, int expectedOutcomeCount, string expectedPositionsStr)
        {
            var direction = new Direction();
            var values = direction.GetSouthEastPositions(new Position(initialPosition), MaxMovementRequested);
            values.Count.Should().Be(expectedOutcomeCount);
            var positions = values.Select(x => x.CellPosition).ToList();
            var expectedPossibleOutcomes = expectedPositionsStr.Split(",", StringSplitOptions.RemoveEmptyEntries);
            if (expectedPossibleOutcomes.Length > 0)
                positions.Should().Contain(expectedPossibleOutcomes);
        }
        [Theory]
        [InlineData("H8", 3, 3, "G7,F6,E5")]
        [InlineData("F3", 3, 2, "E2,D1")]
        [InlineData("C5", 7, 2, "B4,A3")]
        [InlineData("F1", Constants.ChessBoardUpperLimit, 0, "")]
        [InlineData("E1", Constants.ChessBoardUpperLimit, 0, "")]
        public void GetSouthWestDirections_when_valid_maxlimit_is_defined_and_its_within_uppar_limit_of_chessboard_should_give_valid_positions(string initialPosition, uint MaxMovementRequested, int expectedOutcomeCount, string expectedPositionsStr)
        {
            var direction = new Direction();
            var values = direction.GetSouthWestPositions(new Position(initialPosition), MaxMovementRequested);
            values.Count.Should().Be(expectedOutcomeCount);
            var positions = values.Select(x => x.CellPosition).ToList();
            var expectedPossibleOutcomes = expectedPositionsStr.Split(",", StringSplitOptions.RemoveEmptyEntries);
            if (expectedPossibleOutcomes.Length > 0)
                positions.Should().Contain(expectedPossibleOutcomes);
        }
    }
}
