using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FibonacciDelegate
{
    public delegate Task NotificationDelegateHandler(int number,int i);

    class Program
    {
        static void Main(string[] args)
        {
            int number;
            Console.WriteLine("Give the length of the sequence");
            number = int.Parse(Console.ReadLine());
            StartCalculation(number);
            Console.ReadKey();
        }

        public static async Task StartCalculation(int number)
        {
            NotificationDelegateHandler delegateHandler = new NotificationDelegateHandler(StartPercentageCalculation);

            for (int i = 0; i <= number; i++)
            {
                await Task.Run(async () =>
                {
                    var fibonaciiNumber = await Fibonacci(i);
                    Console.Write($"{fibonaciiNumber}  ");
                });

                delegateHandler(i, number);  
            }
        }

        public static async Task StartPercentageCalculation(int i,int number)
        {
            Console.WriteLine(" " + (i * 100) / (number) + "%\n");
        }

        private static async Task<int> Fibonacci(int number)
        {
            if (number == 0 || number == 1)
                return number;
            else
                return (await Fibonacci(number - 1) + await Fibonacci(number - 2));
        }
    }
}
