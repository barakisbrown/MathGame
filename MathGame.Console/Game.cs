namespace MathGame.Console;

using ConsoleTables;
using System;
using System.Reflection.Emit;

public class Game
{
    private List<Problem> Problems { get; set; } = new();
    private int Operand1 { get; set; }
    private int Operand2 { get; set; }
    private GameType Type { get; set; }
    private string ?Prompt { get; }
    private readonly int MAXRANGE = 11;
    private readonly Random random = new();
    
    private void ShowMenu()
    {
        Console.Clear();
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
        do
        {
            ShowMenu();
            FetchMenuChoice();
            if (Type == GameType.ListGames)
                ListProblemsDone();
            PlayProblem();
        } while (Type != GameType.Quit);

        Console.WriteLine("Thank you for playing Math Game. Have a great day!");
    }


    private void FetchMenuChoice()
    {
        char key = Console.ReadKey(true).KeyChar;

        switch(key)
        {
            case 'A':
            case 'a':
                Type = GameType.Addition;
                break;
            case 'S':
            case 's':
                Type = GameType.Subtraction;
                break;
            case 'M':
            case 'm':
                Type = GameType.Multiplication;
                break;
            case 'D':
            case 'd':
                Type = GameType.Division;               
                break;
            case 'Q':
            case 'q':
                Type = GameType.Quit;               
                break;
            case 'L':
            case 'l':
                Type = GameType.ListGames;             
                break;
        }
            
    }

    private void ListProblemsDone()
    {
        Console.Clear();
        Console.WriteLine("Listing Problems Completed Below");

        if (Problems.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Currently no problems exist to be viewed currently.  Please do some and you will see them listed here.");
        }
        else
        {
            var table = new ConsoleTable("Problem", "User Guess", "Actual Answer", "Correct?", "Date");
            foreach (var prob in Problems)
            {
                table.AddRow(prob.Equation, prob.UserAnswer, prob.ActualAnswer, prob.Correct, prob.Date);
            }

            table.Write(Format.Minimal);
            Console.WriteLine();
        }

        Console.WriteLine("Press any key to return back to the menu");
        Console.ReadKey();
        Console.Clear();

    }

    private void PlayProblem()
    {
        Console.Clear();
        // Console.WriteLine(Enum.GetName(Type));
        Console.WriteLine("Playing Problem Here");

    }

    private string GenerateEquation()
    {
        Operand1 = random.Next(0, MAXRANGE);  // X
        Operand2 = random.Next(0, MAXRANGE);  // Y

        char op = ' ';

        switch (Type)
        {
            case GameType.Addition:
                op = '+';
                break;
            case GameType.Subtraction:
                op = '-';
                break;
            case GameType.Multiplication:
                op = '*';
                break;
            case GameType.Division:
                op = '/';
                break;
        }
        // String => X OP Y -- X + Y --
        return string.Format("{1} {2} {3}", Operand1, op, Operand2);        
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
