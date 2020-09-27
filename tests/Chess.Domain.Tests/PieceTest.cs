using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Chess.Domain.Tests
{
    public class PieceTest
    {
        private readonly Direction _direction;

        public PieceTest()
        {
           _direction =  new Direction(); 
        }
        [Theory]
        [MemberData(nameof(Data))]
        public void Piece_should_have_name_and_initial_position_and_defined_colour(ChessPieces chessPiece)
        {
            var position = new Position("D5");
            if (chessPiece == ChessPieces.Horse)
            {
                var horse = new Horse(position, PieceColours.White);
                horse.Name.Should().BeEquivalentTo(chessPiece.ToString());
                horse.CurrentPosition.Equals(position);
            }
            if (chessPiece == ChessPieces.Pawn)
            {
                var pawn = new Pawn(position, PieceColours.White);
                pawn.Name.Should().BeEquivalentTo(chessPiece.ToString());
                pawn.CurrentPosition.Equals(position);
            }
            if (chessPiece == ChessPieces.Rook)
            {
                var horse = new Rook(position,PieceColours.White);
                horse.Name.Should().BeEquivalentTo(chessPiece.ToString());
                horse.CurrentPosition.Equals(position);
            }
            if (chessPiece == ChessPieces.Bishop)
            {
                var bishop = new Bishop(position, PieceColours.White);
                bishop.Name.Should().BeEquivalentTo(chessPiece.ToString());
                bishop.CurrentPosition.Equals(position);
            }
            if (chessPiece == ChessPieces.King)
            {
                var king = new King(position, PieceColours.White);
                king.Name.Should().BeEquivalentTo(chessPiece.ToString());
                king.CurrentPosition.Equals(position);
            }
            if (chessPiece == ChessPieces.Queen)
            {
                var queen = new Queen(position, PieceColours.Black);
                queen.Name.Should().BeEquivalentTo(chessPiece.ToString());
                queen.CurrentPosition.Equals(position);
            }

        }
        [Theory]
        [InlineData("H8", 0, "")]
        [InlineData("A1", 1, "B1")]
        [InlineData("B7", 1, "C7")]
        public void White_Pawn_given_valid_coordinates_should_move_to_valid_co_ordinates(string initialCellPosition, int expectedOutcomesCount, string expectedOutcome)
        {           
            var initialPosition = new Position(initialCellPosition);
            var pawn = new Pawn(initialPosition, PieceColours.White);
            var possibleOutcomes = pawn.GetPossiblePositions(_direction);
            possibleOutcomes.Count.Should().Be(expectedOutcomesCount);
            if (expectedOutcomesCount > 0)
            {
                var data = possibleOutcomes.Select(x => x.CellPosition).ToList();
                data[0].Should().BeEquivalentTo(expectedOutcome);
            }
        }
        [Theory]
        [InlineData("H8", 1, "G8")]
        [InlineData("A1", 0, "")]
        [InlineData("E5", 1, "D5")]
        public void Black_Pawn_given_valid_coordinates_should_move_to_valid_co_ordinates(string initialCellPosition, int expectedOutcomesCount, string expectedOutcome)
        {
            var initialPosition = new Position(initialCellPosition);
            var pawn = new Pawn(initialPosition, PieceColours.Black);
            var possibleOutcomes = pawn.GetPossiblePositions(_direction);
            possibleOutcomes.Count.Should().Be(expectedOutcomesCount);
            if (expectedOutcomesCount > 0)
            {
                var data = possibleOutcomes.Select(x => x.CellPosition).ToList();
                data[0].Should().BeEquivalentTo(expectedOutcome);
            }
        }
        [Theory]
        [InlineData("E3", 8, "G2,G4,F5,D5,C4,C2,D1,F1")]
        [InlineData("A1", 2, "B3,C2")]
        [InlineData("H8", 2, "F7,G6")]
        [InlineData("H1", 2, "F2,G3")]
        public void Horse_given_valid_coordinates_should_move_to_valid_co_ordinates(string initialCellPosition, int expectedOutcomesCount, string expectedOutcomesStr)
        {
            var initialPosition = new Position(initialCellPosition);
            var horse = new Horse(initialPosition, PieceColours.Black);        
            var possibleOutcomes = horse.GetPossiblePositions(_direction);
            possibleOutcomes.Count.Should().Be(expectedOutcomesCount);
            var positions = possibleOutcomes.Select(x => x.CellPosition).ToList();
            var expectedPossibleOutcomes = expectedOutcomesStr.Split(",", StringSplitOptions.RemoveEmptyEntries);
            positions.Should().Contain(expectedPossibleOutcomes);
        }
        [Theory]
        [InlineData("D5", 8, "E5,E6,D6,C6,C5,C4,D4,E4")]
        [InlineData("A1", 3, "A2,B2,B1")]
        [InlineData("H8", 3, "H7,G7,G8")]
        [InlineData("G1", 5, "H1,H2,G2,F2,F1")]
        public void King_given_valid_coordinates_should_move_to_valid_co_ordinates(string initialCellPosition, int expectedOutcomesCount, string expectedOutcomesStr)
        {
            var initialPosition = new Position(initialCellPosition);
            var king = new King(initialPosition, PieceColours.Black);
            var possibleOutcomes = king.GetPossiblePositions(_direction);
            possibleOutcomes.Count.Should().Be(expectedOutcomesCount);
            var positions = possibleOutcomes.Select(x => x.CellPosition).ToList();
            var expectedPossibleOutcomes = expectedOutcomesStr.Split(",", StringSplitOptions.RemoveEmptyEntries);
            positions.Should().Contain(expectedPossibleOutcomes);
        }
        [Theory]
        [InlineData("H1", 21, "H2,H3,H4,H5,H6,H7,H8,G1,F1,E1,D1,C1,B1,A1,G2,F3,E4,D5,C6,B7,A8")]
        [InlineData("C4", 25, "A4,B4,D4,E4,F4,G4,H4,C1,C2,C3,C5,C6,C7,C8,A2,B3,D5,E6,F7,G8,F1,E2,D3,B5,A6")]
        [InlineData("D4", 27, "A4,B4,C4,E4,F4,G4,H4,D1,D2,D3,D5,D6,D7,D8,A1,B2,C3,E5,F6,G7,H8,G1,F2,E3,C5,B6,A7")]
        public void Queen_given_valid_coordinates_should_move_to_valid_co_ordinates(string initialCellPosition, int expectedOutcomesCount, string expectedOutcomesStr)
        {
            var initialPosition = new Position(initialCellPosition);
            var queen = new Queen(initialPosition, PieceColours.White);
            var possibleOutcomes = queen.GetPossiblePositions(_direction);
            possibleOutcomes.Count.Should().Be(expectedOutcomesCount);
            var positions = possibleOutcomes.Select(x => x.CellPosition).ToList();
            var expectedPossibleOutcomes = expectedOutcomesStr.Split(",", StringSplitOptions.RemoveEmptyEntries);
            positions.Should().Contain(expectedPossibleOutcomes);
        }
        [Theory]
        [InlineData("H1", 14, "H2,H3,H4,H5,H6,H7,H8,G1,F1,E1,D1,C1,B1,A1")]
        [InlineData("C4", 14, "A4,B4,D4,E4,F4,G4,H4,C1,C2,C3,C5,C6,C7,C8")]
        [InlineData("D4", 14, "A4,B4,C4,E4,F4,G4,H4,D1,D2,D3,D5,D6,D7,D8")]
        public void Rook_given_valid_coordinates_should_move_to_valid_co_ordinates(string initialCellPosition, int expectedOutcomesCount, string expectedOutcomesStr)
        {
            var initialPosition = new Position(initialCellPosition);
            var rook = new Rook(initialPosition,PieceColours.White);
            var possibleOutcomes = rook.GetPossiblePositions(_direction);
            possibleOutcomes.Count.Should().Be(expectedOutcomesCount);
            var positions = possibleOutcomes.Select(x => x.CellPosition).ToList();
            var expectedPossibleOutcomes = expectedOutcomesStr.Split(",", StringSplitOptions.RemoveEmptyEntries);
            positions.Should().Contain(expectedPossibleOutcomes);
        }
        [Theory]
        [InlineData("H1", 7, "G2,F3,E4,D5,C6,B7,A8")]
        [InlineData("C4", 11, "A2,B3,D5,E6,F7,G8,F1,E2,D3,B5,A6")]
        [InlineData("D4", 13, "A1,B2,C3,E5,F6,G7,H8,G1,F2,E3,C5,B6,A7")]
        public void Bishop_given_valid_coordinates_should_move_to_valid_co_ordinates(string initialCellPosition, int expectedOutcomesCount, string expectedOutcomesStr)
        {
            var initialPosition = new Position(initialCellPosition);
            var bishop = new Bishop(initialPosition, PieceColours.White);
            var possibleOutcomes = bishop.GetPossiblePositions(_direction);
            possibleOutcomes.Count.Should().Be(expectedOutcomesCount);
            var positions = possibleOutcomes.Select(x => x.CellPosition).ToList();
            var expectedPossibleOutcomes = expectedOutcomesStr.Split(",", StringSplitOptions.RemoveEmptyEntries);
            positions.Should().Contain(expectedPossibleOutcomes);
        }
        public static IEnumerable<object[]> Data()
        {
           return new List<object[]> {
               new object[]{ ChessPieces.Pawn },
               new object[]{ ChessPieces.Horse},
               new object[]{ ChessPieces.King },
               new object[]{ ChessPieces.Queen},
               new object[]{ ChessPieces.Rook },
               new object[]{ ChessPieces.Bishop},
           };
        }
    }
}
