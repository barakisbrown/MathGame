
namespace MathGame.Console;

using System;


internal class Helper
{
    internal static string ValidateResults(string? result)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your answer is an integer. Try again!");
            Console.Write("X = ");
            result = Console.ReadLine();
        }
        return result;
    }
}
