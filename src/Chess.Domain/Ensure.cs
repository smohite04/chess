using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Domain
{
    public static class Ensure
    {
        public static void ShouldBeValidNumber(this int value, int upperLimit, string propertyName, string className, string methodName)
        {
            if (value < 0 || value >=upperLimit)
                throw new ArgumentOutOfRangeException($"The {propertyName}'s value should be between 0 and {upperLimit}. Class : {className} and method : {methodName}.");
        }       
    }
}

