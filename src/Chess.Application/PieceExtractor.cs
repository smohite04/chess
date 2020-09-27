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
            //Create piece with default white colour
            switch (chessPiece)
            {
                case ChessPieces.Pawn:
                    return new Pawn(position, PieceColours.White);

                case ChessPieces.King:
                    return new King(position, PieceColours.White);

                case ChessPieces.Queen:
                    return new Queen(position, PieceColours.White);

                case ChessPieces.Rook:
                    return new Rook(position, PieceColours.White);

                case ChessPieces.Bishop:
                    return new Bishop(position, PieceColours.White);

                case ChessPieces.Horse:
                    return new Horse(position, PieceColours.White);
                default:
                    throw new InvalidCastException($"{chessPiece.ToString()} is not implemented.");
            }
        }
    }
}
