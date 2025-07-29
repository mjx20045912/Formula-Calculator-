using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace FormulaCalculator
{
    /// <summary>
    /// Formula Calculator Module
    /// 
    /// This module provides a function to calculate mathematical formulas
    /// with support for basic arithmetic operations and common mathematical functions.
    /// The arguments should be marked start with $, like calc("$arg0 + $arg1", 5, 3) = 8
    /// </summary>
    public static class FormulaCalculator
    {
        /// <summary>
        /// Calculates the result of a mathematical formula
        /// </summary>
        /// <param name="formula">The mathematical formula to evaluate</param>
        /// <param name="args">Additional arguments that can be used in the formula</param>
        /// <returns>The calculated result</returns>
        /// <exception cref="ArgumentException">If the formula is invalid, empty, or cannot be evaluated</exception>
        public static double Calc(string formula, params object[] args)
        {
            if (formula == null)
                throw new ArgumentException("Formula cannot be null");
            if (string.IsNullOrWhiteSpace(formula))
                throw new ArgumentException("Formula cannot be empty");
            try
            {
                // 1. Replace exponentiation (a ^ b or a ** b) with Math.Pow(a, b)
                string processedFormula = formula;
                // Repeat until no ^ or ** left
                string prevExp;
                do {
                    prevExp = processedFormula;
                    processedFormula = Regex.Replace(processedFormula, @"([a-zA-Z0-9_$.()]+)\s*(\^|\*\*)\s*([a-zA-Z0-9_$.()]+)", m =>
                        $"Math.Pow({m.Groups[1].Value}, {m.Groups[3].Value})");
                } while (processedFormula != prevExp && (processedFormula.Contains("^") || processedFormula.Contains("**")));

                // 2. Replace only standalone pi and e (word boundaries)
                processedFormula = Regex.Replace(processedFormula, @"\bpi\b", Math.PI.ToString(CultureInfo.InvariantCulture), RegexOptions.IgnoreCase);
                processedFormula = Regex.Replace(processedFormula, @"\be\b", Math.E.ToString(CultureInfo.InvariantCulture), RegexOptions.IgnoreCase);

                // 3. Replace arguments ($arg0, $name, etc.)
                var namedArgPattern = new Regex(@"\$[a-zA-Z_][a-zA-Z0-9_]*");
                var matches = namedArgPattern.Matches(processedFormula);
                int argIndex = 0;
                foreach (Match match in matches)
                {
                    if (argIndex < args.Length)
                    {
                        string namedArg = match.Value;
                        string replacement = Convert.ToString(args[argIndex], CultureInfo.InvariantCulture);
                        processedFormula = processedFormula.Replace(namedArg, replacement);
                        argIndex++;
                    }
                }

                // 4. Replace function names with Math. prefix for easier parsing
                string expression = processedFormula
                    .Replace("sqrt(", "Math.Sqrt(")
                    .Replace("pow(", "Math.Pow(")
                    .Replace("abs(", "Math.Abs(")
                    .Replace("ceil(", "Math.Ceiling(")
                    .Replace("floor(", "Math.Floor(")
                    .Replace("round(", "Math.Round(")
                    .Replace("sin(", "Math.Sin(")
                    .Replace("cos(", "Math.Cos(")
                    .Replace("tan(", "Math.Tan(")
                    .Replace("log(", "Math.Log(")
                    .Replace("exp(", "Math.Exp(")
                    .Replace("random()", "new Random().NextDouble()");

                // 5. Handle min/max functions with multiple arguments
                string prevMinMax;
                do
                {
                    prevMinMax = expression;
                    expression = HandleMinMaxFunctions(expression);
                } while (expression != prevMinMax);

                // 6. Recursively evaluate all Math.* functions
                string prev;
                do
                {
                    prev = expression;
                    expression = EvaluateMathFunctions(expression);
                } while (expression != prev);
                // Final sweep for any remaining Math.Min/Math.Max
                do
                {
                    prev = expression;
                    expression = EvaluateMathFunctions(expression);
                } while (expression != prev);

                // 7. Evaluate the final expression
                var dataTable = new System.Data.DataTable();
                var result = dataTable.Compute(expression, "");
                if (result is double doubleResult)
                {
                    if (double.IsFinite(doubleResult))
                        return doubleResult;
                    else
                        throw new ArgumentException("Formula evaluation resulted in an invalid number");
                }
                else if (result is int intResult)
                {
                    return intResult;
                }
                else if (result is decimal decimalResult)
                {
                    return Convert.ToDouble(decimalResult);
                }
                else
                {
                    throw new ArgumentException("Formula evaluation did not return a number");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Invalid formula: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles min/max functions with multiple arguments by converting them to nested calls
        /// </summary>
        /// <param name="expression">The expression to process</param>
        /// <returns>The processed expression</returns>
        private static string HandleMinMaxFunctions(string expression)
        {
            // Flatten min/max with more than two arguments into nested calls
            // min(5, 3, 8) => Math.Min(Math.Min(5, 3), 8)
            var minPattern = new Regex(@"min\(([^)]+)\)");
            expression = minPattern.Replace(expression, match =>
            {
                var args = match.Groups[1].Value.Split(',').Select(s => s.Trim()).ToList();
                if (args.Count == 2) return $"Math.Min({args[0]}, {args[1]})";
                if (args.Count > 2)
                {
                    string nested = $"Math.Min({args[0]}, {args[1]})";
                    for (int i = 2; i < args.Count; i++)
                        nested = $"Math.Min({nested}, {args[i]})";
                    return nested;
                }
                return match.Value;
            });
            var maxPattern = new Regex(@"max\(([^)]+)\)");
            expression = maxPattern.Replace(expression, match =>
            {
                var args = match.Groups[1].Value.Split(',').Select(s => s.Trim()).ToList();
                if (args.Count == 2) return $"Math.Max({args[0]}, {args[1]})";
                if (args.Count > 2)
                {
                    string nested = $"Math.Max({args[0]}, {args[1]})";
                    for (int i = 2; i < args.Count; i++)
                        nested = $"Math.Max({nested}, {args[i]})";
                    return nested;
                }
                return match.Value;
            });
            return expression;
        }

        /// <summary>
        /// Evaluates mathematical functions by replacing them with their actual values
        /// </summary>
        /// <param name="expression">The expression to process</param>
        /// <returns>The processed expression</returns>
        private static string EvaluateMathFunctions(string expression)
        {
            // Evaluate sqrt
            var sqrtPattern = new Regex(@"Math\.Sqrt\(([^()]+)\)");
            expression = sqrtPattern.Replace(expression, match =>
            {
                var inner = match.Groups[1].Value;
                var val = Convert.ToDouble(new System.Data.DataTable().Compute(inner, ""));
                return Math.Sqrt(val).ToString(CultureInfo.InvariantCulture);
            });
            // Evaluate pow
            var powPattern = new Regex(@"Math\.Pow\(([^,]+),([^\)]+)\)");
            expression = powPattern.Replace(expression, match =>
            {
                var a = Convert.ToDouble(new System.Data.DataTable().Compute(match.Groups[1].Value, ""));
                var b = Convert.ToDouble(new System.Data.DataTable().Compute(match.Groups[2].Value, ""));
                return Math.Pow(a, b).ToString(CultureInfo.InvariantCulture);
            });
            // Evaluate abs
            var absPattern = new Regex(@"Math\.Abs\(([^()]+)\)");
            expression = absPattern.Replace(expression, match =>
            {
                var inner = match.Groups[1].Value;
                var val = Convert.ToDouble(new System.Data.DataTable().Compute(inner, ""));
                return Math.Abs(val).ToString(CultureInfo.InvariantCulture);
            });
            // Evaluate ceil
            var ceilPattern = new Regex(@"Math\.Ceiling\(([^()]+)\)");
            expression = ceilPattern.Replace(expression, match =>
            {
                var inner = match.Groups[1].Value;
                var val = Convert.ToDouble(new System.Data.DataTable().Compute(inner, ""));
                return Math.Ceiling(val).ToString(CultureInfo.InvariantCulture);
            });
            // Evaluate floor
            var floorPattern = new Regex(@"Math\.Floor\(([^()]+)\)");
            expression = floorPattern.Replace(expression, match =>
            {
                var inner = match.Groups[1].Value;
                var val = Convert.ToDouble(new System.Data.DataTable().Compute(inner, ""));
                return Math.Floor(val).ToString(CultureInfo.InvariantCulture);
            });
            // Evaluate round
            var roundPattern = new Regex(@"Math\.Round\(([^()]+)\)");
            expression = roundPattern.Replace(expression, match =>
            {
                var inner = match.Groups[1].Value;
                var val = Convert.ToDouble(new System.Data.DataTable().Compute(inner, ""));
                return Math.Round(val).ToString(CultureInfo.InvariantCulture);
            });
            // Evaluate sin
            var sinPattern = new Regex(@"Math\.Sin\(([^()]+)\)");
            expression = sinPattern.Replace(expression, match =>
            {
                var inner = match.Groups[1].Value;
                var val = Convert.ToDouble(new System.Data.DataTable().Compute(inner, ""));
                return Math.Sin(val).ToString(CultureInfo.InvariantCulture);
            });
            // Evaluate cos
            var cosPattern = new Regex(@"Math\.Cos\(([^()]+)\)");
            expression = cosPattern.Replace(expression, match =>
            {
                var inner = match.Groups[1].Value;
                var val = Convert.ToDouble(new System.Data.DataTable().Compute(inner, ""));
                return Math.Cos(val).ToString(CultureInfo.InvariantCulture);
            });
            // Evaluate tan
            var tanPattern = new Regex(@"Math\.Tan\(([^()]+)\)");
            expression = tanPattern.Replace(expression, match =>
            {
                var inner = match.Groups[1].Value;
                var val = Convert.ToDouble(new System.Data.DataTable().Compute(inner, ""));
                return Math.Tan(val).ToString(CultureInfo.InvariantCulture);
            });
            // Evaluate log
            var logPattern = new Regex(@"Math\.Log\(([^()]+)\)");
            expression = logPattern.Replace(expression, match =>
            {
                var inner = match.Groups[1].Value;
                var val = Convert.ToDouble(new System.Data.DataTable().Compute(inner, ""));
                return Math.Log(val).ToString(CultureInfo.InvariantCulture);
            });
            // Evaluate exp
            var expPattern = new Regex(@"Math\.Exp\(([^()]+)\)");
            expression = expPattern.Replace(expression, match =>
            {
                var inner = match.Groups[1].Value;
                var val = Convert.ToDouble(new System.Data.DataTable().Compute(inner, ""));
                return Math.Exp(val).ToString(CultureInfo.InvariantCulture);
            });
            // Evaluate min
            var minPattern = new Regex(@"Math\.Min\(([^,]+),([^\)]+)\)");
            expression = minPattern.Replace(expression, match =>
            {
                var a = Convert.ToDouble(new System.Data.DataTable().Compute(match.Groups[1].Value, ""));
                var b = Convert.ToDouble(new System.Data.DataTable().Compute(match.Groups[2].Value, ""));
                return Math.Min(a, b).ToString(CultureInfo.InvariantCulture);
            });
            // Evaluate max
            var maxPattern = new Regex(@"Math\.Max\(([^,]+),([^\)]+)\)");
            expression = maxPattern.Replace(expression, match =>
            {
                var a = Convert.ToDouble(new System.Data.DataTable().Compute(match.Groups[1].Value, ""));
                var b = Convert.ToDouble(new System.Data.DataTable().Compute(match.Groups[2].Value, ""));
                return Math.Max(a, b).ToString(CultureInfo.InvariantCulture);
            });
            // Evaluate random
            var randomPattern = new Regex(@"new Random\(\)\.NextDouble\(\)");
            expression = randomPattern.Replace(expression, new Random().NextDouble().ToString(CultureInfo.InvariantCulture));
            return expression;
        }

        /// <summary>
        /// Example method for running examples
        /// </summary>
        /// <param name="args">Command line arguments</param>
        public static void RunExamples(string[] args)
        {
            Console.WriteLine("=== Formula Calculator Examples ===\n");

            try
            {
                // Basic arithmetic
                Console.WriteLine("Basic Arithmetic:");
                Console.WriteLine($"2 + 3 = {Calc("2 + 3")}");
                Console.WriteLine($"10 - 5 = {Calc("10 - 5")}");
                Console.WriteLine($"4 * 6 = {Calc("4 * 6")}");
                Console.WriteLine($"15 / 3 = {Calc("15 / 3")}");
                Console.WriteLine();

                // Exponentiation
                Console.WriteLine("Exponentiation:");
                Console.WriteLine($"2 ^ 3 = {Calc("2 ^ 3")}");
                Console.WriteLine($"3 ** 2 = {Calc("3 ** 2")}");
                Console.WriteLine();

                // Mathematical constants
                Console.WriteLine("Mathematical Constants:");
                Console.WriteLine($"PI = {Calc("PI")}");
                Console.WriteLine($"E = {Calc("E")}");
                Console.WriteLine();

                // Mathematical functions
                Console.WriteLine("Mathematical Functions:");
                Console.WriteLine($"sqrt(16) = {Calc("sqrt(16)")}");
                Console.WriteLine($"pow(2, 3) = {Calc("pow(2, 3)")}");
                Console.WriteLine($"abs(-5) = {Calc("abs(-5)")}");
                Console.WriteLine($"round(3.6) = {Calc("round(3.6)")}");
                Console.WriteLine($"min(5, 3, 8) = {Calc("min(5, 3, 8)")}");
                Console.WriteLine($"max(5, 3, 8) = {Calc("max(5, 3, 8)")}");
                Console.WriteLine();

                // Trigonometric functions
                Console.WriteLine("Trigonometric Functions:");
                Console.WriteLine($"sin(0) = {Calc("sin(0)")}");
                Console.WriteLine($"cos(0) = {Calc("cos(0)")}");
                Console.WriteLine($"sin(PI/2) = {Calc("sin(PI/2)")}");
                Console.WriteLine();

                // Using arguments
                Console.WriteLine("Using Arguments:");
                Console.WriteLine($"$arg0 + $arg1 (5, 3) = {Calc("$arg0 + $arg1", 5, 3)}");
                Console.WriteLine($"$arg0 * $arg1 (4, 6) = {Calc("$arg0 * $arg1", 4, 6)}");
                Console.WriteLine($"sqrt($arg0) + $arg1 (16, 5) = {Calc("sqrt($arg0) + $arg1", 16, 5)}");

                // Using named arguments
                Console.WriteLine("Using Named Arguments:");
                Console.WriteLine($"$num1 + $num2 (5, 3) = {Calc("$num1 + $num2", 5, 3)}");
                Console.WriteLine($"$quantity * $price (4, 6) = {Calc("$quantity * $price", 4, 6)}");
                Console.WriteLine($"sqrt($base) + $offset (16, 5) = {Calc("sqrt($base) + $offset", 16, 5)}");
                Console.WriteLine();

                // Complex formulas
                Console.WriteLine("Complex Formulas:");
                Console.WriteLine($"(2 + 3) * 4 = {Calc("(2 + 3) * 4")}");
                Console.WriteLine($"2 + (3 * 4) = {Calc("2 + (3 * 4)")}");
                Console.WriteLine($"sqrt(16) + pow(2, 3) = {Calc("sqrt(16) + pow(2, 3)")}");
                Console.WriteLine();

                // Error handling example
                Console.WriteLine("Error Handling:");
                try
                {
                    Console.WriteLine("Trying invalid formula: 2 +");
                    Calc("2 +");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error caught: {e.Message}");
                }

                try
                {
                    Console.WriteLine("Trying division by zero: 1 / 0");
                    Calc("1 / 0");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error caught: {e.Message}");
                }
                Console.WriteLine();

                Console.WriteLine("=== Examples completed ===");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error running examples: {e.Message}");
                Console.WriteLine(e.StackTrace);
            }
        }
    }
} 