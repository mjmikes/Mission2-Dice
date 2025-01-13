// See https://aka.ms/new-console-template for more information
/*
TITLE: Mission #2 Dice Rolls
AUTHOR: Micah Johnson
DESCRIPTION: Write a .NET console application using C# that simulates the rolling of two 6-sided dice. Use an
Array to keep track of the number of times that each combination is thrown. In other words,
keep track of how many times the combination of the two simulated dice is 2, how many times
the combination is 3, and so on, all the way up through 12.
Allow the user to choose how many times the “dice” will be thrown. Then, once you have the
number of rolls, pass that number to a second class that has a method that simulates the roll of
the dice for the number of times that the user specified. That method in the second class should
return the array containing the results. In the first class, use that array to print a histogram (using
the * character) that shows the total percentage each number was rolled. Each * will represent
1% of the total rolls.
 */

using System; //allows me to just write Console.WriteLine instead of System.Console.WriteLine

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the dice throwing simulator!");
        Console.WriteLine("How many dice rolls would you like to simulate? ");
        
        // Safely parse the user input to an integer.
        if (!int.TryParse(Console.ReadLine(), out int numberOfRolls) || numberOfRolls < 1) //TryParse attempts to convert the string input from Console.Readline into an int and returns true or false. If not true, the following line is triggered 
        {
            Console.WriteLine("Invalid number of rolls. Please enter a positive integer.");
            return; // exits the Main Method
        }

        // Create an instance of the DiceSimulator class
        var simulator = new DiceSimulator();

        // Perform the simulation and get the results
        int[] results = simulator.RollDice(numberOfRolls);

        // Output the histogram
        Console.WriteLine("DICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine($"Total number of rolls = {numberOfRolls}.");

        for (int i = 2; i < results.Length; i++)
        {
            Console.Write($"{i}: ");
            int stars = results[i] * 100 / numberOfRolls;
            for (int j = 0; j < stars; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");
    }
}

class DiceSimulator
{
    // Method to simulate dice rolls
    public int[] RollDice(int rolls)
    {
        int[] rollCounts = new int[13]; // From 0 to 12, 0 and 1 are unused

        var rng = new Random();
        for (int i = 0; i < rolls; i++)
        {
            int rollOne = rng.Next(1, 7); // Generate a number from 1 to 6
            int rollTwo = rng.Next(1, 7); // Generate a number from 1 to 6
            int sum = rollOne + rollTwo;
            rollCounts[sum]++;
        }

        return rollCounts;
    }
}
