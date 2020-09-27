using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Domain
{
    public abstract class Piece
    {
        public Piece(Position position)
        {
            CurrentPosition = position;
        }
        public abstract string Name { get; }
        public Position CurrentPosition { get; private set; }

        public abstract List<Position> GetPossiblePositions(IDirection direction);
    }
}
