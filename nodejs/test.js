import { test, describe } from 'node:test';
import assert from 'node:assert';
import { calc } from './index.js';

describe('Formula Calculator Tests', () => {
  describe('Basic operations', () => {
    test('Basic arithmetic operations', async (t) => {
      await t.test('Addition', () => {
        assert.strictEqual(calc('2 + 3'), 5);
        assert.strictEqual(calc('10 + 20'), 30);
      });

      await t.test('Subtraction', () => {
        assert.strictEqual(calc('5 - 3'), 2);
        assert.strictEqual(calc('10 - 7'), 3);
      });

      await t.test('Multiplication', () => {
        assert.strictEqual(calc('4 * 5'), 20);
        assert.strictEqual(calc('6 * 7'), 42);
      });

      await t.test('Division', () => {
        assert.strictEqual(calc('10 / 2'), 5);
        assert.strictEqual(calc('15 / 3'), 5);
      });

      await t.test('Complex arithmetic', () => {
        assert.strictEqual(calc('2 + 3 * 4'), 14);
        assert.strictEqual(calc('(2 + 3) * 4'), 20);
        assert.strictEqual(calc('10 - 3 * 2'), 4);
      });
    });

    test('Exponentiation', async (t) => {
      await t.test('Basic exponentiation', () => {
        assert.strictEqual(calc('2 ^ 3'), 8);
        assert.strictEqual(calc('3 ^ 2'), 9);
        assert.strictEqual(calc('5 ^ 0'), 1);
      });

      await t.test('Using ** operator', () => {
        assert.strictEqual(calc('2 ** 3'), 8);
        assert.strictEqual(calc('3 ** 2'), 9);
      });
    });

    test('Mathematical constants', async (t) => {
      await t.test('PI constant', () => {
        assert.strictEqual(calc('PI'), Math.PI);
        assert.strictEqual(calc('pi'), Math.PI);
        assert.strictEqual(calc('Pi'), Math.PI);
      });

      await t.test('E constant', () => {
        assert.strictEqual(calc('E'), Math.E);
        assert.strictEqual(calc('e'), Math.E);
      });
    });

    test('Mathematical functions', async (t) => {
      await t.test('Square root', () => {
        assert.strictEqual(calc('sqrt(16)'), 4);
        assert.strictEqual(calc('sqrt(25)'), 5);
      });

      await t.test('Power function', () => {
        assert.strictEqual(calc('pow(2, 3)'), 8);
        assert.strictEqual(calc('pow(3, 2)'), 9);
      });

      await t.test('Absolute value', () => {
        assert.strictEqual(calc('abs(-5)'), 5);
        assert.strictEqual(calc('abs(5)'), 5);
      });

      await t.test('Rounding functions', () => {
        assert.strictEqual(calc('round(3.6)'), 4);
        assert.strictEqual(calc('floor(3.6)'), 3);
        assert.strictEqual(calc('ceil(3.2)'), 4);
      });

      await t.test('Min/Max functions', () => {
        assert.strictEqual(calc('min(5, 3, 8)'), 3);
        assert.strictEqual(calc('max(5, 3, 8)'), 8);
      });

      await t.test('Trigonometric functions', () => {
        assert.strictEqual(calc('sin(0)'), 0);
        assert.strictEqual(calc('cos(0)'), 1);
        assert.strictEqual(calc('tan(0)'), 0);
      });

      await t.test('Logarithm and exponential', () => {
        assert.strictEqual(calc('log(1)'), 0);
        assert.strictEqual(calc('exp(0)'), 1);
      });
    });
  });

  describe('Arguments support', () => {
    test('Arguments support', async (t) => {
      // the arguments should be marked start with $ 
      await t.test('Using arguments as variables', () => {
        assert.strictEqual(calc('$arg0 + $arg1', 5, 3), 8);
        assert.strictEqual(calc('$arg0 * $arg1', 4, 6), 24);
      });

      await t.test('Complex formula with arguments', () => {
        assert.strictEqual(calc('$arg0 * $arg1 + $arg2', 2, 3, 4), 10);
        assert.strictEqual(calc('sqrt($arg0) + $arg1', 16, 5), 9);
      });
    });

    test('Using named arguments', async (t) => {
      await t.test('Using arguments as variables', () => {
        assert.strictEqual(calc('$num1 + $num2', 5, 3), 8);
        assert.strictEqual(calc('$quantity * $price', 4, 6), 24);
      });
    });
  });

  describe('with complex logic', () => {
    test('with priority', async (t) => {
      await t.test('Calc according to priority', () => {
        assert.strictEqual(calc('($quantity + $existing) * $price', 4, 5, 6), 54);
      });
    });

    test('with nested functions', async (t) => {
      await t.test('Nested mathematical functions', () => {
        assert.strictEqual(calc('sqrt(pow($base, 2) + pow($height, 2))', 3, 4), 5);
        assert.strictEqual(calc('abs(sin($angle) * $radius)', 0, 5), 0);
      });
    });

    test('with mixed argument types', async (t) => {
      await t.test('Mixed argument types and complex expressions', () => {
        assert.strictEqual(calc('$arg0 + $quantity * $price', 10, 2, 3), 16);
        assert.strictEqual(calc('sqrt($base^2 + $height^2)', 3, 4), 5);
        assert.strictEqual(calc('($x + $y) * $z / $w', 5, 3, 4, 2), 16);
      });
    });
  });

  test('Error handling', async (t) => {
    await t.test('Invalid formula type', () => {
      assert.throws(() => calc(123), /Formula must be a string/);
      assert.throws(() => calc(null), /Formula must be a string/);
      assert.throws(() => calc(undefined), /Formula must be a string/);
    });

    await t.test('Empty formula', () => {
      assert.throws(() => calc(''), /Formula cannot be empty/);
      assert.throws(() => calc('   '), /Formula cannot be empty/);
    });

    await t.test('Invalid mathematical expressions', () => {
      assert.throws(() => calc('2 +'), /Invalid formula/);
      assert.throws(() => calc('* 5'), /Invalid formula/);
      assert.throws(() => calc('sqrt()'), /Invalid formula/);
    });

    await t.test('Division by zero', () => {
      assert.throws(() => calc('1 / 0'), /Invalid formula/);
    });

    await t.test('Invalid function calls', () => {
      assert.throws(() => calc('invalid(5)'), /Invalid formula/);
    });
  });

  test('Edge cases', async (t) => {
    await t.test('Single numbers', () => {
      assert.strictEqual(calc('42'), 42);
      assert.strictEqual(calc('3.14'), 3.14);
    });

    await t.test('Negative numbers', () => {
      assert.strictEqual(calc('-5'), -5);
      assert.strictEqual(calc('5 + (-3)'), 2);
    });

    await t.test('Parentheses', () => {
      assert.strictEqual(calc('(2 + 3) * 4'), 20);
      assert.strictEqual(calc('2 + (3 * 4)'), 14);
    });
  });
}); 