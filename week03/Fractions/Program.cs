using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");
        // --- Step 4: Verify all three constructors ---
        Fraction f1 = new Fraction();        // no-arg constructor -> 1/1
        Fraction f2 = new Fraction(6);        // one-arg constructor -> 6/1
        Fraction f3 = new Fraction(6, 7);     // two-arg constructor -> 6/7

        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f3.GetFractionString());

        Console.WriteLine();

        // --- Step 5: Verify getters and setters ---
        Fraction f4 = new Fraction(1, 2);
        Console.WriteLine($"Before: {f4.GetFractionString()}");

        f4.SetTop(3);
        f4.SetBottom(4);
        Console.WriteLine($"After setting top to {f4.GetTop()} and bottom to {f4.GetBottom()}: {f4.GetFractionString()}");

        Console.WriteLine();

        // --- Step 6: Verify GetFractionString and GetDecimalValue ---
        // Matches the sample output: 1, 5, 3/4, 1/3
        Fraction a = new Fraction(1);
        Console.WriteLine(a.GetFractionString());
        Console.WriteLine(a.GetDecimalValue());

        Fraction b = new Fraction(5);
        Console.WriteLine(b.GetFractionString());
        Console.WriteLine(b.GetDecimalValue());

        Fraction c = new Fraction(3, 4);
        Console.WriteLine(c.GetFractionString());
        Console.WriteLine(c.GetDecimalValue());

        Fraction d = new Fraction(1, 3);
        Console.WriteLine(d.GetFractionString());
        Console.WriteLine(d.GetDecimalValue());
    }
}
