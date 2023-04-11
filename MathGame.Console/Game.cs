namespace MathGame.Console;

using System;

internal class Game
{
    private int MAX_RANGE = 100;
    private GameType Type { get; set; }
    private string Prompt { get; set; }

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


}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}
