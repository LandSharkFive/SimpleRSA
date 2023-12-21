using System;
using System.Text;

namespace SimpleRSA
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Longs. 3 - 4 digits.
            Test1.TestOne(43, 47, Test1.GetString(1));
            Test1.TestOne(173, 199, Test1.GetString(2));
            Test1.TestOne(2609, 2777, Test1.GetString(3));

            // ModularPow().  4-5 digits. 
            Test1.TestTwo(4217, 4363, Test1.GetString(4));
            Test1.TestTwo(39971, 40163, Test1.GetString(1));
            Test1.TestTwo(54311, 54503, Test1.GetString(2));

            // BigInteger. 5-6 digits.
            Test1.TestThree(54401, 67943, Test1.GetString(3));
            Test1.TestThree(93971, 94063, Test1.GetString(4));
            Test1.TestThree(502237, 502543, Test1.GetString(1));

            // Pack characters: 5-6 digits.
            Test1.TestFour(54401, 67943, Test1.GetString(2));
            Test1.TestFour(93971, 94063, Test1.GetString(3));
            Test1.TestFour(502237, 502543, Test1.GetString(4));
        }
    }
}