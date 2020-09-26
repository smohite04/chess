using System.Collections.Generic;

namespace Chess.Domain
{
    public class Queen : Piece
    {
        public override string Name => ChessPieces.Queen.ToString();

        public override List<Position> GetPossiblePositions(Position initialPosition)
        {
            throw new System.NotImplementedException();
        }
    }
}