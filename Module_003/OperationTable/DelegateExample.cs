﻿using System;

public class DelegateExample
{
    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static double Square(double a)
    {
        return (a * a);
    }

    public delegate double BinaryOperation(double a, double b);
    public delegate double UnaryOperation(double a);

    public static double CombineOperations(BinaryOperation bOp, UnaryOperation uOp, double a, double b)
    {
        return bOp(uOp(a), uOp(b));
    }

    public static void TestDelegateExample()
    {
        double val1 = 3;
        double val2 = 4;

        double result = CombineOperations(Multiply, Square, val1, val2);

        Console.WriteLine($"TestDelegateExample: result={result}");
    }
}
