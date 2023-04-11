namespace MathGame.Console;

using System;

internal class Game
{
    private readonly int MAX_RANGE = 100;
    private GameType Type { get; set; }
    private string Prompt { get; }

    private int MAX_GUESS_RANGE => MAX_RANGE;

    public Game()
    {
        Prompt = $@"
        Welcome to Math Game. This game will only use integers from 0 to 100

            Select from one of the following operations to play:
            A)ddition
            S)ubtraction
            M)ultiplication
            D)ivision

         Select either (A/S/M/D)?       
        ";
    }

    private void GetMenuChoice() 
    {
         throw new NotImplementedException();
    }

    private void PerformMath() 
    {
        throw new NotImplementedException();
    }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}
