using Chess.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Application
{
    public static class Ensure
    {
        public static void ShouldBeValidRequest(this string[] values)
        {
            if (values.Length != 2)
                throw new BadRequestException("Invalid input provided for empty chess board execution. It must include both values piece name and position");

            values[1].ShouldBeValidCellPosition();
        }
        private static void ShouldBeValidCellPosition(this string cellPosition)
        {
            var values = cellPosition.ToCharArray();
            if (values.Length!=2)
                throw new BadRequestException("Invalid cell position provided for empty chess board execution.");

            if(values[0].IsValidAlphabet() == false)
                throw new BadRequestException("Invalid cell position provided for empty chess board execution. Row should be between A and H");

            if (values[1].IsValidCellNumber() == false)
                throw new BadRequestException("Invalid cell position provided for empty chess board execution. Column should be between 1 and 8");
        }

        private static bool IsValidAlphabet(this char value)
        {
            var intEquivalent = (int)char.ToUpper(value);
            if (intEquivalent >= 65 && intEquivalent <= 72)
                return true;

            return false;
        }
        private static bool IsValidCellNumber(this char value)
        {
            var intEquivalent = Convert.ToInt32(value.ToString());
            if (intEquivalent >= 1 && intEquivalent <= 8)
                return true;

            return false;
        }
    }
}
