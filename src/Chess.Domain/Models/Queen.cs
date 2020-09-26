using System.Collections.Generic;

namespace Chess.Domain
{
    public class Queen : Piece
    {
        public override string Name => ChessPieces.Queen.ToString();
        /// <summary>
        /// Queen can move across the board in all 8 directions
        /// </summary>
        /// <param name="initialPosition"></param>
        /// <returns></returns>
        public override List<Position> GetPossiblePositions(Position initialPosition, IDirection direction)
        {
            var possibleOutcomes = new List<Position>();
            possibleOutcomes.AddRange(direction.GetEastPositions(initialPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetWestPositions(initialPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetNorthPositions(initialPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetSouthPositions(initialPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetNorthEastPositions(initialPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetNorthWestPositions(initialPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetSouthEastPositions(initialPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetSouthWestPositions(initialPosition, Constants.ChessBoardUpperLimit));
            return possibleOutcomes;
        }
    }
}