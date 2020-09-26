using System.Collections.Generic;

namespace Chess.Domain
{
    public class Pawn : Piece
    {
        public override string Name => ChessPieces.Pawn.ToString();

        /// <summary>
        /// Pawn can move only forward by one cell.
        /// </summary>
        /// <param name="initialPosition"></param>
        /// <returns></returns>
        public override List<Position> GetPossiblePositions(Position initialPosition)
        {
            var direction = new Direction();
            var possibleOutcomes = direction.GetNorthPositions(initialPosition, 1);
            return possibleOutcomes;
        }
    }
}