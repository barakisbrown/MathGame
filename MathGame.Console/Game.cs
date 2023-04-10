using System;

namespace MathGame.Console;

public class Game
{
    public static void ShowMenu()
    {
        string prompt = @"Welcome to a game of math. All numbers need to be between 0 and 100.  Please select from one of the choices.

        A)dd two numbers
        S)ubtract two numbers
        M)ultiply two numbers
        D)ivide two numbers

        Select your choice(A/S/M/D) ?
        ";

        System.Console.WriteLine(prompt);
    }
}
