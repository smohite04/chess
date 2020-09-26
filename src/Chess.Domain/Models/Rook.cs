using System.Collections.Generic;

namespace Chess.Domain
{
    public class Rook : Piece
    {
        public override string Name => ChessPieces.Rook.ToString();

        public override List<Position> GetPossiblePositions(Position initialPosition)
        {
            throw new System.NotImplementedException();
        }
    }
}