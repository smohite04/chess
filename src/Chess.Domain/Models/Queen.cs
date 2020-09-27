using System.Collections.Generic;

namespace Chess.Domain
{
    public class Queen : Piece
    {
        public Queen(Position position, PieceColours pieceColor) : base(position, pieceColor)
        {
        }

        public override string Name => ChessPieces.Queen.ToString();
        /// <summary>
        /// Queen can move across the board in all 8 directions
        /// </summary>
        /// <param name="initialPosition"></param>
        /// <returns></returns>
        public override List<Position> GetPossiblePositions(IDirection direction)
        {
            var possibleOutcomes = new List<Position>();
            possibleOutcomes.AddRange(direction.GetEastPositions(CurrentPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetWestPositions(CurrentPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetNorthPositions(CurrentPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetSouthPositions(CurrentPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetNorthEastPositions(CurrentPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetNorthWestPositions(CurrentPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetSouthEastPositions(CurrentPosition, Constants.ChessBoardUpperLimit));
            possibleOutcomes.AddRange(direction.GetSouthWestPositions(CurrentPosition, Constants.ChessBoardUpperLimit));
            return possibleOutcomes;
        }
    }
}