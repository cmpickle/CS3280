using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// @author Cameron Pickle
/// @Date 5/10/17
/// </summary>
namespace ConsoleApp1
{
    /// <summary>
    /// This class is a console application that will prompt the user for 
    /// two integer. It will then print out the sum, difference, divisor,
    /// quotient, whether the first is less than the second, whether the
    /// first is greater than the second, and whether the first is equal
    /// to the second.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main method for the application, execution begins here.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the first number: ");
            String input;
            int first = 0;
            int second = 0;
            bool firstInput = true;
            while (true)
            {
                try
                {
                    input = Console.ReadLine();
                    int.Parse(input);
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    Console.WriteLine("Your input wasn't a valid integer. Please try again.");
                    continue;
                }
                if(firstInput)
                {
                    first = int.Parse(input);
                    firstInput = false;
                    Console.WriteLine("Please enter the second number: ");
                    continue;
                } else
                {
                    second = int.Parse(input);
                }
                break;
            }

            Console.WriteLine("\n" + first + " + " + second + " = " + (first + second));
            Console.WriteLine("" + first + " - " + second + " = " + (first - second));
            Console.WriteLine("" + first + " * " + second + " = " + (first * second));
            if(second == 0)
            {
                Console.WriteLine("Error: Cannot divide by zero!");
            } else
            {
                Console.WriteLine("" + first + " / " + second + " = " + (first / second));
            }
            if (second == 0)
            {
                Console.WriteLine("Error: Cannot mod by zero!");
            }
            else
            {
                Console.WriteLine("" + first + " % " + second + " = " + (first % second));
            }
            if(first >= second)
            {
                Console.WriteLine("\n" + first + " is not less than " + second);
            } else
            {
                Console.WriteLine("\n" + first + " is less than " + second);
            }
            if(first > second)
            {
                Console.WriteLine("" + first + " is greater than " + second);
            } else
            {
                Console.WriteLine("" + first + " is not greater than " + second);
            }
            if(first == second)
            {
                Console.WriteLine("" + first + " equals " + second);
            } else
            {
                Console.WriteLine("" + first + " does not equal " + second);
            }
            Console.Read();
        }
    }
}
