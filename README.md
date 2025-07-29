# Formula Calculator

A intelligent Calculator for different formulas with support for multiple programming languages.

## Projects

This repository contains formula calculator implementations in different languages:

- **Node.js** - JavaScript/TypeScript implementation with comprehensive testing
- **Python** - Python implementation
- **Java** - Java implementation  
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

## CI/CD Pipeline

This project uses GitHub Actions for continuous integration and deployment:

### Workflows

1. **`nodejs-test.yml`** - Focused testing for Node.js project
   - Runs on Node.js 18.x, 20.x, 21.x
   - Tests only when Node.js files change
   - Includes test coverage reporting

2. **`ci.yml`** - Comprehensive CI/CD pipeline
   - Multi-platform testing (Ubuntu, Windows, macOS)
   - Security audits
   - Code formatting checks
   - Multiple Node.js versions

3. **`test.yml`** - Simple test workflow
   - Basic testing setup
   - Runs on push and pull requests

### Features

- ✅ Automated testing on multiple Node.js versions
- ✅ Cross-platform compatibility testing
- ✅ Security vulnerability scanning
- ✅ Code formatting validation
- ✅ Test coverage reporting
- ✅ Path-based triggers (only runs when relevant files change)

### Status Badge

Add this badge to your README to show the CI status:

```markdown
![Node.js Tests](https://github.com/{username}/Formula-Calculator-/workflows/Node.js%20Formula%20Calculator%20Tests/badge.svg)
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
