# Java Formula Calculator

A Java module for calculating mathematical formulas with support for basic arithmetic operations, mathematical functions, and constants.

## Features

- Basic arithmetic operations (+, -, *, /, ^)
- Mathematical constants (PI, E)
- Mathematical functions (sqrt, pow, abs, sin, cos, tan, log, exp, etc.)
- Support for additional arguments as variables
- Safe evaluation with error handling
- Comprehensive test suite using JUnit 5

## Requirements

- Java 17 or higher
- Maven 3.6 or higher

## Installation

```bash
cd java
mvn clean install
```

## Usage

### Basic Usage

```java
import com.formulacalculator.FormulaCalculator;

// Basic arithmetic
double result1 = FormulaCalculator.calc("2 + 3"); // 5.0
double result2 = FormulaCalculator.calc("10 - 5"); // 5.0
double result3 = FormulaCalculator.calc("4 * 6"); // 24.0
double result4 = FormulaCalculator.calc("15 / 3"); // 5.0

// Exponentiation
double result5 = FormulaCalculator.calc("2 ^ 3"); // 8.0
double result6 = FormulaCalculator.calc("3 ** 2"); // 9.0

// Mathematical constants
double result7 = FormulaCalculator.calc("PI"); // 3.141592653589793
double result8 = FormulaCalculator.calc("E"); // 2.718281828459045
```

### Mathematical Functions

```java
// Square root
double result1 = FormulaCalculator.calc("sqrt(16)"); // 4.0

// Power function
double result2 = FormulaCalculator.calc("pow(2, 3)"); // 8.0

// Absolute value
double result3 = FormulaCalculator.calc("abs(-5)"); // 5.0

// Rounding functions
double result4 = FormulaCalculator.calc("round(3.6)"); // 4.0
double result5 = FormulaCalculator.calc("floor(3.6)"); // 3.0
double result6 = FormulaCalculator.calc("ceil(3.2)"); // 4.0

// Min/Max functions
double result7 = FormulaCalculator.calc("min(5, 3, 8)"); // 3.0
double result8 = FormulaCalculator.calc("max(5, 3, 8)"); // 8.0

// Trigonometric functions
double result9 = FormulaCalculator.calc("sin(0)"); // 0.0
double result10 = FormulaCalculator.calc("cos(0)"); // 1.0
double result11 = FormulaCalculator.calc("tan(0)"); // 0.0

// Logarithm and exponential
double result12 = FormulaCalculator.calc("log(1)"); // 0.0
double result13 = FormulaCalculator.calc("exp(0)"); // 1.0
```

### Using Arguments as Variables

```java
// Pass additional arguments that can be used in the formula
double result1 = FormulaCalculator.calc("$arg0 + $arg1", 5, 3); // 8.0
double result2 = FormulaCalculator.calc("$arg0 * $arg1", 4, 6); // 24.0
double result3 = FormulaCalculator.calc("sqrt($arg0) + $arg1", 16, 5); // 9.0
double result4 = FormulaCalculator.calc("$arg0 * $arg1 + $arg2", 2, 3, 4); // 10.0

// Using named arguments for better readability
double result5 = FormulaCalculator.calc("$num1 + $num2", 5, 3); // 8.0
double result6 = FormulaCalculator.calc("$quantity * $price", 4, 6); // 24.0
double result7 = FormulaCalculator.calc("sqrt($base) + $offset", 16, 5); // 9.0
```

### Complex Formulas

```java
// Complex expressions with parentheses
double result1 = FormulaCalculator.calc("(2 + 3) * 4"); // 20.0
double result2 = FormulaCalculator.calc("2 + (3 * 4)"); // 14.0

// Using mathematical functions with constants
double result3 = FormulaCalculator.calc("sin(PI/2)"); // 1.0
double result4 = FormulaCalculator.calc("sqrt(16) + pow(2, 3)"); // 12.0
```

## API Reference

### `FormulaCalculator.calc(String formula, Object... args)`

Calculates the result of a mathematical formula.

**Parameters:**
- `formula` (String): The mathematical formula to evaluate
- `args` (Object...): Additional arguments that can be used in the formula as `$arg0`, `$arg1`, etc.

**Returns:**
- `double`: The calculated result

**Throws:**
- `IllegalArgumentException`: If the formula is invalid, empty, or cannot be evaluated

## Supported Operations

### Arithmetic Operators
- `+` Addition
- `-` Subtraction
- `*` Multiplication
- `/` Division
- `^` or `**` Exponentiation

### Mathematical Constants
- `PI` or `pi` - π (3.141592653589793)
- `E` or `e` - Euler's number (2.718281828459045)

### Mathematical Functions
- `sqrt(x)` - Square root
- `pow(x, y)` - Power function
- `abs(x)` - Absolute value
- `ceil(x)` - Ceiling function
- `floor(x)` - Floor function
- `round(x)` - Round function
- `max(x, y, ...)` - Maximum value
- `min(x, y, ...)` - Minimum value
- `sin(x)` - Sine function
- `cos(x)` - Cosine function
- `tan(x)` - Tangent function
- `log(x)` - Natural logarithm
- `exp(x)` - Exponential function
- `random()` - Random number between 0 and 1

## Testing

Run the test suite using Maven:

```bash
mvn test
```

Or run tests with detailed output:

```bash
mvn test -Dtest=FormulaCalculatorTest
```

## Building

Build the project:

```bash
mvn clean compile
```

Create a JAR file:

```bash
mvn clean package
```

## Running Examples

Run the example program:

```bash
mvn exec:java -Dexec.mainClass="com.formulacalculator.FormulaCalculator"
```

Or run the compiled JAR:

```bash
java -cp target/formula-calculator-1.0.0.jar com.formulacalculator.FormulaCalculator
```

## Error Handling

The module includes comprehensive error handling:

```java
try {
    double result = FormulaCalculator.calc("2 + 3");
    System.out.println(result); // 5.0
} catch (IllegalArgumentException e) {
    System.err.println("Calculation error: " + e.getMessage());
}
```

Common error scenarios:
- Invalid formula syntax
- Division by zero
- Empty or null formulas
- Invalid function calls
- Non-numeric results

## Security

The module uses Java's ScriptEngine (Nashorn) for safe evaluation. It only exposes mathematical functions and constants, preventing access to potentially dangerous operations.

## Performance

The module uses a single ScriptEngine instance for better performance. The engine is thread-safe for concurrent usage.

## License

MIT License 