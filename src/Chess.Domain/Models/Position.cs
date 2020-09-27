using System;

namespace Chess.Domain
{
    /// <summary>
    /// This class defines co-ordinates on chess board. 
    /// </summary>
    public class Position
    {
        /// <summary>
        ///It defines the cell value of a board which is in notation of "A5", "E6" etc
        /// </summary>
        /// <param name="cellPosition"> chess cell notation for example, "E6"</param>
        public Position(string cellPosition)
        {
            cellPosition.ShouldBeValid(nameof(cellPosition), nameof(Position), Constants.Constructor);
            var (row, column) = cellPosition.ToCellCoOrdinates();

            row.ShouldBeValidNumber(Constants.ChessBoardUpperLimit, nameof(row), nameof(Position), Constants.Constructor);
            this.Row = row;

            column.ShouldBeValidNumber(Constants.ChessBoardUpperLimit, nameof(column), nameof(Position), Constants.Constructor);
            this.Column = column;

            CellPosition = cellPosition;
        }
        /// <summary>
        /// It defines the cell value of a board in a zero-based index notation
        /// </summary>
        /// <param name="row"> 0 based row value for cell</param>
        /// <param name="column"> 0 based column value for cell</param>
        public Position(int row, int column)
        {
            row.ShouldBeValidNumber(Constants.ChessBoardUpperLimit, nameof(row), nameof(Position), Constants.Constructor);
            this.Row = row;

            column.ShouldBeValidNumber(Constants.ChessBoardUpperLimit, nameof(column), nameof(Position), Constants.Constructor);
            this.Column = column;

            var first = row.NumberToAlphabet();
            CellPosition = $"{first}{(column + 1).ToString()}";
        }   
        public int Row { get; }
        public int Column { get; }
        public string CellPosition { get; }
    }
}
