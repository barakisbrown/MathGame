namespace MathGame.Console;

using ConsoleTables;
using System;

public class Game
{
    private List<Problem> Problems { get; set; } = new();
    private int Operand1 { get; set; }
    private int Operand2 { get; set; }
    private GameType Type { get; set; }
    private int MAXRANGE = (int)Difficulty_Modes.Beginner;
    private readonly Random random = new();
    
    private void ShowMenu()
    {        
        string Prompt = @"Welcome to MathGame. All numbers need to be between 0 and 100.  Please select from one of the choices.

        A)dd two numbers
        S)ubtract two numbers
        M)ultiply two numbers
        D)ivide two numbers
        
        L)ist Games Played
        X)tra Options
        Q)uit the game

        Select your choice(A/S/M/D/L/X/Q) ?
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
            else if (Type == GameType.Difficulty)
                ChangeDifficultyLevel();
            else if (Type == GameType.Quit)
                break;
            else
                PlayProblem();
        } while (true);

        Console.WriteLine("Thank you for playing Math Game. Have a great day!");
    }

    private void ChangeDifficultyLevel()
    {
        string ?Difficulty_Prompt = @"
            Would you like to change the difficulty level?
            1) Regular [All numbers will be less than 10][Default]
            2) Moderate [All numbers will be less than 50]
            3) Extreme [All numbers will be less than 100]

            Select your option (1/2/3)?
        ";

        Console.Clear();
        Console.WriteLine(Difficulty_Prompt);

        char key = Console.ReadKey(true).KeyChar;
        switch(key)
        {
            case '1':
                MAXRANGE = (int)Difficulty_Modes.Beginner;
                break;
            case '2':
                MAXRANGE = (int)Difficulty_Modes.Advanced;
                break;
            case '3':
                MAXRANGE = (int)Difficulty_Modes.Expert;
                break;
        }
        Console.Clear();
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
            case 'X':
            case 'x':
                Type = GameType.Difficulty;
                break;
        }            
    }

    private void ListProblemsDone()
    {
        Console.Clear();
        Console.WriteLine("Listing Problems Completed Below");
        Console.WriteLine($"Number of Records = {Problems.Count}");


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
        bool flag = true;
        do
        {
            
            Console.Clear();
            Console.WriteLine($"The Current Problem Type is {Enum.GetName(Type)}");

            string problemString = GenerateEquation();
            Console.WriteLine(problemString);

            int ActualAnswer = 0;
            switch (Type)
            {
                case GameType.Addition:
                    ActualAnswer = Calc.Add(Operand1, Operand2);
                    break;
                case GameType.Subtraction:
                    ActualAnswer = Calc.Substract(Operand1, Operand2);
                    break;
                case GameType.Multiplication:
                    ActualAnswer = Calc.Multiply(Operand1, Operand2);
                    break;
                case GameType.Division:
                    try
                    {
                        ActualAnswer = Calc.Division(Operand1, Operand2);                     
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Error:Divide by Zero");
                        return;
                    }
                    break;
            }

            Console.Write("Guess : ");
            string? guess = Console.ReadLine();
            guess = Helpers.ValidateResult(guess, "Guess : ");
            int UserAnswer = Helpers.CovertStingToInt(guess);

            if (UserAnswer == ActualAnswer)
                Console.WriteLine("Congrats.");
            else
                Console.WriteLine($"Wrong Answer. The actual answer is {ActualAnswer}");

            Console.WriteLine("Would you like another problem to test yourself further(y/n)");

            // FIXED
            Problem P = new()
            {
                Equation = problemString,
                UserAnswer = UserAnswer,
                ActualAnswer = ActualAnswer,
                Correct = (ActualAnswer == UserAnswer),
                Date = DateTime.Now
            };
            Problems.Add(P);

            char key = Console.ReadKey(true).KeyChar;
            switch (key)
            {
                case 'Y':
                case 'y':                    
                    break;
                case 'N':
                case 'n':
                    flag = false;
                    Console.Clear();
                    break;
            } 
        } while (flag);

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
                // WIll not do undefined
                if (Operand2 == 0)
                    Operand2 = random.Next(1, MAXRANGE);
                break;
        }
        // String => X OP Y -- X + Y --
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
    Difficulty,
    Quit
}

internal enum Difficulty_Modes
{
    Beginner = 11,
    Advanced = 51,
    Expert = 101
}