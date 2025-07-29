# GitHub Actions Workflows

This directory contains GitHub Actions workflows for the Formula Calculator project.

## Workflow Files

### 1. `nodejs-test.yml` (Recommended)
- **Purpose**: Focused testing for the Node.js formula calculator
- **Triggers**: Push/PR to main/master with changes to `nodejs/` directory
- **Features**:
  - Tests on Node.js 18.x, 20.x, 21.x
  - Path-based triggers (only runs when relevant files change)
  - Test coverage reporting
  - Example execution

### 2. `ci.yml` (Comprehensive)
- **Purpose**: Full CI/CD pipeline with multiple checks
- **Triggers**: Push/PR to main/master/develop
- **Features**:
  - Multi-platform testing (Ubuntu, Windows, macOS)
  - Security audits
  - Code formatting checks
  - Multiple Node.js versions
  - Separate security job

### 3. `test.yml` (Simple)
- **Purpose**: Basic testing workflow
- **Triggers**: Push/PR to main/master
- **Features**:
  - Simple setup
  - Multiple Node.js versions
  - Basic test execution

### 4. `template.yml` (Template)
- **Purpose**: Template for other projects
- **Features**:
  - Automatically finds all `package.json` files
  - Runs tests for all Node.js projects
  - Security audits for all projects
  - Can be adapted for different project structures

## Usage

### For Node.js Project Only
Use `nodejs-test.yml` - it's optimized for the Node.js formula calculator and only runs when relevant files change.

### For Multiple Projects
Use `template.yml` - it will automatically find and test all projects with `package.json` files.

### For Comprehensive CI/CD
Use `ci.yml` - it includes security checks, formatting validation, and cross-platform testing.

## Configuration

### Node.js Versions
All workflows test against multiple Node.js versions:
- 18.x (LTS)
- 20.x (LTS)
- 21.x (Latest)

### Caching
Dependencies are cached using npm cache to speed up builds:
```yaml
cache: 'npm'
cache-dependency-path: nodejs/package.json
```

### Path Triggers
Some workflows use path-based triggers to only run when relevant files change:
```yaml
paths:
  - 'nodejs/**'
  - '.github/workflows/nodejs-test.yml'
```

## Adding New Workflows

1. Copy `template.yml` for a new project
2. Modify the paths and commands as needed
3. Update the README.md in the root directory
4. Test the workflow locally if possible

## Troubleshooting

### Common Issues

1. **Tests failing**: Check that all tests pass locally first
2. **Cache issues**: Clear cache by removing the cache key
3. **Path triggers not working**: Ensure the file paths are correct
4. **Security audit failures**: Review and fix vulnerabilities

### Local Testing

Test workflows locally using [act](https://github.com/nektos/act):
```bash
# Install act
brew install act

# Run a specific workflow
act -W .github/workflows/nodejs-test.yml
```

## Status Badges

Add these badges to your README:

```markdown
![Node.js Tests](https://github.com/{username}/Formula-Calculator-/workflows/Node.js%20Formula%20Calculator%20Tests/badge.svg)
![CI/CD Pipeline](https://github.com/{username}/Formula-Calculator-/workflows/CI%2FCD%20Pipeline/badge.svg)
```

Replace `{username}` with your GitHub username. 