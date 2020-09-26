using Chess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Application
{
    public static class Extensions
    {
        public static string ToResponse(this List<Position> positions)
        {
            var outcomes = positions.Select(x => x.CellPosition);
            return string.Join(",", outcomes);
        }
        public static ChessPiecePositionRequest ToChessPiecePositionRequest(this string value)
        {
            var requestData = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
           requestData.ShouldBeValidRequest();
            return new ChessPiecePositionRequest { InitialPosition = requestData[1], PieceName = requestData[0]};

        }
    }
}
