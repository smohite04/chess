using System;

namespace Chess.Domain
{
    public class Position
    {
        private int _row;
        private int _column;

        public Position(int row, int column)
        {
            row.ShouldBeValidNumber(Constants.ChessBoardUpperLimit, nameof(row), nameof(Position),Constants.Constructor);
            this._row = row;
            column.ShouldBeValidNumber(Constants.ChessBoardUpperLimit, nameof(column), nameof(Position), Constants.Constructor);
            this._column = column;
        }
    }
}
