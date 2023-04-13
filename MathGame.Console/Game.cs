namespace MathGame.Console;

using System;

public class Game
{
    private int Operator1 { get; set; }
    private int Operator2 { get; set; }
    private GameType Type { get; set; }
    private string ?Prompt { get; }
    
    public void ShowMenu()
    {
        string Prompt = @"Welcome to a game of math. All numbers need to be between 0 and 100.  Please select from one of the choices.

        A)dd two numbers
        S)ubtract two numbers
        M)ultiply two numbers
        D)ivide two numbers
        L)ist Games Played
        Q)uit the game

        Select your choice(A/S/M/D) ?
        ";

        Console.WriteLine(Prompt);
    }

    public void GetSelectedOperation()
    {
        char key = Console.ReadKey(true).KeyChar;

        switch(key)
        {
            case 'A':
            case 'a':
                Type = GameType.Addition;
                FetchOperatorInput();
                break;
            case 'S':
            case 's':
                Type = GameType.Subtraction;
                FetchOperatorInput();
                break;
            case 'M':
            case 'm':
                Type = GameType.Multiplication;
                FetchOperatorInput();
                break;
            case 'D':
            case 'd':
                Type = GameType.Division;
                FetchOperatorInput();
                break;
            case 'Q':
            case 'q':
                Type = GameType.Quit;
                FetchOperatorInput();
                break;
            case 'L':
            case 'l':
                Type = GameType.ListGames;
                FetchOperatorInput();
                break;
        }
            
    }

    private void FetchOperatorInput()
    {
        
    }
}

    internal enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        ListGames,
        Quit
    }
}
