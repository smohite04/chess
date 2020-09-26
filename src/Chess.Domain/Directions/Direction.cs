using System;
using System.Collections.Generic;

namespace Chess.Domain
{

    public class Direction : IDirection
    {
        /// <summary>
        /// Going East means increase the column value 
        /// </summary>
        /// <param name="initialPosition"></param>
        /// <param name="maxMovementLimit"></param>
        /// <returns></returns>
        public List<Position> GetEastPositions(Position initialPosition, uint maxMovementLimit)
        {
            var positions = new List<Position>();           
                for (var index = 1; index <= maxMovementLimit; index++)
                {
                    var nextposition = initialPosition.Column + index;
                    if (nextposition.IsValidMovement(Constants.ChessBoardUpperLimit) == false)
                        break;

                    positions.Add(new Position(initialPosition.Row, initialPosition.Column + index));
                }                      
            return positions;
        }

        public List<Position> GetNorthEastPositions(Position initialPosition, uint maxMovementLimit=0)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Going North means increase the row value 
        /// </summary>
        /// <param name="initialPosition"></param>
        /// <param name="maxMovementLimit"></param>
        /// <returns></returns>
        public List<Position> GetNorthPositions(Position initialPosition, uint maxMovementLimit)
        {
            var positions = new List<Position>();
            for (var index = 1; index <= maxMovementLimit; index++)
            {
                var nextposition = initialPosition.Row + index;
                if (nextposition.IsValidMovement(Constants.ChessBoardUpperLimit) == false)
                    break;

                positions.Add(new Position(nextposition, initialPosition.Column));
            }
            return positions;
        }

        public List<Position> GetNorthWestPositions(Position initialPosition, uint maxMovementLimit)
        {
            throw new NotImplementedException();
        }

        public List<Position> GetSouthEastPositions(Position initialPosition, uint maxMovementLimit)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Going South means decrease the row value 
        /// </summary>
        /// <param name="initialPosition"></param>
        /// <param name="maxMovementLimit"></param>
        /// <returns></returns>
        public List<Position> GetSouthPositions(Position initialPosition, uint maxMovementLimit)
        {
            throw new NotImplementedException();
        }

        public List<Position> GetSouthWestPositions(Position initialPosition, uint maxMovementLimit)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Going Wesr means decrease the column value 
        /// </summary>
        /// <param name="initialPosition"></param>
        /// <param name="maxMovementLimit"></param>
        /// <returns></returns>
        public List<Position> GetWestPositions(Position initialPosition, uint maxMovementLimit)
        {
            throw new NotImplementedException();
        }
    }
}
