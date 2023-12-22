using System.Numerics;
using System.Text;

namespace SimpleRSA
{
    public static class Code
    {
        // Is p prime?
        public static bool IsPrime(long p)
        {
            for (int i = 2; i <= Math.Sqrt(p); i++)
            {
                if (p % i == 0)
                    return false;
            }

            return true;
        }

        public static bool CheckPrimes(long p, long q)
        {
            return p != q && IsPrime(p) && IsPrime(q);
        }

        // Get primes.
        public static long[] GetPrimes(long p, long q)
        {
            const int maxLength = 40;
            List<long> list = new List<long>();

            long totient = (p - 1) * (q - 1);

            for (long i = 2; i < totient; i++)
            {
                if (totient % i == 0)
                    continue;

                if (IsPrime(i) && i != p && i != q)
                {
                    long exp = GetDecryptExp(i, totient);
                    if (exp > 0)
                    {
                        list.Add(i);
                        list.Add(exp);
                    }

                    if (list.Count > maxLength - 1)
                        break;
                }
            }

            return list.ToArray();
        }

        // Get the encryption exponent (e).
        public static long GetEncryptExp(long p, long q)
        {
            long totient = (p - 1) * (q - 1);
            for (long i = 2; i < totient; i++)
            {
                if (totient % i == 0)
                    continue;

                if (IsPrime(i) && i != p && i != q)
                {
                    long exp = GetDecryptExp(i, totient);
                    if (exp > 0)
                        return i;
                }
            }

            return 0;
        }

        // Get Decryption exponent (d).
        public static long GetDecryptExp(long x, long t)
        {
            long k = 1;
            while (true)
            {
                k = k + t;
                if (k % x == 0)
                    return k / x;
            }
        }

        public static long[] Encrypt(long key, long modulus, string msg)
        {
            int len = msg.Length;

            // encrypted 
            long[] en = new long[len];

            for (int i = 0; i < msg.Length; i++)
            {
                // plain text
                long pt = msg[i];
                long k = 1;
                for (long j = 0; j < key; j++)
                {
                    k = MulMod(k, pt, modulus);
                }

                // cipher text
                en[i] = k + 96;
            }

            return en;
        }


        /// <summary>
        /// Decrypt encrypted text;
        /// </summary>
        /// <param name="en">encrypted text</param>
        /// <param name="key">key</param>
        /// <param name="n">modulus</param>
        /// <returns></returns>
        public static string Decrypt(long key, long modulus, long[] en)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < en.Length; i++)
            {
                // cipher text
                long ct = en[i] - 96;
                long k = 1;
                for (long j = 0; j < key; j++)
                {
                    k = MulMod(k, ct, modulus);
                }

                // Get positive modulo.
                const long n = 256;
                k = PosMod(k, n);
                sb.Append(Convert.ToChar(k));
            }

