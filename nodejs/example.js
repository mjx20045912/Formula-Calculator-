import { calc } from './index.js';

console.log('=== Formula Calculator Examples ===\n');

// Basic arithmetic
console.log('Basic Arithmetic:');
console.log('2 + 3 =', calc('2 + 3'));
console.log('10 - 5 =', calc('10 - 5'));
console.log('4 * 6 =', calc('4 * 6'));
console.log('15 / 3 =', calc('15 / 3'));
console.log('');

// Exponentiation
console.log('Exponentiation:');
console.log('2 ^ 3 =', calc('2 ^ 3'));
console.log('3 ** 2 =', calc('3 ** 2'));
console.log('');

// Mathematical constants
console.log('Mathematical Constants:');
console.log('PI =', calc('PI'));
console.log('E =', calc('E'));
console.log('');

// Mathematical functions
console.log('Mathematical Functions:');
console.log('sqrt(16) =', calc('sqrt(16)'));
console.log('pow(2, 3) =', calc('pow(2, 3)'));
console.log('abs(-5) =', calc('abs(-5)'));
console.log('round(3.6) =', calc('round(3.6)'));
console.log('min(5, 3, 8) =', calc('min(5, 3, 8)'));
console.log('max(5, 3, 8) =', calc('max(5, 3, 8)'));
console.log('');

// Trigonometric functions
console.log('Trigonometric Functions:');
console.log('sin(0) =', calc('sin(0)'));
console.log('cos(0) =', calc('cos(0)'));
console.log('sin(PI/2) =', calc('sin(PI/2)'));
console.log('');

// Using arguments
console.log('Using Arguments:');
console.log('$arg0 + $arg1 (5, 3) =', calc('$arg0 + $arg1', 5, 3));
console.log('$arg0 * $arg1 (4, 6) =', calc('$arg0 * $arg1', 4, 6));
console.log('sqrt($arg0) + $arg1 (16, 5) =', calc('sqrt($arg0) + $arg1', 16, 5));

// Using named arguments
console.log('Using Named Arguments:');
console.log('$num1 + $num2 (5, 3) =', calc('$num1 + $num2', 5, 3));
console.log('$quantity * $price (4, 6) =', calc('$quantity * $price', 4, 6));
console.log('sqrt($base) + $offset (16, 5) =', calc('sqrt($base) + $offset', 16, 5));
console.log('');

// Complex formulas
console.log('Complex Formulas:');
console.log('(2 + 3) * 4 =', calc('(2 + 3) * 4'));
console.log('2 + (3 * 4) =', calc('2 + (3 * 4)'));
console.log('sqrt(16) + pow(2, 3) =', calc('sqrt(16) + pow(2, 3)'));
console.log('');

// Error handling example
console.log('Error Handling:');
try {
  console.log('Trying invalid formula: 2 +');
  calc('2 +');
} catch (error) {
  console.log('Error caught:', error.message);
}

try {
  console.log('Trying division by zero: 1 / 0');
  calc('1 / 0');
} catch (error) {
  console.log('Error caught:', error.message);
}
console.log('');

console.log('=== Examples completed ==='); 