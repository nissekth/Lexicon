/*

Input contains a single test case. Each test case contains three integers on a single line, 
X, Y and N (1 <= X < Y <= N <= 100).

Print integers from 1 to N in order, each on its own line, replacing the ones 
divisible by X with Fizz, 
divisible by Y with Buzz 
divisible by both X and Y with FizzBuzz.

 */

using System;
using System.Numerics;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args){

            string[] input = Console.ReadLine().Split();

/*
            if(args.Length != 3)
            {
                Console.WriteLine("Please provide an X, Y and N value!\n\"dotnet run 2 3 7\"");
                return;
            }
*/

            int X = int.Parse(input[0]);
            int Y = int.Parse(input[1]);
            int N = int.Parse(input[2])+1;

            int p = 1;
            while (p < N)
            {
                if (p % X == 0 && p % Y == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (p % X == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (p % Y == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(p);
                }

                p++;
            }
            
        }
    }
}