            return sb.ToString();
        }

        // Modular Multiplication. Return (a * b) % mod.  Prevents most overflows.
        // Overflows when (a % mod) * (b % mod) is greater than 64 bits.
        // Overflows when modulus is greater than 10 million.
        public static long MulMod(long a, long b, long mod)
        {
            return ((a % mod) * (b % mod)) % mod;
        }

        // Return (a * b) % mod.  No overflow.  
        public static long MulModTwo(long a, long b, long mod)
        {
            long result = 0; 
            a = a % mod;
            while (b > 0)
            {
                // If b is odd, add 'a' to result. 
                if (b % 2 == 1)
                {
                    result = (result + a) % mod;
                }

                // Multiply 'a' with 2.
                a = (a * 2) % mod;

                // Divide b by 2 
                b /= 2;
            }

            return result % mod;
        }


        // Positive Modulo. Return a mod n.
        // Result is positive or zero.
        public static int PosMod(int a, int n)
        {
            return (a % n + n) % n;
        }

        // Positive Modulo. Return a mod n.
        // Result is positive or zero.
        public static long PosMod(long a, long n)
        {
            return (a % n + n) % n;
        }

        public static long[] EncryptTwo(long key, long modulus, string msg)
        {
            int len = msg.Length;

            // encrypted 
            long[] en = new long[len];

            for (int i = 0; i < msg.Length; i++)
            {
                // plain text
                long pt = msg[i];
                long k = ModularPow(pt, key, modulus);

                // cipher text
                en[i] = k + 96;
            }

            return en;
        }

        /// <summary>
        /// Decrypt encrypted text;
        /// </summary>
        /// <param name="en">encrypted text</param>
        /// <param name="key">key</param>
        /// <param name="n">modulus</param>
        /// <returns></returns>
        public static string DecryptTwo(long key, long modulus, long[] en)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < en.Length; i++)
            {
                // cipher text
                long ct = en[i] - 96;
                long k = ModularPow(ct, key, modulus);

                // Get positive modulo.
                const long n = 256;
                k = PosMod(k, n);
                sb.Append(Convert.ToChar(k));
            }

            return sb.ToString();
        }



        // Return (num ^ exponent) % modulus.
        public static long ModularPow(long num, long exponent, long modulus)
        {
            long result = 1;
            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                    result = (result * num) % modulus;
                exponent = exponent >> 1;
                num = (num * num) % modulus;
            }

            return result;
        }

        // Return (num ^ exponent) % modulus.
        public static int ModularPow(int num, int exponent, int modulus)
        {
            int result = 1;
            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                    result = (result * num) % modulus;
                exponent = exponent >> 1;
                num = (num * num) % modulus;
            }

            return result;
        }

        public static BigInteger[] EncryptThree(BigInteger key, BigInteger modulus, string msg)
        {
            int len = msg.Length;

            // encrypted 
            BigInteger[] en = new BigInteger[len];

            for (int i = 0; i < msg.Length; i++)
            {
                // plain text
                BigInteger pt = msg[i];
                BigInteger k = BigInteger.ModPow(pt, key, modulus);

                // cipher text
                en[i] = k + 96;
            }

            return en;
        }

        public static string DecryptThree(BigInteger key, BigInteger modulus, BigInteger[] en)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < en.Length; i++)
            {
                // cipher text
                BigInteger ct = en[i] - 96;
                BigInteger k = BigInteger.ModPow(ct, key, modulus);

                // Get positive modulo.
                BigInteger N = 256;
                k = k % N;
                int ch = (int)k;
                int n = 256;
                ch = PosMod(ch, n);
                sb.Append(Convert.ToChar(ch));
            }

            return sb.ToString();
        }

        public static BigInteger[] EncryptFour(BigInteger key, BigInteger modulus, string msg)
        {
            int len = msg.Length / 4;
            if (msg.Length % 4 > 0)
                ++len;

            // encrypted 
            BigInteger[] en = new BigInteger[len];

            // Pack characters.
            int[] m = StrToArray(msg);

            for (int i = 0; i < m.Length; i++)
            {
                // plain text
                BigInteger pt = m[i];
                BigInteger k = BigInteger.ModPow(pt, key, modulus);

                // cipher text
                en[i] = k + 96;
            }

            return en;
        }

        public static string DecryptFour(BigInteger key, BigInteger modulus, BigInteger[] en)
        {
            BigInteger N = int.MaxValue;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < en.Length; i++)
            {
                // cipher text
                BigInteger ct = en[i] - 96;
                BigInteger k = BigInteger.ModPow(ct, key, modulus);
                k = k % N;
                int a = (int)k;
                // Unpack integer
                sb.Append(IntToStr(a));
            }

            return sb.ToString();
        }


        // Convert string to Array.
        public static int[] StrToArray(string str)
        {
            int n = str.Length / 4;
            if (str.Length % 4 > 0)
                ++n;
            int[] array = new int[n];

            int k = 0;
            for (int i = 0; i < str.Length; i += 4)
            {
                string s1 = str.Substring(i, Math.Min(4, str.Length - i));
                array[k++] = StrToInt(s1);
            }

            return array;
        }

        // Convert string to integer.
        public static int StrToInt(string str)
        {
            int result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                result = (256 * result) + str[i];
            }

            return result;
        }

        // Convert integer to string.
        public static string IntToStr(int a)
        {
            string result = string.Empty;
            while (a > 0)
            {
                char ch = (char)(a % 256);
                result = ch + result;
                a = a / 256;
            }

            return result;
        }

    }
}

