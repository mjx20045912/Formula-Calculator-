import com.formulacalculator.FormulaCalculator;

/**
 * Example usage of the FormulaCalculator class
 */
public class Example {
    
    public static void main(String[] args) {
        System.out.println("=== Java Formula Calculator Example ===\n");
        
        try {
            // Basic arithmetic
            System.out.println("Basic Arithmetic:");
            System.out.println("2 + 3 = " + FormulaCalculator.calc("2 + 3"));
            System.out.println("10 - 5 = " + FormulaCalculator.calc("10 - 5"));
            System.out.println("4 * 6 = " + FormulaCalculator.calc("4 * 6"));
            System.out.println("15 / 3 = " + FormulaCalculator.calc("15 / 3"));
            System.out.println();
            
            // Exponentiation
            System.out.println("Exponentiation:");
            System.out.println("2 ^ 3 = " + FormulaCalculator.calc("2 ^ 3"));
            System.out.println("3 ** 2 = " + FormulaCalculator.calc("3 ** 2"));
            System.out.println();
            
            // Mathematical constants
            System.out.println("Mathematical Constants:");
            System.out.println("PI = " + FormulaCalculator.calc("PI"));
            System.out.println("E = " + FormulaCalculator.calc("E"));
            System.out.println();
            
            // Mathematical functions
            System.out.println("Mathematical Functions:");
            System.out.println("sqrt(16) = " + FormulaCalculator.calc("sqrt(16)"));
            System.out.println("pow(2, 3) = " + FormulaCalculator.calc("pow(2, 3)"));
            System.out.println("abs(-5) = " + FormulaCalculator.calc("abs(-5)"));
            System.out.println("round(3.6) = " + FormulaCalculator.calc("round(3.6)"));
            System.out.println("min(5, 3, 8) = " + FormulaCalculator.calc("min(5, 3, 8)"));
            System.out.println("max(5, 3, 8) = " + FormulaCalculator.calc("max(5, 3, 8)"));
            System.out.println();
            
            // Trigonometric functions
            System.out.println("Trigonometric Functions:");
            System.out.println("sin(0) = " + FormulaCalculator.calc("sin(0)"));
            System.out.println("cos(0) = " + FormulaCalculator.calc("cos(0)"));
            System.out.println("sin(PI/2) = " + FormulaCalculator.calc("sin(PI/2)"));
            System.out.println();
            
            // Using arguments
            System.out.println("Using Arguments:");
            System.out.println("$arg0 + $arg1 (5, 3) = " + FormulaCalculator.calc("$arg0 + $arg1", 5, 3));
            System.out.println("$arg0 * $arg1 (4, 6) = " + FormulaCalculator.calc("$arg0 * $arg1", 4, 6));
            System.out.println("sqrt($arg0) + $arg1 (16, 5) = " + FormulaCalculator.calc("sqrt($arg0) + $arg1", 16, 5));
            
            // Using named arguments
            System.out.println("Using Named Arguments:");
            System.out.println("$num1 + $num2 (5, 3) = " + FormulaCalculator.calc("$num1 + $num2", 5, 3));
            System.out.println("$quantity * $price (4, 6) = " + FormulaCalculator.calc("$quantity * $price", 4, 6));
            System.out.println("sqrt($base) + $offset (16, 5) = " + FormulaCalculator.calc("sqrt($base) + $offset", 16, 5));
            System.out.println();
            
            // Complex formulas
            System.out.println("Complex Formulas:");
            System.out.println("(2 + 3) * 4 = " + FormulaCalculator.calc("(2 + 3) * 4"));
            System.out.println("2 + (3 * 4) = " + FormulaCalculator.calc("2 + (3 * 4)"));
            System.out.println("sqrt(16) + pow(2, 3) = " + FormulaCalculator.calc("sqrt(16) + pow(2, 3)"));
            System.out.println();
            
            // Error handling example
            System.out.println("Error Handling:");
            try {
                System.out.println("Trying invalid formula: 2 +");
                FormulaCalculator.calc("2 +");
            } catch (IllegalArgumentException e) {
                System.out.println("Error caught: " + e.getMessage());
            }
            
            try {
                System.out.println("Trying division by zero: 1 / 0");
                FormulaCalculator.calc("1 / 0");
            } catch (IllegalArgumentException e) {
                System.out.println("Error caught: " + e.getMessage());
            }
            System.out.println();
            
            System.out.println("=== Example completed ===");
            
        } catch (Exception e) {
            System.err.println("Error running examples: " + e.getMessage());
            e.printStackTrace();
        }
    }
} 