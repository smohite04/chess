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
                throw new ArgumentException("Invalid input provided for empty chess board execution.");
        }
    }
}
