namespace MathGame.Console;

public class Calc
{
    public static int Add(int Operator1, int Operator2) => Operator1 + Operator2;
    
    
    public static int Substract(int Operator1, int Operator2) => Operator1 - Operator2;

    public static int Multiply(int Operator1, int Operator2) => Operator1 * Operator2;

    public static int? Division(int Dividend, int Divisor) 
    {
        if (Divisor == 0)
            return null;
        else
            return Dividend / Divisor;
    }
}
