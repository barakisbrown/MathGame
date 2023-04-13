namespace MathGame.Console;

using System;


public class Game
{
    private int Operand1 { get; set; }
    private int Operand2 { get; set; }
    private GameType Type { get; set; }
    private string ?Prompt { get; }
    private readonly int MAXRANGE = 11;
    private readonly Random random = new();
    
    private void ShowMenu()
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

    public void BeginGame()
    {
        
    }


    private void GetSelectedOperation()
    {
        char key = Console.ReadKey(true).KeyChar;

        switch(key)
        {
            case 'A':
            case 'a':
                Type = GameType.Addition;
                FetchOperatorInput('+');
                break;
            case 'S':
            case 's':
                Type = GameType.Subtraction;
                FetchOperatorInput('-');
                break;
            case 'M':
            case 'm':
                Type = GameType.Multiplication;
                FetchOperatorInput('*');
                break;
            case 'D':
            case 'd':
                Type = GameType.Division;
                FetchOperatorInput('/');
                break;
            case 'Q':
            case 'q':
                Type = GameType.Quit;
                FetchOperatorInput('l');
                break;
            case 'L':
            case 'l':
                Type = GameType.ListGames;
                FetchOperatorInput('q');
                break;
        }
            
    }

    private void FetchOperatorInput(char op)
    {
        Console.Clear();
        
    }

    private string GenerateEquation(char op)
    {
        Operand1 = random.Next(0, MAXRANGE);  // X
        Operand2 = random.Next(0, MAXRANGE);  // Y

        return string.Format("{0} {1} {2}", Operand1, op, Operand2);
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
