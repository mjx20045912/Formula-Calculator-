using System;
using Xunit;

namespace FormulaCalculator.Tests
{
    /// <summary>
    /// Comprehensive test suite for FormulaCalculator
    /// </summary>
    public class FormulaCalculatorTests
    {
        public class BasicOperations
        {
            public class BasicArithmetic
            {
                [Fact]
                public void Addition()
                {
                    Assert.Equal(5.0, FormulaCalculator.Calc("2 + 3"));
                    Assert.Equal(30.0, FormulaCalculator.Calc("10 + 20"));
                }

                [Fact]
                public void Subtraction()
                {
                    Assert.Equal(2.0, FormulaCalculator.Calc("5 - 3"));
                    Assert.Equal(3.0, FormulaCalculator.Calc("10 - 7"));
                }

                [Fact]
                public void Multiplication()
                {
                    Assert.Equal(20.0, FormulaCalculator.Calc("4 * 5"));
                    Assert.Equal(42.0, FormulaCalculator.Calc("6 * 7"));
                }

                [Fact]
                public void Division()
                {
                    Assert.Equal(5.0, FormulaCalculator.Calc("10 / 2"));
                    Assert.Equal(5.0, FormulaCalculator.Calc("15 / 3"));
                }

                [Fact]
                public void ComplexArithmetic()
                {
                    Assert.Equal(14.0, FormulaCalculator.Calc("2 + 3 * 4"));
                    Assert.Equal(20.0, FormulaCalculator.Calc("(2 + 3) * 4"));
                    Assert.Equal(4.0, FormulaCalculator.Calc("10 - 3 * 2"));
                }
            }

            public class Exponentiation
            {
                [Fact]
                public void BasicExponentiation()
                {
                    Assert.Equal(8.0, FormulaCalculator.Calc("2 ^ 3"));
                    Assert.Equal(9.0, FormulaCalculator.Calc("3 ^ 2"));
                    Assert.Equal(1.0, FormulaCalculator.Calc("5 ^ 0"));
                }

                [Fact]
                public void UsingDoubleStarOperator()
                {
                    Assert.Equal(8.0, FormulaCalculator.Calc("2 ** 3"));
                    Assert.Equal(9.0, FormulaCalculator.Calc("3 ** 2"));
                }
            }

            public class MathematicalConstants
            {
                [Fact]
                public void PIConstant()
                {
                    Assert.Equal(Math.PI, FormulaCalculator.Calc("PI"));
                    Assert.Equal(Math.PI, FormulaCalculator.Calc("pi"));
                    Assert.Equal(Math.PI, FormulaCalculator.Calc("Pi"));
                }

                [Fact]
                public void EConstant()
                {
                    Assert.Equal(Math.E, FormulaCalculator.Calc("E"));
                    Assert.Equal(Math.E, FormulaCalculator.Calc("e"));
                }
            }

            public class MathematicalFunctions
            {
                [Fact]
                public void SquareRoot()
                {
                    Assert.Equal(4.0, FormulaCalculator.Calc("sqrt(16)"));
                    Assert.Equal(5.0, FormulaCalculator.Calc("sqrt(25)"));
                }

                [Fact]
                public void PowerFunction()
                {
                    Assert.Equal(8.0, FormulaCalculator.Calc("pow(2, 3)"));
                    Assert.Equal(9.0, FormulaCalculator.Calc("pow(3, 2)"));
                }

                [Fact]
                public void AbsoluteValue()
                {
                    Assert.Equal(5.0, FormulaCalculator.Calc("abs(-5)"));
                    Assert.Equal(5.0, FormulaCalculator.Calc("abs(5)"));
                }

                [Fact]
                public void RoundingFunctions()
                {
                    Assert.Equal(4.0, FormulaCalculator.Calc("round(3.6)"));
                    Assert.Equal(3.0, FormulaCalculator.Calc("floor(3.6)"));
                    Assert.Equal(4.0, FormulaCalculator.Calc("ceil(3.2)"));
                }

                [Fact]
                public void MinMaxFunctions()
                {
                    Assert.Equal(3.0, FormulaCalculator.Calc("min(5, 3, 8)"));
                    Assert.Equal(8.0, FormulaCalculator.Calc("max(5, 3, 8)"));
                }

                [Fact]
                public void TrigonometricFunctions()
                {
                    Assert.Equal(0.0, FormulaCalculator.Calc("sin(0)"));
                    Assert.Equal(1.0, FormulaCalculator.Calc("cos(0)"));
                    Assert.Equal(0.0, FormulaCalculator.Calc("tan(0)"));
                }

