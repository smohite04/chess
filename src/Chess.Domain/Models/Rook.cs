using System.Collections.Generic;

namespace Chess.Domain
{
    public class Rook : Piece
    {
        public Rook(Position position, PieceColours pieceColor) : base(position, pieceColor)
        {
        }

        public override string Name => ChessPieces.Rook.ToString();

        public override List<Position> GetPossiblePositions(IDirection direction)
        {
            var possibleOutcomes = new List<Position>();
            possibleOutcomes.AddRange(direction.GetEastPositions(CurrentPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetWestPositions(CurrentPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetNorthPositions(CurrentPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetSouthPositions(CurrentPosition, Constants.ChessBoardUpperLimit));           
            return possibleOutcomes;
        }
    }
}