using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Domain
{
    public static class Extensions
    {
        public static string NumberToAlphabet(this int number)
        {
            return ((char)(number + 65)).ToString();
        }
        public static (int row, int column) ToCellCoOrdinates(this string cellPosition)
        {
            var values = cellPosition.ToCharArray();

            var row = values[0].AlphabetToNumber();
            var column = values[1].ToCellNumber();
            return (row, column);
        }
        private static int AlphabetToNumber(this char letter)
        {
            return char.ToUpper(letter) - 65;
        }
        private static int ToCellNumber(this char value)
        {
            return Convert.ToInt32(value.ToString()) - 1;
        }
    }
}
