﻿using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Chess.Domain.Tests
{
    public class PieceTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Piece_should_have_name(ChessPieces chessPiece)
        {
            if (chessPiece == ChessPieces.Horse)
            {
                var horse = new Horse();
                horse.Name.Should().BeEquivalentTo(chessPiece.ToString());
            }
            if (chessPiece == ChessPieces.Pawn)
            {
                var pawn = new Pawn();
                pawn.Name.Should().BeEquivalentTo(chessPiece.ToString());
            }
            if (chessPiece == ChessPieces.Rook)
            {
                var horse = new Rook();
                horse.Name.Should().BeEquivalentTo(chessPiece.ToString());
            }
            if (chessPiece == ChessPieces.Bishop)
            {
                var horse = new Bishop();
                horse.Name.Should().BeEquivalentTo(chessPiece.ToString());
            }
            if (chessPiece == ChessPieces.King)
            {
                var horse = new King();
                horse.Name.Should().BeEquivalentTo(chessPiece.ToString());
            }
            if (chessPiece == ChessPieces.Queen)
            {
                var horse = new Queen();
                horse.Name.Should().BeEquivalentTo(chessPiece.ToString());
            }

        }
        [Fact]
        public void Pawn_given_valid_coordinates_should_move_to_valid_co_ordinates()
        {
            var pawn = new Pawn();
            var initialPosition = new Position("A1");
           var possibleOutcomes = pawn.GetPossiblePositions(initialPosition);
            possibleOutcomes.Count.Should().Be(1);
            var data = possibleOutcomes.Select(x => x.CellPosition).ToList();
            data[0].Should().BeEquivalentTo("B1");
        }
        [Fact]
        public void Pawn_given_valid_coordinates_when_it_is_last_cell_should_not_return_any_coordinates()
        {
            var pawn = new Pawn();
            var initialPosition = new Position("H8");
            var possibleOutcomes = pawn.GetPossiblePositions(initialPosition);
            possibleOutcomes.Count.Should().Be(0);           
        }
        [Theory]
        [InlineData("E3", 8, "G2,G4,F5,D5,C4,C2,D1,F1")]
        [InlineData("A1", 2, "B3,C2")]
        [InlineData("H8", 2, "F7,G6")]
        [InlineData("H1", 2, "F2,G3")]
        public void Horse_given_valid_coordinates_should_move_to_valid_co_ordinates(string initialCellPosition, int expectedOutcomesCount, string expectedOutcomesStr)
        {
            var horse = new Horse();
            var initialPosition = new Position(initialCellPosition);
            var possibleOutcomes = horse.GetPossiblePositions(initialPosition);
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
