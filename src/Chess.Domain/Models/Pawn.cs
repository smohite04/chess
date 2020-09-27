using System.Collections.Generic;

namespace Chess.Domain
{
    public class Pawn : Piece
    {
        public Pawn(Position position) : base(position)
        {
        }

        public override string Name => ChessPieces.Pawn.ToString();

        /// <summary>
        /// Pawn can move only forward by one cell.
        /// </summary>
        /// <param name="initialPosition"></param>
        /// <returns></returns>
        public override List<Position> GetPossiblePositions(IDirection direction)
        {
           return direction.GetNorthPositions(CurrentPosition, 1);
        }
    }
}