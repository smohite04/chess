using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Domain
{
    public abstract class Piece
    {
        public Piece(Position position, PieceColours color)
        {
            CurrentPosition = position;
            Color = color;
        }
        public abstract string Name { get; }
        public Position CurrentPosition { get; private set; }
        public PieceColours Color { get; }

        public abstract List<Position> GetPossiblePositions(IDirection direction);
    }
}
