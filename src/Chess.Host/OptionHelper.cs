using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Host
{
    public class OptionHelper
    {
        public static string GetOptionToBeExecuted()
        {
            var options = GetOptions();
            Console.WriteLine("Please select the flow by entering the appropriate number.");
            for (int i = 1; i <= options.Count; i++)
            {
                Console.WriteLine(string.Format("{0}. {1}", i, options[i - 1].Value));
            }

            var input = Console.ReadLine();


            int.TryParse(input, out int option);

            while (option < 1 || option > options.Count)
            {
                Console.WriteLine("Please enter the valid option.");
                input = Console.ReadLine();
                int.TryParse(input, out option);
            }

            return options[option - 1].Key;
        }
        private static List<KeyValuePair<string, string>> GetOptions()
        {
            return new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>(Keystore.EmptyChessMovement, "To get the piece position on empty chess board"),
                new KeyValuePair<string, string>(Keystore.EmptyChessMovement, "Exit")
            };
        }
    }
}
