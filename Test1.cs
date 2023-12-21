
using System.Numerics;

namespace SimpleRSA
{
    public static class Test1
    {
        public static void TestOne(long p, long q, string message)
        {
            Console.WriteLine("p={0} q={1}", p, q);

            if (!Code.CheckPrimes(p, q))
            {
                Console.WriteLine("Not Prime");
                return;
            }

            long[] primes = Code.GetPrimes(p, q);
            for (int i = 0; i < primes.Length / 2; i++)
            {
                Console.Write("[{0}, {1}] ", primes[i], primes[i + 1]);
            }
            Console.WriteLine();

            long e = primes[0];
            long d = primes[1];
            long modulus = p * q;

            Console.WriteLine("e={0} d={1} n={2}", e, d, modulus);

            long[] ct = Code.Encrypt(e, modulus, message);

            Console.WriteLine("ENCRYPTED");
            for (int i = 0; i < ct.Length; i++)
            {
                Console.Write(ct[i] + " ");
            }

            Console.WriteLine();

            string plain = Code.Decrypt(d, modulus, ct);

            Console.WriteLine("DECRYPTED");
            Console.WriteLine(plain);
            Console.WriteLine();
        }

        public static void TestTwo(long p, long q, string message)
        {
            Console.WriteLine("p={0} q={1}", p, q);

            if (!Code.CheckPrimes(p, q))
            {
                Console.WriteLine("Not Prime");
                return;
            }

            long[] primes = Code.GetPrimes(p, q);
            for (int i = 0; i < primes.Length / 2; i++)
            {
                Console.Write("[{0}, {1}] ", primes[i], primes[i + 1]);
            }
            Console.WriteLine();

            long e = primes[0];
            long d = primes[1];
            long modulus = p * q;

            Console.WriteLine("e={0} d={1} n={2}", e, d, modulus);

            long[] ct = Code.EncryptTwo(e, modulus, message);

            Console.WriteLine("ENCRYPTED");
            for (int i = 0; i < ct.Length; i++)
            {
                Console.Write(ct[i] + " ");
            }

            Console.WriteLine();

            string plain = Code.DecryptTwo(d, modulus, ct);

            Console.WriteLine("DECRYPTED");
            Console.WriteLine(plain);
            Console.WriteLine();
        }

        public static void TestThree(long p, long q, string message)
        {
            Console.WriteLine("p={0} q={1}", p, q);

            if (!Code.CheckPrimes(p, q))
            {
                Console.WriteLine("Not Prime");
                return;
            }

            long[] primes = Code.GetPrimes(p, q);
            for (int i = 0; i < primes.Length / 2; i++)
            {
                Console.Write("[{0}, {1}] ", primes[i], primes[i + 1]);
            }
            Console.WriteLine();

            BigInteger e = primes[0];
            BigInteger d = primes[1];
            BigInteger modulus = p * q;

            Console.WriteLine("e={0} d={1} n={2}", e, d, modulus);

            BigInteger[] ct = Code.EncryptThree(e, modulus, message);

            Console.WriteLine("ENCRYPTED");
            for (int i = 0; i < ct.Length; i++)
            {
                Console.Write(ct[i] + " ");
            }

            Console.WriteLine();

            string plain = Code.DecryptThree(d, modulus, ct);

            Console.WriteLine("DECRYPTED");
            Console.WriteLine(plain);
            Console.WriteLine();
        }


        public static void TestFour(long p, long q, string message)
        {
            Console.WriteLine("p={0} q={1}", p, q);

            if (!Code.CheckPrimes(p, q))
            {
                Console.WriteLine("Not Prime");
                return;
            }

            long[] primes = Code.GetPrimes(p, q);
            for (int i = 0; i < primes.Length / 2; i++)
            {
                Console.Write("[{0}, {1}] ", primes[i], primes[i + 1]);
            }
            Console.WriteLine();

            BigInteger e = primes[0];
            BigInteger d = primes[1];
            BigInteger modulus = p * q;

            Console.WriteLine("e={0} d={1} n={2}", e, d, modulus);

            BigInteger[] ct = Code.EncryptFour(e, modulus, message);

            Console.WriteLine("ENCRYPTED");
            for (int i = 0; i < ct.Length; i++)
            {
                Console.Write(ct[i] + " ");
            }

            Console.WriteLine();

            string plain = Code.DecryptFour(d, modulus, ct);

            Console.WriteLine("DECRYPTED");
            Console.WriteLine(plain);
            Console.WriteLine();
        }

        public static string GetString(int index)
        {
            if (index == 1)
            {
                return @"You may say I'm a dreamer, but I'm not the only one. -John Lennon";
            }
            else if (index == 2)
            {
                return @"The only thing we have to fear is fear itself. -Franklin D. Roosevelt";
            }
            else if (index == 3)
            {
                return @"You must be the change you wish to see in the World. -Mahatma Gandhi";
            }
            else if (index == 4)
            {
                return @"Good. Better. Best. Never let it Rest.";
            }

            return @"The sky is blue.";
        }

    }
}
