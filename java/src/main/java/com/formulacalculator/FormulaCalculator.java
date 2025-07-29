package com.formulacalculator;

import java.util.HashMap;
import java.util.Map;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import javax.script.ScriptEngine;
import javax.script.ScriptEngineManager;
import javax.script.ScriptException;

/**
 * Formula Calculator Module
 * 
 * This module provides a function to calculate mathematical formulas
 * with support for basic arithmetic operations and common mathematical functions.
 * The arguments should be marked start with $, like calc("$arg0 + $arg1", 5, 3) = 8
 */
public class FormulaCalculator {
    
    private static final ScriptEngine engine = new ScriptEngineManager().getEngineByName("nashorn");
    
    /**
     * Calculates the result of a mathematical formula
     * @param formula The mathematical formula to evaluate
     * @param args Additional arguments that can be used in the formula
     * @return The calculated result
     * @throws IllegalArgumentException If the formula is invalid or cannot be evaluated
     */
    public static double calc(String formula, Object... args) {
        if (formula == null) {
            throw new IllegalArgumentException("Formula cannot be null");
        }
        
        if (formula.trim().isEmpty()) {
            throw new IllegalArgumentException("Formula cannot be empty");
        }
        
        try {
            // Replace common mathematical symbols with JavaScript equivalents
            String processedFormula = formula
                .replaceAll("\\^", "**") // Replace ^ with ** for exponentiation
                .replaceAll("(?i)\\bpi\\b", "Math.PI") // Replace pi with Math.PI
                .replaceAll("(?i)\\be\\b", "Math.E"); // Replace e with Math.E
            
            // Handle all named arguments (both $arg0, $arg1, etc. and custom names)
            Pattern namedArgPattern = Pattern.compile("\\$[a-zA-Z_][a-zA-Z0-9_]*");
            Matcher matcher = namedArgPattern.matcher(processedFormula);
            
            // Replace named arguments with actual values
            int argIndex = 0;
            while (matcher.find() && argIndex < args.length) {
                String namedArg = matcher.group();
                String replacement = String.valueOf(args[argIndex]);
                processedFormula = processedFormula.replace(namedArg, replacement);
                argIndex++;
            }
            
            // Create a safe evaluation context with mathematical functions
            Map<String, Object> context = new HashMap<>();
            context.put("Math", Math.class);
            context.put("PI", Math.PI);
            context.put("E", Math.E);
            context.put("abs", Math.abs(0.0));
            context.put("ceil", Math.ceil(0.0));
            context.put("floor", Math.floor(0.0));
            context.put("round", Math.round(0.0));
            context.put("max", Math.max(0.0, 0.0));
            context.put("min", Math.min(0.0, 0.0));
            context.put("pow", Math.pow(0.0, 0.0));
            context.put("sqrt", Math.sqrt(0.0));
            context.put("sin", Math.sin(0.0));
            context.put("cos", Math.cos(0.0));
            context.put("tan", Math.tan(0.0));
            context.put("log", Math.log(0.0));
            context.put("exp", Math.exp(0.0));
            context.put("random", Math.random());
            
            // Add mathematical functions to the engine
            engine.put("Math", Math.class);
            engine.put("PI", Math.PI);
            engine.put("E", Math.E);
            
            // Execute the formula
            Object result = engine.eval(processedFormula);
            
            // Validate the result
            if (result instanceof Number) {
                double doubleResult = ((Number) result).doubleValue();
                if (Double.isFinite(doubleResult)) {
                    return doubleResult;
                } else {
                    throw new IllegalArgumentException("Formula evaluation resulted in an invalid number");
                }
            } else {
                throw new IllegalArgumentException("Formula evaluation did not return a number");
            }
            
        } catch (ScriptException e) {
            throw new IllegalArgumentException("Invalid formula: " + e.getMessage());
        } catch (Exception e) {
            throw new IllegalArgumentException("Invalid formula: " + e.getMessage());
        }
    }
    
    /**
     * Main method for running examples
     */
    public static void main(String[] args) {
        System.out.println("=== Formula Calculator Examples ===\n");
        
        try {
            // Basic arithmetic
            System.out.println("Basic Arithmetic:");
            System.out.println("2 + 3 = " + calc("2 + 3"));
            System.out.println("10 - 5 = " + calc("10 - 5"));
            System.out.println("4 * 6 = " + calc("4 * 6"));
            System.out.println("15 / 3 = " + calc("15 / 3"));
            System.out.println();
            
            // Exponentiation
            System.out.println("Exponentiation:");
            System.out.println("2 ^ 3 = " + calc("2 ^ 3"));
            System.out.println("3 ** 2 = " + calc("3 ** 2"));
            System.out.println();
            
            // Mathematical constants
            System.out.println("Mathematical Constants:");
            System.out.println("PI = " + calc("PI"));
            System.out.println("E = " + calc("E"));
            System.out.println();
            
            // Mathematical functions
            System.out.println("Mathematical Functions:");
            System.out.println("sqrt(16) = " + calc("sqrt(16)"));
            System.out.println("pow(2, 3) = " + calc("pow(2, 3)"));
            System.out.println("abs(-5) = " + calc("abs(-5)"));
            System.out.println("round(3.6) = " + calc("round(3.6)"));
            System.out.println("min(5, 3, 8) = " + calc("min(5, 3, 8)"));
            System.out.println("max(5, 3, 8) = " + calc("max(5, 3, 8)"));
            System.out.println();
            
            // Trigonometric functions
            System.out.println("Trigonometric Functions:");
            System.out.println("sin(0) = " + calc("sin(0)"));
            System.out.println("cos(0) = " + calc("cos(0)"));
            System.out.println("sin(PI/2) = " + calc("sin(PI/2)"));
            System.out.println();
            
            // Using arguments
            System.out.println("Using Arguments:");
            System.out.println("$arg0 + $arg1 (5, 3) = " + calc("$arg0 + $arg1", 5, 3));
            System.out.println("$arg0 * $arg1 (4, 6) = " + calc("$arg0 * $arg1", 4, 6));
            System.out.println("sqrt($arg0) + $arg1 (16, 5) = " + calc("sqrt($arg0) + $arg1", 16, 5));
            
            // Using named arguments
            System.out.println("Using Named Arguments:");
            System.out.println("$num1 + $num2 (5, 3) = " + calc("$num1 + $num2", 5, 3));
            System.out.println("$quantity * $price (4, 6) = " + calc("$quantity * $price", 4, 6));
            System.out.println("sqrt($base) + $offset (16, 5) = " + calc("sqrt($base) + $offset", 16, 5));
            System.out.println();
            
            // Complex formulas
            System.out.println("Complex Formulas:");
            System.out.println("(2 + 3) * 4 = " + calc("(2 + 3) * 4"));
            System.out.println("2 + (3 * 4) = " + calc("2 + (3 * 4)"));
            System.out.println("sqrt(16) + pow(2, 3) = " + calc("sqrt(16) + pow(2, 3)"));
            System.out.println();
            
            // Error handling example
            System.out.println("Error Handling:");
            try {
                System.out.println("Trying invalid formula: 2 +");
                calc("2 +");
            } catch (IllegalArgumentException e) {
                System.out.println("Error caught: " + e.getMessage());
            }
            
            try {
                System.out.println("Trying division by zero: 1 / 0");
                calc("1 / 0");
            } catch (IllegalArgumentException e) {
                System.out.println("Error caught: " + e.getMessage());
            }
            System.out.println();
            
            System.out.println("=== Examples completed ===");
            
        } catch (Exception e) {
            System.err.println("Error running examples: " + e.getMessage());
            e.printStackTrace();
        }
    }
} 