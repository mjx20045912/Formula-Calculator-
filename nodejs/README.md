# Formula Calculator

A Node.js module for calculating mathematical formulas with support for basic arithmetic operations, mathematical functions, and constants.

## Features

- Basic arithmetic operations (+, -, *, /, ^)
- Mathematical constants (PI, E)
- Mathematical functions (sqrt, pow, abs, sin, cos, tan, log, exp, etc.)
- Support for additional arguments as variables
- Safe evaluation with error handling
- Comprehensive test suite using Node.js built-in test runner

## Installation

```bash
cd nodejs
npm install
```

## Usage

### Basic Usage

```javascript
import { calc } from './index.js';

// Basic arithmetic
console.log(calc('2 + 3')); // 5
console.log(calc('10 - 5')); // 5
console.log(calc('4 * 6')); // 24
console.log(calc('15 / 3')); // 5

// Exponentiation
console.log(calc('2 ^ 3')); // 8
console.log(calc('3 ** 2')); // 9

// Mathematical constants
console.log(calc('PI')); // 3.141592653589793
console.log(calc('E')); // 2.718281828459045
```

### Mathematical Functions

```javascript
// Square root
console.log(calc('sqrt(16)')); // 4

// Power function
console.log(calc('pow(2, 3)')); // 8

// Absolute value
console.log(calc('abs(-5)')); // 5

// Rounding functions
console.log(calc('round(3.6)')); // 4
console.log(calc('floor(3.6)')); // 3
console.log(calc('ceil(3.2)')); // 4

// Min/Max functions
console.log(calc('min(5, 3, 8)')); // 3
console.log(calc('max(5, 3, 8)')); // 8

// Trigonometric functions
console.log(calc('sin(0)')); // 0
console.log(calc('cos(0)')); // 1
console.log(calc('tan(0)')); // 0

// Logarithm and exponential
console.log(calc('log(1)')); // 0
console.log(calc('exp(0)')); // 1
```

### Using Arguments as Variables

```javascript
// Pass additional arguments that can be used in the formula
console.log(calc('$arg0 + $arg1', 5, 3)); // 8
console.log(calc('$arg0 * $arg1', 4, 6)); // 24
console.log(calc('sqrt($arg0) + $arg1', 16, 5)); // 9
console.log(calc('$arg0 * $arg1 + $arg2', 2, 3, 4)); // 10

// Using named arguments for better readability
console.log(calc('$num1 + $num2', 5, 3)); // 8
console.log(calc('$quantity * $price', 4, 6)); // 24
console.log(calc('sqrt($base) + $offset', 16, 5)); // 9
```

### Complex Formulas

```javascript
// Complex expressions with parentheses
console.log(calc('(2 + 3) * 4')); // 20
console.log(calc('2 + (3 * 4)')); // 14

// Using mathematical functions with constants
console.log(calc('sin(PI/2)')); // 1
console.log(calc('sqrt(16) + pow(2, 3)')); // 12
```

## API Reference

### `calc(formula, ...args)`

Calculates the result of a mathematical formula.

**Parameters:**
- `formula` (string): The mathematical formula to evaluate
- `...args` (any): Additional arguments that can be used in the formula as `$arg0`, `$arg1`, etc.

**Returns:**
- `number`: The calculated result

**Throws:**
- `Error`: If the formula is invalid, empty, or cannot be evaluated

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

Run the test suite using Node.js built-in test runner:

```bash
npm test
```

Or run tests directly:

```bash
node --test test.js
```

## Error Handling

The module includes comprehensive error handling:

```javascript
try {
  const result = calc('2 + 3');
  console.log(result); // 5
} catch (error) {
  console.error('Calculation error:', error.message);
}
```

Common error scenarios:
- Invalid formula syntax
- Division by zero
- Empty or null formulas
- Invalid function calls
- Non-numeric results

## Security

The module uses a safe evaluation context that only exposes mathematical functions and constants. It does not allow access to global objects or potentially dangerous operations.

## License

MIT 