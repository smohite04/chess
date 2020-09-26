using FluentAssertions;
using System;
using System.Collections.Generic;
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
