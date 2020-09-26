using System.Collections.Generic;

namespace Chess.Domain
{
    public class Pawn : Piece
    {
        public override string Name => ChessPieces.Pawn.ToString();

        public override List<Position> GetPossiblePositions(Position initialPosition)
        {
            throw new System.NotImplementedException();
        }
    }
}