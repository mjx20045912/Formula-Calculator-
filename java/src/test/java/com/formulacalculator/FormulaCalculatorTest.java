package com.formulacalculator;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Nested;
import static org.junit.jupiter.api.Assertions.*;

/**
 * Comprehensive test suite for FormulaCalculator
 */
@DisplayName("Formula Calculator Tests")
class FormulaCalculatorTest {

    @Nested
    @DisplayName("Basic operations")
    class BasicOperations {
        
        @Nested
        @DisplayName("Basic arithmetic operations")
        class BasicArithmetic {
            
            @Test
            @DisplayName("Addition")
            void testAddition() {
                assertEquals(5.0, FormulaCalculator.calc("2 + 3"));
                assertEquals(30.0, FormulaCalculator.calc("10 + 20"));
            }
            
            @Test
            @DisplayName("Subtraction")
            void testSubtraction() {
                assertEquals(2.0, FormulaCalculator.calc("5 - 3"));
                assertEquals(3.0, FormulaCalculator.calc("10 - 7"));
            }
            
            @Test
            @DisplayName("Multiplication")
            void testMultiplication() {
                assertEquals(20.0, FormulaCalculator.calc("4 * 5"));
                assertEquals(42.0, FormulaCalculator.calc("6 * 7"));
            }
            
            @Test
            @DisplayName("Division")
            void testDivision() {
                assertEquals(5.0, FormulaCalculator.calc("10 / 2"));
                assertEquals(5.0, FormulaCalculator.calc("15 / 3"));
            }
            
            @Test
            @DisplayName("Complex arithmetic")
            void testComplexArithmetic() {
                assertEquals(14.0, FormulaCalculator.calc("2 + 3 * 4"));
                assertEquals(20.0, FormulaCalculator.calc("(2 + 3) * 4"));
                assertEquals(4.0, FormulaCalculator.calc("10 - 3 * 2"));
            }
        }
        
        @Nested
        @DisplayName("Exponentiation")
        class Exponentiation {
            
            @Test
            @DisplayName("Basic exponentiation")
            void testBasicExponentiation() {
                assertEquals(8.0, FormulaCalculator.calc("2 ^ 3"));
                assertEquals(9.0, FormulaCalculator.calc("3 ^ 2"));
                assertEquals(1.0, FormulaCalculator.calc("5 ^ 0"));
            }
            
            @Test
            @DisplayName("Using ** operator")
            void testDoubleStarOperator() {
                assertEquals(8.0, FormulaCalculator.calc("2 ** 3"));
                assertEquals(9.0, FormulaCalculator.calc("3 ** 2"));
            }
        }
        
        @Nested
        @DisplayName("Mathematical constants")
        class MathematicalConstants {
            
            @Test
            @DisplayName("PI constant")
            void testPIConstant() {
                assertEquals(Math.PI, FormulaCalculator.calc("PI"));
                assertEquals(Math.PI, FormulaCalculator.calc("pi"));
                assertEquals(Math.PI, FormulaCalculator.calc("Pi"));
            }
            
            @Test
            @DisplayName("E constant")
            void testEConstant() {
                assertEquals(Math.E, FormulaCalculator.calc("E"));
                assertEquals(Math.E, FormulaCalculator.calc("e"));
            }
        }
        
        @Nested
        @DisplayName("Mathematical functions")
        class MathematicalFunctions {
            
            @Test
            @DisplayName("Square root")
            void testSquareRoot() {
                assertEquals(4.0, FormulaCalculator.calc("sqrt(16)"));
                assertEquals(5.0, FormulaCalculator.calc("sqrt(25)"));
            }
            
            @Test
            @DisplayName("Power function")
            void testPowerFunction() {
                assertEquals(8.0, FormulaCalculator.calc("pow(2, 3)"));
                assertEquals(9.0, FormulaCalculator.calc("pow(3, 2)"));
            }
            
            @Test
            @DisplayName("Absolute value")
            void testAbsoluteValue() {
                assertEquals(5.0, FormulaCalculator.calc("abs(-5)"));
                assertEquals(5.0, FormulaCalculator.calc("abs(5)"));
            }
            
            @Test
            @DisplayName("Rounding functions")
            void testRoundingFunctions() {
                assertEquals(4.0, FormulaCalculator.calc("round(3.6)"));
                assertEquals(3.0, FormulaCalculator.calc("floor(3.6)"));
                assertEquals(4.0, FormulaCalculator.calc("ceil(3.2)"));
            }
            
            @Test
            @DisplayName("Min/Max functions")
            void testMinMaxFunctions() {
                assertEquals(3.0, FormulaCalculator.calc("min(5, 3, 8)"));
                assertEquals(8.0, FormulaCalculator.calc("max(5, 3, 8)"));
            }
            
            @Test
            @DisplayName("Trigonometric functions")
            void testTrigonometricFunctions() {
                assertEquals(0.0, FormulaCalculator.calc("sin(0)"));
                assertEquals(1.0, FormulaCalculator.calc("cos(0)"));
                assertEquals(0.0, FormulaCalculator.calc("tan(0)"));
            }
            