                [Fact]
                public void LogarithmAndExponential()
                {
                    Assert.Equal(0.0, FormulaCalculator.Calc("log(1)"));
                    Assert.Equal(1.0, FormulaCalculator.Calc("exp(0)"));
                }
            }
        }

        public class ArgumentsSupport
        {
            public class ArgumentsSupportTests
            {
                [Fact]
                public void UsingArgumentsAsVariables()
                {
                    Assert.Equal(8.0, FormulaCalculator.Calc("$arg0 + $arg1", 5, 3));
                    Assert.Equal(24.0, FormulaCalculator.Calc("$arg0 * $arg1", 4, 6));
                }

                [Fact]
                public void ComplexFormulaWithArguments()
                {
                    Assert.Equal(10.0, FormulaCalculator.Calc("$arg0 * $arg1 + $arg2", 2, 3, 4));
                    Assert.Equal(9.0, FormulaCalculator.Calc("sqrt($arg0) + $arg1", 16, 5));
                }
            }

            public class NamedArguments
            {
                [Fact]
                public void UsingNamedArgumentsAsVariables()
                {
                    Assert.Equal(8.0, FormulaCalculator.Calc("$num1 + $num2", 5, 3));
                    Assert.Equal(24.0, FormulaCalculator.Calc("$quantity * $price", 4, 6));
                }
            }
        }

        public class ComplexLogic
        {
            public class PriorityTests
            {
                [Fact]
                public void CalcAccordingToPriority()
                {
                    Assert.Equal(54.0, FormulaCalculator.Calc("($quantity + $existing) * $price", 4, 5, 6));
                }
            }

            public class NestedFunctions
            {
                [Fact]
                public void NestedMathematicalFunctions()
                {
                    Assert.Equal(5.0, FormulaCalculator.Calc("sqrt(pow($base, 2) + pow($height, 2))", 3, 4));
                    Assert.Equal(0.0, FormulaCalculator.Calc("abs(sin($angle) * $radius)", 0, 5));
                }
            }

            public class MixedArgumentTypes
            {
                [Fact]
                public void MixedArgumentTypesAndComplexExpressions()
                {
                    Assert.Equal(16.0, FormulaCalculator.Calc("$arg0 + $quantity * $price", 10, 2, 3));
                    Assert.Equal(5.0, FormulaCalculator.Calc("sqrt($base^2 + $height^2)", 3, 4));
                    Assert.Equal(16.0, FormulaCalculator.Calc("($x + $y) * $z / $w", 5, 3, 4, 2));
                }
            }
        }

        public class ErrorHandling
        {
            [Fact]
            public void InvalidFormulaType()
            {
                Assert.Throws<ArgumentException>(() => FormulaCalculator.Calc(null!));
            }

            [Fact]
            public void EmptyFormula()
            {
                Assert.Throws<ArgumentException>(() => FormulaCalculator.Calc(""));
                Assert.Throws<ArgumentException>(() => FormulaCalculator.Calc("   "));
            }

            [Fact]
            public void InvalidMathematicalExpressions()
            {
                Assert.Throws<ArgumentException>(() => FormulaCalculator.Calc("2 +"));
                Assert.Throws<ArgumentException>(() => FormulaCalculator.Calc("* 5"));
                Assert.Throws<ArgumentException>(() => FormulaCalculator.Calc("sqrt()"));
            }

            [Fact]
            public void DivisionByZero()
            {
                Assert.Throws<ArgumentException>(() => FormulaCalculator.Calc("1 / 0"));
            }

            [Fact]
            public void InvalidFunctionCalls()
            {
                Assert.Throws<ArgumentException>(() => FormulaCalculator.Calc("invalid(5)"));
            }
        }

        public class EdgeCases
        {
            [Fact]
            public void SingleNumbers()
            {
                Assert.Equal(42.0, FormulaCalculator.Calc("42"));
                Assert.Equal(3.14, FormulaCalculator.Calc("3.14"));
            }

            [Fact]
            public void NegativeNumbers()
            {
                Assert.Equal(-5.0, FormulaCalculator.Calc("-5"));
                Assert.Equal(2.0, FormulaCalculator.Calc("5 + (-3)"));
            }

            [Fact]
            public void Parentheses()
            {
                Assert.Equal(20.0, FormulaCalculator.Calc("(2 + 3) * 4"));
                Assert.Equal(14.0, FormulaCalculator.Calc("2 + (3 * 4)"));
            }
        }
    }
} 