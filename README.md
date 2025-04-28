# FromAIGenTextToReadable

A small utility that converts LaTeX-style math formulas into more readable text using superscript, subscript, and special symbols.

This is useful when copying formulas from AI tools like ChatGPT, where you get LaTeX code like `\frac{1}{x^2}` and want to see it as readable text like `(¹)/(ₓ²)`.

---

## 💡 What It Does

✅ Converts LaTeX-style math like:

\frac{1}{x^2} → (¹)/(ₓ²)
x^2 + y_1 → x² + y₁
\sum_{i=1}^{n} → ∑ᵢ⁼¹ⁿ

✅ Supports:
- `\frac{a}{b}`
- superscript (`^`)
- subscript (`_`)
- Greek letters like `\alpha`, `\beta`, `\pi`
- symbols like `\sum`, `\rightarrow`, `\neq`, `\leq`, etc.

✅ Works with nested fractions (like `\frac{1}{\frac{2}{x}}`)

---

## 📁 Files

- `input.txt`: You write or paste your LaTeX-like math here.
- `output.txt`: The converted readable result will appear here.
- `help.txt`: Instructions in simple English.

---

## 🚀 How to Use

1. Run the program (from terminal or by starting it in Visual Studio or other IDE).
2. You will see a menu:
