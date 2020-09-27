using System.Collections.Generic;

namespace Chess.Domain
{
    public class King : Piece
    {
        public King(Position position) : base(position)
        {
        }

        public override string Name => ChessPieces.King.ToString();
        /// <summary>
        /// This gives possible movements of King.
        /// King can move only 1 step at a time in all 8 directions (horizontal, vertical and diagonal)
        /// </summary>
        /// <param name="initialPosition"></param>
        /// <returns></returns>
        public override List<Position> GetPossiblePositions(IDirection direction)
        {
            var possibleOutcomes = new List<Position>();
            possibleOutcomes.AddRange(direction.GetEastPositions(CurrentPosition, 1));
            possibleOutcomes.AddRange(direction.GetWestPositions(CurrentPosition, 1));
            possibleOutcomes.AddRange(direction.GetNorthPositions(CurrentPosition, 1));
            possibleOutcomes.AddRange(direction.GetSouthPositions(CurrentPosition, 1));
            possibleOutcomes.AddRange(direction.GetNorthEastPositions(CurrentPosition, 1));
            possibleOutcomes.AddRange(direction.GetNorthWestPositions(CurrentPosition, 1));
            possibleOutcomes.AddRange(direction.GetSouthEastPositions(CurrentPosition, 1));
            possibleOutcomes.AddRange(direction.GetSouthWestPositions(CurrentPosition, 1));
            return possibleOutcomes;
        }
    }
}