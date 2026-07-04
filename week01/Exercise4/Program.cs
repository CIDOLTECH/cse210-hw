using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number;

        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }

        } while (number != 0);

        // Compute the sum
        int sum = 0;

        foreach (int value in numbers)
        {
            sum += value;
        }

        // Compute the average
        double average = (double)sum / numbers.Count;

        // Find the largest number
        int largest = numbers[0];

        foreach (int value in numbers)
        {
            if (value > largest)
            {
                largest = value;
            }
        }

        int smallestPositive = int.MaxValue;

        foreach (int value in numbers)
        {
            if (value > 0 && value < smallestPositive)
            {
                smallestPositive = value;
            }
        }

        // Sort the list
        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");

        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        Console.WriteLine("The sorted list is:");

        foreach (int value in numbers)
        {
            Console.WriteLine(value);
        }
    }
}