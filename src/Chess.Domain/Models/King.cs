using System.Collections.Generic;

namespace Chess.Domain
{
    public class King : Piece
    {
        public override string Name => ChessPieces.King.ToString();
        /// <summary>
        /// This gives possible movements of King.
        /// King can move only 1 step at a time in all 8 directions (horizontal, vertical and diagonal)
        /// </summary>
        /// <param name="initialPosition"></param>
        /// <returns></returns>
        public override List<Position> GetPossiblePositions(Position initialPosition)
        {
            var possibleOutcomes = new List<Position>();
            var direction = new Direction();
            possibleOutcomes.AddRange(direction.GetEastPositions(initialPosition, 1));
            possibleOutcomes.AddRange(direction.GetWestPositions(initialPosition, 1));
            possibleOutcomes.AddRange(direction.GetNorthPositions(initialPosition, 1));
            possibleOutcomes.AddRange(direction.GetSouthPositions(initialPosition, 1));
            possibleOutcomes.AddRange(direction.GetNorthEastPositions(initialPosition, 1));
            possibleOutcomes.AddRange(direction.GetNorthWestPositions(initialPosition, 1));
            possibleOutcomes.AddRange(direction.GetSouthEastPositions(initialPosition, 1));
            possibleOutcomes.AddRange(direction.GetSouthWestPositions(initialPosition, 1));
            return possibleOutcomes;
        }
    }
}