using System.Collections.Generic;

namespace Chess.Domain
{
    public class Pawn : Piece
    {
        public Pawn(Position position, PieceColours pieceColor) : base(position, pieceColor)
        {
        }

        public override string Name => ChessPieces.Pawn.ToString();

        /// <summary>
        /// Pawn can move only forward by one cell.
        /// White pawn can move forward from A to H as per chess boards location.
        /// Black pawn can move from H to A as per chess boards default location.
        /// </summary>
        /// <param name="initialPosition"></param>
        /// <returns></returns>
        public override List<Position> GetPossiblePositions(IDirection direction)
        {
            if(Color == PieceColours.White)
                return direction.GetNorthPositions(CurrentPosition, 1);
            else
                return direction.GetSouthPositions(CurrentPosition, 1);
        }
    }
}