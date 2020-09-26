using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Domain
{
    public abstract class Piece
    {
        public abstract string Name { get; }

        public abstract List<Position> GetPossiblePositions(Position initialPosition,IDirection direction);
    }
}
