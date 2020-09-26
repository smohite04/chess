using System.Collections.Generic;

namespace Chess.Domain
{
    public class Bishop : Piece
    {
        public override string Name => ChessPieces.Bishop.ToString();

        /// <summary>
        /// Bishop can move across the board only diagonally
        /// </summary>
        /// <param name="initialPosition"></param>
        /// <returns></returns>
        public override List<Position> GetPossiblePositions(Position initialPosition)
        {
            var possibleOutcomes = new List<Position>();
            var direction = new Direction();           
            possibleOutcomes.AddRange(direction.GetNorthEastPositions(initialPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetNorthWestPositions(initialPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetSouthEastPositions(initialPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetSouthWestPositions(initialPosition, Constants.ChessBoardUpperLimit));
            return possibleOutcomes;
        }
    }
}