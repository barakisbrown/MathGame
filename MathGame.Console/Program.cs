

using MathGame.Console;

var result = Calc.Division(10, 3);

if (result is null)
{
    Console.WriteLine("Error. Division by zero is illegal.");
} else
{
    Console.WriteLine($"{result}");
}
