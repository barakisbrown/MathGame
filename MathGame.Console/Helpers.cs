namespace MathGame.Console;

using System;

internal class Helpers
{
    internal static string ValidateResult(string ?result, string ?operand)
    {
        while(string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Please try again!");
            Console.Write(operand);
            result = Console.ReadLine();
        }
        return result;
    }

    internal static int CovertStingToInt(string ?result)
    {      
        _ = Int32.TryParse(result, out int returnValue);
        return returnValue;
    }
}
