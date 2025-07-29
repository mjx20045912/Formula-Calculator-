#!/bin/bash

# Simple build script for Java Formula Calculator
# This script compiles and runs the Java project without Maven

echo "Building Java Formula Calculator..."

# Create target directory
mkdir -p target/classes
mkdir -p target/test-classes

# Compile main classes
echo "Compiling main classes..."
javac -d target/classes -cp ".:lib/*" src/main/java/com/formulacalculator/*.java

if [ $? -eq 0 ]; then
    echo "✅ Main classes compiled successfully"
else
    echo "❌ Compilation failed"
    exit 1
fi

# Compile test classes (if JUnit is available)
if [ -f "lib/junit-jupiter-api-5.9.2.jar" ]; then
    echo "Compiling test classes..."
    javac -d target/test-classes -cp "target/classes:lib/*" src/test/java/com/formulacalculator/*.java
    
    if [ $? -eq 0 ]; then
        echo "✅ Test classes compiled successfully"
    else
        echo "⚠️  Test compilation failed (JUnit not available)"
    fi
else
    echo "⚠️  JUnit not found, skipping test compilation"
fi

# Create JAR file
echo "Creating JAR file..."
jar cf target/formula-calculator-1.0.0.jar -C target/classes .

if [ $? -eq 0 ]; then
    echo "✅ JAR file created successfully"
else
    echo "❌ JAR creation failed"
    exit 1
fi

echo "Build completed successfully!"
echo ""
echo "To run the example:"
echo "java -cp target/classes com.formulacalculator.FormulaCalculator"
echo ""
echo "To run tests (if JUnit is available):"
echo "java -cp target/classes:target/test-classes:lib/* org.junit.platform.console.ConsoleLauncher --class-path target/classes:target/test-classes --scan-class-path" 