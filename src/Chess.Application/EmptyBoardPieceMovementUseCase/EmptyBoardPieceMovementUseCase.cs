using Chess.Domain;
using System;

namespace Chess.Application
{
    /// <summary>
    /// This defines the scenario, where given a 8*8 empty chess board and initial position of any position, derves the possible outputs for that piece
    /// </summary>
    public class EmptyBoardPieceMovementUseCase : IUseCase<string, string>
    {
        private readonly IDirection _direction;

        public EmptyBoardPieceMovementUseCase(IDirection direction)
        {
            this._direction = direction;
        }

        public string Execute(string request)
        {
            try
            {
                var requestData = request.ToChessPiecePositionRequest();
                var piece = requestData.ToChessPiece();
                var outcomes = piece.GetPossiblePositions(_direction);
                return outcomes.ToResponse();
            }
            catch (Exception ex) when ((ex is BaseApplicationException) == false)
            {
                throw new SystemException("A system error occured. Please check the request and try again.");
            }
        }
    }
}
