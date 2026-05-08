# Simple RSA Examples

A progressive, educational implementation of the Rivest-Shamir-Adleman (RSA) algorithm in C#. This project breaks down the intimidating mathematics of public-key cryptography into four digestible levels of complexity.

### The Logic
RSA is built on the computational difficulty of factoring large prime numbers. This implementation demonstrates the core relationship between the Public Key (for encryption/distribution) and the Private Key (for decryption/retention), utilizing the `System.Numerics.BigInteger` library for high-precision arithmetic.

### Four Levels of Implementation
The project is structured into four distinct unit tests, each increasing in sophistication:
1. **Level 1 (Manual Math):** Uses a custom `MulMod()` function to handle powers and modulo operations on individual characters.
2. **Level 2 (Modular Power):** Introduces a dedicated `ModularPow()` function for more efficient character-by-character processing.
3. **Level 3 (BigInteger Integration):** Leverages `BigInteger.ModPow()` for optimized, large-scale modular exponentiation.
4. **Level 4 (Data Packing):** Demonstrates bit-packing by compressing four characters into a 32-bit integer before encryption—the first step toward real-world data throughput.

### ⚠️ Security Disclaimer
This is an **Educational Proof of Concept**. It is not hardened for production environments:
* **Key Length:** The exponents used here are for demonstration. Modern security requires at least 2,000 to 3,000-bit keys to resist factorization.
* **Storage:** In a production setting, keys must be held in cryptographically secure containers (HSMs) and distributed via secure protocols like Diffie-Hellman.
* **Optimizations:** Advanced features like the Rabin-Miller primality test and massive prime generation are left as advanced exercises.

### Build Requirements
* **Language:** C# / .NET
* **Compiler:** Visual Studio 2022+
* **Dependencies:** `System.Numerics`

---

### References
* **Wikipedia:** [RSA Cryptosystem](https://en.wikipedia.org/wiki/RSA_(cryptosystem))
* **Menezes et al.:** *Handbook of Applied Cryptography*, CRC Press.
* **Rivest, Shamir, & Adleman (1978):** *A Method for Obtaining Digital Signatures and Public-Key Cryptosystems*.
