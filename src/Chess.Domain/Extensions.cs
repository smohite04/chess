using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Domain
{
    public static class Extensions
    {
        public static int AlphabetToNumber(this char letter)
        {
           return char.ToUpper(letter) - 65;   
        }

        public static int ToCellNumber(this char value)
        {
            return Convert.ToInt32(value.ToString()) - 1;
        }
        public static string NumberToAlphabet(this int number)
        {
            return ((char)(number + 65)).ToString();
        }
    }
}
