using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            bool result = true;
            int invalidInputCount = 0;

            DisplayGreetingMessage();

            while (result == true && invalidInputCount < 3)
            {
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    switch (input)
                    {
                        case 0:
                            result = false;
                            break;
                        case int n when (n > 0 && n < 5):
                            Calculate(input);
                            DisplayGreetingMessage();
                            break;
                        default:
                            invalidInputCount++;
                            Console.WriteLine("Unknown input");
                            break;
                    }
                }
                else
                {
                    if (invalidInputCount < 2)
                        Console.WriteLine("Invalid input. Please try again.");
                    invalidInputCount++;
                }

                //if (invalidInputCount == 3) result = false;
            }
            DisplayExitMessage();
        }

        private static void DisplayGreetingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Hello. Press 1 for addition, 2 for subtraction, 3 for multiplication, and 4 for division");
            Console.WriteLine("Enter 0 (zero) to exit");
        }

        private static void Calculate(int input)
        {
            double? firstNumber;
            double? secondNumber;

            Console.Write("Enter first number for calculation: ");
            firstNumber = GetNumberForCalculation();
            if (firstNumber == null)
                DisplayExitMessage();
            else
            {
                Console.Write("Enter second number for calculation: ");
                secondNumber = GetNumberForCalculation();
                if (secondNumber == null)
                    DisplayExitMessage();
                else
                    DoCalculation(input, (double)firstNumber, (double)secondNumber);
            }

        }
        private static int? GetNumberForCalculation()
        {
            int invalidInputCount = 0;
            int? returnNumber = null;

            while (returnNumber == null && invalidInputCount < 3)
            {
                string inputString = Console.ReadLine();
                if (int.TryParse(inputString, out int goodNumber))
                {
                    returnNumber = goodNumber;
                }
                else
                {
                    invalidInputCount++;
                    if (invalidInputCount <= 3)
                        Console.WriteLine($"'{inputString}' is not a number. Please try again.");
                }
            }
            return returnNumber;
        }

        private static void DoCalculation(int input, double firstNumber, double secondNumber)
        {
            switch (input)
            {
                case 1:
                    Console.Write($"{firstNumber} + {secondNumber} = ");
                    Console.WriteLine(Calculator.Add(firstNumber, secondNumber));
                    break;
                case 2:
                    Console.Write($"{firstNumber} - {secondNumber} = ");
                    Console.WriteLine(Calculator.Subtract(firstNumber, secondNumber));
                    break;
                case 3:
                    Console.Write($"{firstNumber} * {secondNumber} = ");
                    Console.WriteLine(Calculator.Multiply(firstNumber, secondNumber));
                    break;
                case 4:
                    Console.Write($"{firstNumber} / {secondNumber} = ");
                    Console.WriteLine(Calculator.Divide(firstNumber, secondNumber));
                    break;
                default:
                    break;
            }
        }

        private static void DisplayExitMessage()
        {
            Console.WriteLine("Thank you for using calculator. Goodbye!");
        }
    }
}
