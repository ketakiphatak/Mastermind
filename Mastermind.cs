using System;
using System.Collections.Generic;

class Mastermind
{
    private static readonly Random random = new Random();

    private const int DIGITS = 4;
    private const int MAX_ATTEMPTS = 10;

    static void Main()
    {
        Console.WriteLine("MASTERMIND!");
        var scanner = new Scanner();
        string magicNumber = GenerateMagicNumber(4);
        Console.WriteLine($"Please enter a {DIGITS} digit number.");

        var uniqueNumberSet = GetUniqueNumberSet(magicNumber);

        for (int i = 1; i <= MAX_ATTEMPTS; i++)
        {
            Console.Write($"Attempt {i}: ");
            string inputNumber = scanner.ReadLine();

            // Validate input
            EvaluatePluses(magicNumber, inputNumber);
            EvaluateMinuses(uniqueNumberSet, magicNumber, inputNumber);

            if (magicNumber == inputNumber)
            {
                Console.WriteLine("You won!");
                return;
            }
        }

        Console.WriteLine("You lost!");
    }

    private static void EvaluateMinuses(HashSet<char> uniqueNumberSet, string magicNumber, string inputNumber)
    {
        for (int i = 0; i < DIGITS; i++)
        {
            if (uniqueNumberSet.Contains(inputNumber[i]) && magicNumber[i] != inputNumber[i])
                Console.Write("-");
            else
                Console.Write(" ");
        }
        Console.WriteLine();
    }

    private static HashSet<char> GetUniqueNumberSet(string magicNumber)
    {
        var uniqueNumbers = new HashSet<char>();
        for (int i = 0; i < DIGITS; i++)
        {
            uniqueNumbers.Add(magicNumber[i]);
        }
        return uniqueNumbers;
    }

    private static void EvaluatePluses(string magicNumber, string inputNumber)
    {
        for (int i = 0; i < DIGITS; i++)
        {
            if (magicNumber[i] == inputNumber[i])
                Console.Write("+");
            else
                Console.Write(" ");
        }
        Console.WriteLine();
    }

    public static string GenerateMagicNumber(int digit)
    {
        if (digit <= 0)
            return "";
        else
            return random.Next(0, 10).ToString() + GenerateMagicNumber(digit - 1);
    }
}

// Simple Scanner class to read lines from the console
public class Scanner
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}