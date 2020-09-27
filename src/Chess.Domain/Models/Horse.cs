using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Domain
{
    public class Horse : Piece
    {
        public Horse(Position position) : base(position)
        {
        }

        public override string Name => ChessPieces.Horse.ToString();
        /// <summary>
        /// This gives posible movements of horse.
        ///Horse can move across the board only in 2.5 steps (2 vertical steps and 1 horizontal step)
        /// </summary>
        /// <param name="initialPosition"></param>
        /// <returns></returns>
        public override List<Position> GetPossiblePositions(IDirection direction)
        {
           
            var possibleOutcomes = new List<Position>();
            var horizontalMovements = GetHorizontalTwoAndHalfMovements( direction);
            var verticalMovements = GetVerticalTwoAndHalfMovements(direction);
            possibleOutcomes.AddRange(horizontalMovements);
            possibleOutcomes.AddRange(verticalMovements);
            return possibleOutcomes;
           
        }
        /// <summary>
        ///To calculate the horizontal movements of a horse, we need to go 2 cells north and south.
        ///For the valid vertical 2 cell movements, we can then go horizontal as a half location.
        /// </summary>
        /// <returns></returns>
        private List<Position> GetHorizontalTwoAndHalfMovements(IDirection direction)
        {
            var verticalPositions = new List<Position>();
            var northIndex = CurrentPosition.Row + 2;
            if (northIndex.IsValidMovement() == true)
            {
                verticalPositions.Add(new Position(northIndex, CurrentPosition.Column));
            }
            var southIndex = CurrentPosition.Row - 2;
            if (southIndex.IsValidMovement() == true)
            {
                verticalPositions.Add(new Position(southIndex, CurrentPosition.Column));
            }
            var horizontalMovements = new List<Position>();
            verticalPositions.ForEach(x =>
            {
                horizontalMovements.AddRange(direction.GetEastPositions(x, 1));
                horizontalMovements.AddRange(direction.GetWestPositions(x, 1));
            });
            return horizontalMovements;
        }

        /// <summary>
        ///To calculate the vertical movements of a horse, we need to go 2 cells east and west.
        ///For the valid horizontal 2 cell movements, we can then go vertical as a half movement.
        /// </summary>
        /// <param name="initialPosition"></param>
        /// <returns></returns>
        private List<Position> GetVerticalTwoAndHalfMovements(IDirection direction)
        {
     
            var horizontalPositions = new List<Position>();
            var eastIndex = CurrentPosition.Column + 2;
            if (eastIndex.IsValidMovement() == true)
            {
                horizontalPositions.Add(new Position(CurrentPosition.Row, eastIndex));
            }
            var westIndex = CurrentPosition.Column - 2;
            if (westIndex.IsValidMovement() == true)
            {
                horizontalPositions.Add(new Position(CurrentPosition.Row, westIndex));
            }
            var verticalMovements = new List<Position>();
            horizontalPositions.ForEach(x =>
            {
                verticalMovements.AddRange(direction.GetNorthPositions(x, 1));
                verticalMovements.AddRange(direction.GetSouthPositions(x, 1));
            });
            return verticalMovements;
        }
    }
}
