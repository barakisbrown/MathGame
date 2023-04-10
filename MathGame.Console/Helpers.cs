namespace MathGame.Console;

using System;

internal class Helpers
{
    internal static string ValidateResult(string ?result)
    {
        while(string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Please try again!");
            Console.Write("X = ");
            result = Console.ReadLine();
        }
        return result;
    }
}
