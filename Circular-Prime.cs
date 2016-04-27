using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circular_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Prog();
        }
        public void Prog()
        {

            //Circular primes below 10
            int count = 4;
            //Start from 10 because 2 and 5 below 10 are primes.
            for (int i = 10; i < 1000000; i++)
            {
                if (Odd(i) && Prime(i))
                {
                    int j = 0;
                    var numbers = circular(i);
                    //If one of circularized numbers are not prime, break and do not add 1 to the counter
                    for (; j < numbers.Length; j++)
                    {
                        if (!Prime(numbers[j]))
                        {
                            break;
                        }

                    }
                    if (j == numbers.Length)
                        count++;
                }
            }
            Console.WriteLine("There are {0} circular prime numbers below 1000000", count);
            Console.ReadLine();
        }

        //Adds circular numbers to the list
        static int[] circular(int num)
        {
            var count = num.ToString().Length - 1;
            int[] array = new int[count];
            for (int i = 0; i < count; i++)
            {
                int x = (int)Math.Pow(10, count);
                num = (num % x * 10) + num / x;
                array[i] = num;
            }
            return array;

        }

        //Check for even numbers
        static bool Odd(int number)
        {
            while (true)
            {
                int d = number % 10;
                number /= 10;
                if (d % 2 == 0 || d % 5 == 0)
                {
                    return false;
                }
                if (number < 10)
                {
                    if (number % 2 == 0 || number % 5 == 0)
                    {
                        return false;
                    }
                    return true;
                }
            }
        }
        //Check for primes
        public static bool Prime(int number)
        {
            for (int i = 3; (i * i) <= number; i += 2)
            {
                if ((number % i) == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
