using System.Collections.Generic;

namespace Chess.Domain
{
    public class King : Piece
    {
        public override string Name => ChessPieces.King.ToString();

        public override List<Position> GetPossiblePositions(Position initialPosition)
        {
            throw new System.NotImplementedException();
        }
    }
}