            @Test
            @DisplayName("Logarithm and exponential")
            void testLogarithmAndExponential() {
                assertEquals(0.0, FormulaCalculator.calc("log(1)"));
                assertEquals(1.0, FormulaCalculator.calc("exp(0)"));
            }
        }
    }
    
    @Nested
    @DisplayName("Arguments support")
    class ArgumentsSupport {
        
        @Nested
        @DisplayName("Arguments support")
        class ArgumentsSupportTests {
            
            @Test
            @DisplayName("Using arguments as variables")
            void testUsingArgumentsAsVariables() {
                assertEquals(8.0, FormulaCalculator.calc("$arg0 + $arg1", 5, 3));
                assertEquals(24.0, FormulaCalculator.calc("$arg0 * $arg1", 4, 6));
            }
            
            @Test
            @DisplayName("Complex formula with arguments")
            void testComplexFormulaWithArguments() {
                assertEquals(10.0, FormulaCalculator.calc("$arg0 * $arg1 + $arg2", 2, 3, 4));
                assertEquals(9.0, FormulaCalculator.calc("sqrt($arg0) + $arg1", 16, 5));
            }
        }
        
        @Nested
        @DisplayName("Using named arguments")
        class NamedArguments {
            
            @Test
            @DisplayName("Using arguments as variables")
            void testUsingNamedArgumentsAsVariables() {
                assertEquals(8.0, FormulaCalculator.calc("$num1 + $num2", 5, 3));
                assertEquals(24.0, FormulaCalculator.calc("$quantity * $price", 4, 6));
            }
        }
    }
    
    @Nested
    @DisplayName("with complex logic")
    class ComplexLogic {
        
        @Nested
        @DisplayName("with priority")
        class PriorityTests {
            
            @Test
            @DisplayName("Calc according to priority")
            void testCalcAccordingToPriority() {
                assertEquals(54.0, FormulaCalculator.calc("($quantity + $existing) * $price", 4, 5, 6));
            }
        }
        
        @Nested
        @DisplayName("with nested functions")
        class NestedFunctions {
            
            @Test
            @DisplayName("Nested mathematical functions")
            void testNestedMathematicalFunctions() {
                assertEquals(5.0, FormulaCalculator.calc("sqrt(pow($base, 2) + pow($height, 2))", 3, 4));
                assertEquals(0.0, FormulaCalculator.calc("abs(sin($angle) * $radius)", 0, 5));
            }
        }
        
        @Nested
        @DisplayName("with mixed argument types")
        class MixedArgumentTypes {
            
            @Test
            @DisplayName("Mixed argument types and complex expressions")
            void testMixedArgumentTypesAndComplexExpressions() {
                assertEquals(16.0, FormulaCalculator.calc("$arg0 + $quantity * $price", 10, 2, 3));
                assertEquals(5.0, FormulaCalculator.calc("sqrt($base^2 + $height^2)", 3, 4));
                assertEquals(16.0, FormulaCalculator.calc("($x + $y) * $z / $w", 5, 3, 4, 2));
            }
        }
    }
    
    @Nested
    @DisplayName("Error handling")
    class ErrorHandling {
        
        @Test
        @DisplayName("Invalid formula type")
        void testInvalidFormulaType() {
            assertThrows(IllegalArgumentException.class, () -> FormulaCalculator.calc(null));
        }
        
        @Test
        @DisplayName("Empty formula")
        void testEmptyFormula() {
            assertThrows(IllegalArgumentException.class, () -> FormulaCalculator.calc(""));
            assertThrows(IllegalArgumentException.class, () -> FormulaCalculator.calc("   "));
        }
        
        @Test
        @DisplayName("Invalid mathematical expressions")
        void testInvalidMathematicalExpressions() {
            assertThrows(IllegalArgumentException.class, () -> FormulaCalculator.calc("2 +"));
            assertThrows(IllegalArgumentException.class, () -> FormulaCalculator.calc("* 5"));
            assertThrows(IllegalArgumentException.class, () -> FormulaCalculator.calc("sqrt()"));
        }
        
        @Test
        @DisplayName("Division by zero")
        void testDivisionByZero() {
            assertThrows(IllegalArgumentException.class, () -> FormulaCalculator.calc("1 / 0"));
        }
        
        @Test
        @DisplayName("Invalid function calls")
        void testInvalidFunctionCalls() {
            assertThrows(IllegalArgumentException.class, () -> FormulaCalculator.calc("invalid(5)"));
        }
    }
    
    @Nested
    @DisplayName("Edge cases")
    class EdgeCases {
        
        @Test
        @DisplayName("Single numbers")
        void testSingleNumbers() {
            assertEquals(42.0, FormulaCalculator.calc("42"));
            assertEquals(3.14, FormulaCalculator.calc("3.14"));
        }
        
        @Test
        @DisplayName("Negative numbers")
        void testNegativeNumbers() {
            assertEquals(-5.0, FormulaCalculator.calc("-5"));
            assertEquals(2.0, FormulaCalculator.calc("5 + (-3)"));
        }
        
        @Test
        @DisplayName("Parentheses")
        void testParentheses() {
            assertEquals(20.0, FormulaCalculator.calc("(2 + 3) * 4"));
            assertEquals(14.0, FormulaCalculator.calc("2 + (3 * 4)"));
        }
    }
} 