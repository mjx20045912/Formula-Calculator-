# Formula Calculator

A intelligent Calculator for different formulas with support for multiple programming languages.

## Projects

This repository contains formula calculator implementations in different languages:

- **Node.js** - JavaScript/TypeScript implementation with comprehensive testing
- **Java** - Java implementation with Maven build system and JUnit 5 testing
- **Python** - Python implementation
- **C#** - C# implementation  
- **UI** - User interface components

## Node.js Formula Calculator

The Node.js implementation provides a robust formula calculator with the following features:

- Mathematical formula evaluation
- Support for basic arithmetic operations
- Mathematical functions and constants
- Named and indexed arguments
- Comprehensive test suite
- GitHub Actions CI/CD pipeline

### Quick Start

```bash
cd nodejs
npm install
npm test
```

### Usage

```javascript
import { calc } from './nodejs/index.js';

// Basic arithmetic
calc('2 + 3') // 5

// Using arguments
calc('$arg0 + $arg1', 5, 3) // 8
calc('$quantity * $price', 4, 6) // 24

// Mathematical functions
calc('sqrt(16)') // 4
calc('sin(PI/2)') // 1
```

## Java Formula Calculator

The Java implementation provides a robust formula calculator with the following features:

- Mathematical formula evaluation using Java ScriptEngine
- Support for basic arithmetic operations
- Mathematical functions and constants
- Named and indexed arguments
- Comprehensive test suite using JUnit 5
- Maven build system
- GitHub Actions CI/CD pipeline

### Quick Start

```bash
cd java
mvn clean install
mvn test
```

### Usage

```java
import com.formulacalculator.FormulaCalculator;

// Basic arithmetic
double result = FormulaCalculator.calc("2 + 3"); // 5.0

// Using arguments
double result1 = FormulaCalculator.calc("$arg0 + $arg1", 5, 3); // 8.0
double result2 = FormulaCalculator.calc("$quantity * $price", 4, 6); // 24.0

// Mathematical functions
double result3 = FormulaCalculator.calc("sqrt(16)"); // 4.0
double result4 = FormulaCalculator.calc("sin(PI/2)"); // 1.0
```

## CI/CD Pipeline

This project uses GitHub Actions for continuous integration and deployment:

### Workflows

1. **`nodejs-test.yml`** - Focused testing for Node.js project
   - Runs on Node.js 18.x, 20.x, 21.x
   - Tests only when Node.js files change
   - Includes test coverage reporting

2. **`java-test.yml`** - Focused testing for Java project
   - Runs on Java 17, 20, 21
   - Tests only when Java files change
   - Includes Maven build and JAR testing

3. **`ci.yml`** - Comprehensive CI/CD pipeline
   - Multi-platform testing (Ubuntu, Windows, macOS)
   - Security audits
   - Code formatting checks
   - Multiple Node.js versions

4. **`test.yml`** - Simple test workflow
   - Basic testing setup
   - Runs on push and pull requests

### Features

- ✅ Automated testing on multiple Node.js and Java versions
- ✅ Cross-platform compatibility testing
- ✅ Security vulnerability scanning
- ✅ Code formatting validation
- ✅ Test coverage reporting
- ✅ Path-based triggers (only runs when relevant files change)
- ✅ Maven build system for Java projects
- ✅ JUnit 5 testing framework

### Status Badge

Add these badges to your README to show the CI status:

```markdown
![Node.js Tests](https://github.com/{username}/Formula-Calculator-/workflows/Node.js%20Formula%20Calculator%20Tests/badge.svg)
![Java Tests](https://github.com/{username}/Formula-Calculator-/workflows/Java%20Formula%20Calculator%20Tests/badge.svg)
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests for new functionality
5. Ensure all tests pass
6. Submit a pull request

## License

MIT License
