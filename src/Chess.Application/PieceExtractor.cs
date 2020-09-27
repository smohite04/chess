using Chess.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Application
{
    public static class PieceExtractor
    {
        private static readonly Dictionary<ChessPieces, Piece> _ChessPieceMappings = new Dictionary<ChessPieces, Piece> {
            { ChessPieces.Pawn,new Pawn()},
            { ChessPieces.King,new King()},
            { ChessPieces.Queen,new Queen()},
            { ChessPieces.Rook,new Rook()},
            { ChessPieces.Bishop,new Bishop()},
            { ChessPieces.Horse,new Horse()},
        };
        public static Piece ToChessPiece(this string pieceName)
        {
            var isValid = Enum.TryParse(pieceName, out ChessPieces chessPiece);
            if (isValid == false)
                throw new BadRequestException($"The piece type {pieceName} does not exist in the context of chase");

            return _ChessPieceMappings[chessPiece];
        }
    }
}
