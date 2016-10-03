using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Contracts_Compulsory_Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter the number: ('q' to stop the application)");

                var enteredKey = Console.ReadLine();

                if (enteredKey == "q")
                {
                    break;
                }

                var num1 = Convert.ToInt32(enteredKey);

                Console.WriteLine(IsPrime(num1) ? "It is prime" : "It is not prime");
                Console.ReadKey();
            }
        }

        public static bool IsPrime(int number)
        {
            Contract.Requires(number > 0);
            Contract.Ensures(Contract.Result<bool>() == Contract.ForAll(2, number, c => number % c != 0));
             
            if (number == 1)
            {
                return false;
            }
            if (number == 2)
            {
                return true;
            }

            for (var i = 2; i < number; ++i)
            {
                Contract.Assert(Contract.ForAll(2, i, c => number % c != 0));
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
