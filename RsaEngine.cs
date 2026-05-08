using System.Numerics;
using System.Text;

namespace SimpleRSA
{
    public static class RsaEngine
    {
        /// <summary>
        /// Checks if a number is prime using a basic trial division.
        /// </summary>
        public static bool IsPrime(long n)
        {
            if (n <= 1) return false;
            if (n == 2 || n == 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;

            for (long i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Are p and q coprime?
        /// </summary>
        public static bool CheckPrimes(long p, long q)
        {
            return p != q && IsPrime(p) && IsPrime(q);
        }

        /// <summary>
        /// Get primes.
        /// </summary>
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

        /// <summary>
        /// Get the encryption exponent (e).
        /// </summary>
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

        /// <summary>
        /// Get Decryption exponent (d).
        /// </summary>
        public static long GetDecryptExp(long x, long t)
        {
            long k = 1;
            while (true)
            {
                k = k + t;
                if (k % x == 0)
                {
                    return k / x;
                }
            }
        }

        /// <summary>
        /// Encrypt message using key and modulus.
        /// </summary>
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
                en[i] = k; 
            }

            return en;
        }


        /// <summary>
        /// Decrypt the ciphertext (en).
        /// </summary>
        public static string Decrypt(long key, long modulus, long[] en)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < en.Length; i++)
            {
                // cipher text
                long ct = en[i]; 
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

        /// <summary>
        /// Modular Multiplication using longs. Return (a * b) % mod.  Prevents most overflows.
        /// Overflows when (a % mod) * (b % mod) is greater than 64 bits.
        /// Overflows when modulus is greater than 10 million.
        /// </summary>
        public static long MulMod(long a, long b, long mod)
        {
            return ((a % mod) * (b % mod)) % mod;
        }

        /// <summary>
        /// Modular Multiplication using longs. Return (a * b) % mod.  No overflow. This is faster.
        /// </summary>
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


        /// <summary>
        /// Positive Modulo for Int (Int32). Return a mod n. Result is positive or zero.
        /// </summary>
        public static int PosMod(int a, int n)
        {
            return (a % n + n) % n;
        }

        /// <summary>
        /// Positive Modulo for long (Int64). Return a mod n. Result is positive or zero.
        /// </summary>
        public static long PosMod(long a, long n)
        {
            return (a % n + n) % n;
        }

        /// <summary>
        /// Encrypt a message with a key and a modulus. 
        /// </summary>
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
                en[i] = k; 
            }

            return en;
        }

        /// <summary>
        /// Decrypt ciphertext (en).
        /// </summary>
        public static string DecryptTwo(long key, long modulus, long[] en)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < en.Length; i++)
            {
                // cipher text
                long ct = en[i];
                long k = ModularPow(ct, key, modulus);

                // Get positive modulo.
                const long n = 256;
                k = PosMod(k, n);
                sb.Append(Convert.ToChar(k));
            }

            return sb.ToString();
        }


        /// <summary>
        /// Modular Power for longs (Int64).  Return (num ^ exponent) % modulus.
        /// </summary>
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

        /// <summary>
        /// Modular Power for integers (Int32). Return (num ^ exponent) % modulus.
        /// </summary>
        public static int ModularPow(int num, int exponent, int modulus)
        {
            int result = 1;
            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                {
                    result = (result * num) % modulus;
                }
                exponent = exponent >> 1;
                num = (num * num) % modulus;
            }

            return result;
        }

        /// <summary>
        /// Encrypt message using BigIntegers.  Use key and modulus. Not packed.
        /// </summary>
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
                en[i] = k;
            }

            return en;
        }

        /// <summary>
        /// Decrypt ciphertext (en) using BigIntegers.  Use key and modulus. Not packed.
        /// </summary>
        public static string DecryptThree(BigInteger key, BigInteger modulus, BigInteger[] en)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < en.Length; i++)
            {
                // cipher text
                BigInteger ct = en[i];
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

        /// <summary>
        /// Encrypt message with BigIntegers.  Use key and modulus. Packed.
        /// </summary>
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
                en[i] = k; 
            }

            return en;
        }

        /// <summary>
        /// Decrypt ciphertext (en) using BigIntegers.  Use key and modulus. Unpacked.
        /// </summary>
        public static string DecryptFour(BigInteger key, BigInteger modulus, BigInteger[] en)
        {
            BigInteger N = int.MaxValue;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < en.Length; i++)
            {
                // cipher text
                BigInteger ct = en[i];
                BigInteger k = BigInteger.ModPow(ct, key, modulus);
                k = k % N;
                int a = (int)k;
                // Unpack integer
                sb.Append(IntToStr(a));
            }

            return sb.ToString();
        }


        /// <summary>
        /// Convert string to Array.
        /// </summary>
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

        /// <summary>
        /// Convert string to integer.
        /// </summary>
        public static int StrToInt(string str)
        {
            int result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                result = (256 * result) + str[i];
            }

            return result;
        }

        /// <summary>
        /// Convert integer to string.
        /// </summary>
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

