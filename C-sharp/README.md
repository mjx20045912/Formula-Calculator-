# C# Formula Calculator

A C# module for calculating mathematical formulas with support for basic arithmetic operations, mathematical functions, and constants.

## Features

- Basic arithmetic operations (+, -, *, /, ^)
- Mathematical constants (PI, E)
- Mathematical functions (sqrt, pow, abs, sin, cos, tan, log, exp, etc.)
- Support for additional arguments as variables
- Safe evaluation with error handling
- Comprehensive test suite using xUnit
- .NET 8.0 support

## Requirements

- .NET 8.0 SDK or higher
- Visual Studio 2022 or VS Code with C# extension

## Installation

```bash
cd C-sharp
dotnet restore
dotnet build
```

## Usage

### Basic Usage

```csharp
using FormulaCalculator;

// Basic arithmetic
double result1 = FormulaCalculator.Calc("2 + 3"); // 5.0
double result2 = FormulaCalculator.Calc("10 - 5"); // 5.0
double result3 = FormulaCalculator.Calc("4 * 6"); // 24.0
double result4 = FormulaCalculator.Calc("15 / 3"); // 5.0

// Exponentiation
double result5 = FormulaCalculator.Calc("2 ^ 3"); // 8.0
double result6 = FormulaCalculator.Calc("3 ** 2"); // 9.0

// Mathematical constants
double result7 = FormulaCalculator.Calc("PI"); // 3.141592653589793
double result8 = FormulaCalculator.Calc("E"); // 2.718281828459045
```

### Mathematical Functions

```csharp
// Square root
double result1 = FormulaCalculator.Calc("sqrt(16)"); // 4.0

// Power function
double result2 = FormulaCalculator.Calc("pow(2, 3)"); // 8.0

// Absolute value
double result3 = FormulaCalculator.Calc("abs(-5)"); // 5.0

// Rounding functions
double result4 = FormulaCalculator.Calc("round(3.6)"); // 4.0
double result5 = FormulaCalculator.Calc("floor(3.6)"); // 3.0
double result6 = FormulaCalculator.Calc("ceil(3.2)"); // 4.0

// Min/Max functions
double result7 = FormulaCalculator.Calc("min(5, 3, 8)"); // 3.0
double result8 = FormulaCalculator.Calc("max(5, 3, 8)"); // 8.0

// Trigonometric functions
double result9 = FormulaCalculator.Calc("sin(0)"); // 0.0
double result10 = FormulaCalculator.Calc("cos(0)"); // 1.0
double result11 = FormulaCalculator.Calc("tan(0)"); // 0.0

// Logarithm and exponential
double result12 = FormulaCalculator.Calc("log(1)"); // 0.0
double result13 = FormulaCalculator.Calc("exp(0)"); // 1.0
```

### Using Arguments as Variables

```csharp
// Pass additional arguments that can be used in the formula
double result1 = FormulaCalculator.Calc("$arg0 + $arg1", 5, 3); // 8.0
double result2 = FormulaCalculator.Calc("$arg0 * $arg1", 4, 6); // 24.0
double result3 = FormulaCalculator.Calc("sqrt($arg0) + $arg1", 16, 5); // 9.0
double result4 = FormulaCalculator.Calc("$arg0 * $arg1 + $arg2", 2, 3, 4); // 10.0

// Using named arguments for better readability
double result5 = FormulaCalculator.Calc("$num1 + $num2", 5, 3); // 8.0
double result6 = FormulaCalculator.Calc("$quantity * $price", 4, 6); // 24.0
double result7 = FormulaCalculator.Calc("sqrt($base) + $offset", 16, 5); // 9.0
```

### Complex Formulas

```csharp
// Complex expressions with parentheses
double result1 = FormulaCalculator.Calc("(2 + 3) * 4"); // 20.0
double result2 = FormulaCalculator.Calc("2 + (3 * 4)"); // 14.0

// Using mathematical functions with constants
double result3 = FormulaCalculator.Calc("sin(PI/2)"); // 1.0
double result4 = FormulaCalculator.Calc("sqrt(16) + pow(2, 3)"); // 12.0
```

## API Reference

### `FormulaCalculator.Calc(string formula, params object[] args)`

Calculates the result of a mathematical formula.

**Parameters:**
- `formula` (string): The mathematical formula to evaluate
- `args` (params object[]): Additional arguments that can be used in the formula as `$arg0`, `$arg1`, etc.

**Returns:**
- `double`: The calculated result

**Throws:**
- `ArgumentException`: If the formula is invalid, empty, or cannot be evaluated

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

Run the test suite using .NET CLI:

```bash
dotnet test
```

Or run tests with detailed output:

```bash
dotnet test --verbosity normal
```

## Building

Build the project:

```bash
dotnet build
```

Create a release build:

```bash
dotnet build --configuration Release
```

## Running Examples

Run the example program:

```bash
dotnet run
```

Or run the compiled executable:

```bash
dotnet run --configuration Release
```

## Error Handling

The module includes comprehensive error handling:

```csharp
try
{
    double result = FormulaCalculator.Calc("2 + 3");
    Console.WriteLine(result); // 5.0
}
catch (ArgumentException e)
{
    Console.WriteLine($"Calculation error: {e.Message}");
}
```

Common error scenarios:
- Invalid formula syntax
- Division by zero
- Empty or null formulas
- Invalid function calls
- Non-numeric results

## Security

The module uses .NET's DataTable.Compute for safe expression evaluation. It only exposes mathematical functions and constants, preventing access to potentially dangerous operations.

## Performance

The module uses efficient string processing and regex operations for argument replacement. The DataTable.Compute method provides fast and safe expression evaluation.

## Technical Implementation

- **Expression Evaluation**: Uses System.Data.DataTable.Compute for safe formula evaluation
- **Argument Handling**: Regex-based replacement for `$` prefixed variables
- **Error Handling**: Comprehensive validation and meaningful error messages
- **Thread Safety**: Stateless implementation for concurrent usage
- **Security**: Safe evaluation context with only mathematical functions

## License

MIT License 