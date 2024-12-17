using System;
using System.Numerics;

public class Fraction
{
	int numerator, denominator;

	public Fraction(int numerator, int denominator)
	{
		this.numerator = numerator;
		if (denominator == 0)
		{
			throw new DivideByZeroException();
		}
		this.denominator = denominator;
	}

    public static Fraction operator +(Fraction a, Fraction b)
	{
		Fraction result = new Fraction(0, 1);
		result.numerator = a.numerator * b.denominator + b.numerator * a.denominator;
		result.denominator = a.denominator * b.denominator;
		return result;
	}

    public static Fraction operator -(Fraction a, Fraction b)
	{
		Fraction minus_b = new Fraction(-b.numerator, b.denominator);
		return a + minus_b;
	}

	public override string ToString()
	{
		return $"{numerator}/{denominator}";
	}
}
