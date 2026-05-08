using System;
using System.Text;

namespace SimpleRSA
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    DemoOne();
                    break;
                case 2:
                    DemoTwo();
                    break;
                case 3:
                    DemoThree();
                    break;
                case 4:
                    DemoFour();
                    break;
                case 5:
                    RunAllDemos();
                    break;
            }

        }

        private static void DemoOne()
        {
            Console.WriteLine("Demo One.");
            Console.WriteLine("MulMod(). 3 - 4 digits. Use Integers (Int32).");
            Console.WriteLine();

            Test1.TestOne(43, 47, Test1.GetString(1));
            Test1.TestOne(173, 199, Test1.GetString(2));
            Test1.TestOne(2609, 2777, Test1.GetString(3));
            Console.WriteLine("\n");
        }

        private static void DemoTwo()
        {
            Console.WriteLine("Demo Two.");
            Console.WriteLine("ModularPow(). 4-5 digits. Use Long (Int64).");
            Console.WriteLine();

            Test1.TestTwo(4217, 4363, Test1.GetString(4));
            Test1.TestTwo(39971, 40163, Test1.GetString(1));
            Test1.TestTwo(54311, 54503, Test1.GetString(2));
            Console.WriteLine("\n");
        }

        private static void DemoThree() 
        {
            Console.WriteLine("Demo Three.");
            Console.WriteLine("BigInteger. 5-6 digits. Not packed.");
            Console.WriteLine();

            Test1.TestThree(54401, 67943, Test1.GetString(3));
            Test1.TestThree(93971, 94063, Test1.GetString(4));
            Test1.TestThree(502237, 502543, Test1.GetString(1));
            Console.WriteLine("\n");
        }

        private static void DemoFour() 
        {
            Console.WriteLine("Demo Four.");
            Console.WriteLine("BigIntegers. Pack characters: 5-6 digits.");
            Console.WriteLine();

            Test1.TestFour(54401, 67943, Test1.GetString(2));
            Test1.TestFour(93971, 94063, Test1.GetString(3));
            Test1.TestFour(502237, 502543, Test1.GetString(4));
            Console.WriteLine("\n");
        }

        private static void RunAllDemos()
        {
            DemoOne();
            DemoTwo();
            DemoThree();
            DemoFour();
        }
    }
}