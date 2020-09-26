using System.Collections.Generic;

namespace Chess.Domain
{
    public class Rook : Piece
    {
        public override string Name => ChessPieces.Rook.ToString();

        public override List<Position> GetPossiblePositions(Position initialPosition)
        {
            var possibleOutcomes = new List<Position>();
            var direction = new Direction();
            possibleOutcomes.AddRange(direction.GetEastPositions(initialPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetWestPositions(initialPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetNorthPositions(initialPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetSouthPositions(initialPosition, Constants.ChessBoardUpperLimit));           
            return possibleOutcomes;
        }
    }
}