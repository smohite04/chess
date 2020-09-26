using System.Collections.Generic;

namespace Chess.Domain
{
    public class Bishop : Piece
    {
        public override string Name => ChessPieces.Bishop.ToString();

        public override List<Position> GetPossiblePositions(Position initialPosition)
        {
            throw new System.NotImplementedException();
        }
    }
}