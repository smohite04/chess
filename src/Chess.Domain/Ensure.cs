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
        public static void ShouldNotBeNullOrEmpty(this string value, string propertyName, string className, string methodName)
        {
            if (string.IsNullOrWhiteSpace(value) == true)
                throw new ArgumentException($"The {propertyName}'s value should ne null or empty. Class : {className} and method : {methodName}.");
        }
        public static void ShouldBeValid(this string cellPosition, string propertyName, string className, string methodName)
        {
            cellPosition.ShouldNotBeNullOrEmpty( propertyName, className, methodName);
            if (cellPosition.Length > 2)
                throw new ArgumentException($"The {propertyName}'s value should be contain only 2 charachers. Class : {className} and method : {methodName}.");
        }
        public static bool IsValidMovement(this int value, int upperLimit)
        {
            if (value >= upperLimit)
            {
                return false;
            }
            return true;
        }
    }
}

