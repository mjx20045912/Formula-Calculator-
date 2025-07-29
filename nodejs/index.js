/**
 * Formula Calculator Module
 * 
 * This module provides a function to calculate mathematical formulas
 * with support for basic arithmetic operations and common mathematical functions.
 * the arguments should be marked start with $, like calc('$arg0 + $arg1', 5, 3) = 8
 */

/**
 * Calculates the result of a mathematical formula
 * @param {string} formula - The mathematical formula to evaluate
 * @param {...any} args - Additional arguments that can be used in the formula
 * @returns {number} The calculated result
 * @throws {Error} If the formula is invalid or cannot be evaluated
 */
export function calc(formula, ...args) {
  if (typeof formula !== 'string') {
    throw new Error('Formula must be a string');
  }

  if (!formula.trim()) {
    throw new Error('Formula cannot be empty');
  }

  try {
    // Create a safe evaluation context
    const context = {
      Math: Math,
      PI: Math.PI,
      E: Math.E,
      abs: Math.abs,
      ceil: Math.ceil,
      floor: Math.floor,
      round: Math.round,
      max: Math.max,
      min: Math.min,
      pow: Math.pow,
      sqrt: Math.sqrt,
      sin: Math.sin,
      cos: Math.cos,
      tan: Math.tan,
      log: Math.log,
      exp: Math.exp,
      random: Math.random
    };

    // Replace common mathematical symbols with JavaScript equivalents
    let processedFormula = formula
      .replace(/\^/g, '**') // Replace ^ with ** for exponentiation
      .replace(/\bpi\b/gi, 'PI') // Replace pi with PI
      .replace(/\be\b/gi, 'E'); // Replace e with E

    // Handle all named arguments (both $arg0, $arg1, etc. and custom names)
    const allNamedArgMatches = processedFormula.match(/\$[a-zA-Z_][a-zA-Z0-9_]*/g);
    if (allNamedArgMatches) {
      const uniqueNamedArgs = [...new Set(allNamedArgMatches)];
      uniqueNamedArgs.forEach((namedArg, index) => {
        if (index < args.length) {
          const argPattern = new RegExp(`\\${namedArg}\\b`, 'g');
          processedFormula = processedFormula.replace(argPattern, args[index].toString());
        }
      });
    }

    // Create a function that evaluates the formula safely
    const evalFunction = new Function(...Object.keys(context), `return ${processedFormula}`);
    
    // Execute the function with the context values
    const result = evalFunction(...Object.values(context));
    
    // Validate the result
    if (typeof result !== 'number' || !isFinite(result)) {
      throw new Error('Formula evaluation resulted in an invalid number');
    }
    
    return result;
  } catch (error) {
    throw new Error(`Invalid formula: ${error.message}`);
  }
}

// Export as default for convenience
export default calc; 