using Chess.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Application
{
    public static class PieceExtractor
    {
        public static Piece ToChessPiece(this ChessPiecePositionRequest chessPiecePositionRequest)
        {
            var isValid = Enum.TryParse(chessPiecePositionRequest.PieceName, true, out ChessPieces chessPiece);
            if (isValid == false)
                throw new BadRequestException($"The piece type {chessPiecePositionRequest.PieceName} does not exist in the context of chase");

            var position = new Position(chessPiecePositionRequest.InitialPosition);
            switch (chessPiece)
            {
                case ChessPieces.Pawn:
                    return new Pawn(position);

                case ChessPieces.King:
                    return new King(position);

                case ChessPieces.Queen:
                    return new Queen(position);

                case ChessPieces.Rook:
                    return new Rook(position);

                case ChessPieces.Bishop:
                    return new Bishop(position);

                case ChessPieces.Horse:
                    return new Horse(position);
                default:
                    throw new InvalidCastException($"{chessPiece.ToString()} is not implemented.");
            }
        }
    }
}
