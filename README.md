# Simple RSA Examples

This project contains a simple introduction to the RSA (Rivest Shamir Adleman) Algorithm.  RSA is also called the Public Key and Private Key Algorithm. The public key is securely given to the recipient and saved in a secure container.  The private key is kept by the sender in a secure container. The private key is used for encryption. The public key is used for decryption.

## Install and Build

The is a C# Console-Mode Project.  Use Visual Studio 2022 and above to compile.  The program uses BigInteger (System.Numerics).

## Features

The main project contains four unit tests:  TestOne, TestTwo, TestThree and TestFour.  TestOne is the simplest test.  It uses MulMod() to do the powers and modulo to convert plain text to cipher text.  It does one character at a time.  TestTwo uses a function called ModularPow() to do the powers and modulo one character at a time.  TestThree uses BigInteger to do the powers and modulo with the BigInteger.ModPow() function.  TestThree does the encryption one character at a time.  TestFour uses BigInteger and the BigInteger.ModPow() function.  TestFour packs four characters into a 32-bit integer.  The 32-bit integers are the cipher text.  As the modulus becomes longer, you can pack more characters into a BigInteger.  Longer primes are left as an exercise.  A faster prime detector is Rabin-Miller.  Rabin-Miller is left as an exercise.

To understand how RSA Algorithm works, please see the WIKI on RSA and google RSA.  Apologies, I don't have time to explain RSA here.  But I've made these examples as simple as possible at four different levels.

## Warning

This code is not safe for production use.  The exponents are too small.  Eight-Hundred (800) bit exponents and moduli can be cracked (factored) in a few hours. A 2,000 bit key (exponent) is required to make factorization and residual key analysis infeasible.  A 3,000 bit RSA key is recommended. The exponents must be stored in a cryptographically secure storage container. Keys must be distributed in a secure manner using Diffie Hellman, Secure IP, Secure DNS, anti-tamper and anti-easedropping (man in the middle) techniques.  This code is only for Educational Purposes.  

## References
```
1. RSA CryptoSystem, Wikipedia.

2. Handbook of Applied Cryptography, Alfred J. Menezes, Jonathan Katz, Paul C. van Oorschot, Scott A. Vanstone, CRC Press, 1996.

3. R. L. RIVEST, A. SHAMIR, AND L. ADELMAN, “A Method for Obtaining Digital Signatures and Public-Key Cryptosystems,” Communications of the ACM, 21, 120–126 (1978).
```
   





