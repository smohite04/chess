using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Domain
{
    public class Horse : Piece
    {
        public override string Name => ChessPieces.Horse.ToString();

        public override List<Position> GetPossiblePositions(Position initialPosition)
        {
            throw new NotImplementedException();
        }
    }
}
