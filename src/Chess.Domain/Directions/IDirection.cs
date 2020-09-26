using System.Collections.Generic;
using System.Text;

namespace Chess.Domain
{
    /// <summary>
    /// Defines the movement in any direction for a chess board
    /// </summary>
    public interface IDirection
    {
        List<Position> GetNorthPositions(Position initialPosition, uint maxMovementLimit);
        List<Position> GetSouthPositions(Position initialPosition, uint maxMovementLimit);
        List<Position> GetEastPositions(Position initialPosition, uint maxMovementLimit);
        List<Position> GetWestPositions(Position initialPosition, uint maxMovementLimit);
        List<Position> GetNorthEastPositions(Position initialPosition, uint maxMovementLimit);
        List<Position> GetNorthWestPositions(Position initialPosition, uint maxMovementLimit);
        List<Position> GetSouthEastPositions(Position initialPosition, uint maxMovementLimit);
        List<Position> GetSouthWestPositions(Position initialPosition, uint maxMovementLimit);
    }
}
