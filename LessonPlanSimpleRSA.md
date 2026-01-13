# Lesson Plan: The Mechanics of RSA Encryption
**Duration:** 90 Minutes  
**Prerequisites:** Basic understanding of prime numbers and algebra.  
**Objective:** Students will understand the mathematical foundation of RSA (GCD and Modular Arithmetic) and observe how these concepts are implemented in code.

---

### 1. Warm-up: The "Magic" of Modular Math (15 mins)
* **Concept:** Explain Modular Arithmetic (Clock Math). Focus on why it’s useful for cryptography: it’s easy to perform but hard to "undo" without specific information.
* **Exercise:** Simple Modular exponentiation.
    * *Question:* What is $7^3 \pmod{10}$? 
    * *Work:* $7 \times 7 = 49 \equiv 9$. $9 \times 7 = 63 \equiv 3$.
* **Online Tool:** [WolframAlpha](https://www.wolframalpha.com/input?i=7%5E3+mod+10) (Type: `7^3 mod 10`) or the [Omni Calculator - Modulo](https://www.omnicalculator.com/math/modulo).

### 2. The Greatest Common Divisor & Euclid (25 mins)


[Image of Euclidean Algorithm flowchart]

* **The Problem:** For RSA, we need to find two numbers that are "coprime" (GCD = 1).
* **The Algorithm:** Teach **Euclidean Algorithm** (repeated division).
    * *Example:* Find $GCD(1071, 462)$.
    * $1071 = 2(462) + 147$
    * $462 = 3(147) + 21$
    * $147 = 7(21) + 0 \rightarrow$ GCD is **21**.
* **Guided Practice:** Have students find $GCD(35, 12)$. (Result is 1, so they are coprime—essential for RSA).
* **Online Tool:** [Calculator.net GCD Calculator](https://www.calculator.net/gcd-calculator.html).

### 3. Understanding RSA (The SimpleRSA Model) (20 mins)

Explain the five steps of RSA using the logic found in the GitHub repo's `TestOne`:
1.  **Pick two primes ($p, q$):** Keep them small for class (e.g., 61 and 53).
2.  **Compute $n = p \times q$:** This is the modulus used in the code.
3.  **Compute Totient $\phi(n) = (p-1)(q-1)$:** This is where the Euclid math comes in.
4.  **Choose $e$:** Must be coprime with $\phi(n)$ (use Euclid here!).
5.  **Determine $d$:** The "modular inverse" (the secret key).

### 4. Code Deep-Dive: SimpleRSA (20 mins)
Open the [SimpleRSA GitHub](https://github.com/LandSharkFive/SimpleRSA) and walk through the four levels of complexity provided:
* **TestOne:** Highlight how it encrypts one character at a time using `MulMod()`. This mirrors the math they did in step 1.
* **TestTwo/Three:** Discuss the `ModularPow()` function. Explain that for large numbers, we can't just do $base^{exponent}$ because the number becomes too large for a computer to hold (overflow).
* **TestFour:** Show how "packing" works (putting multiple characters into one BigInteger). This is how real-world encryption is efficient.

### 5. Hands-on Activity: The Human RSA (10 mins)
* Break students into pairs.
* **Student A (Receiver):** Picks two small primes, calculates $n$ and $e$, and gives them to Student B.
* **Student B (Sender):** Uses a calculator to encrypt a single number (a "message") using $m^e \pmod{n}$.
* **Student A:** Decrypts it using their private key $d$.
* **Calculator Tip:** Use the Use the [Google Search Bar](https://www.google.com/search?q=7+pow+3+mod+10) or a Scientific Calculator (typically the `%` or `mod` button).

---

### Resources for Students
* **Code Reference:** [LandSharkFive/SimpleRSA](https://github.com/LandSharkFive/SimpleRSA)
* **Visualizer:** [RSA Visualizer](https://www.cs.drexel.edu/~jpopyack/Courses/CSP/Fa17/notes/RSA_Worksheet.html)
* **Advanced Reading:** The GitHub README suggests the *Handbook of Applied Cryptography*.
