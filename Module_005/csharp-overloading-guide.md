# C# Overloading: Functions, Operators, and Extensions

## Function Overloading

Function overloading allows multiple methods in the same class to have the same name but different parameter lists.

### Key Characteristics
- Methods must differ in:
  - Number of parameters
  - Type of parameters
  - Order of parameters

### Example
```csharp
public class Calculator 
{
    // Overloaded static methods
    public static int Add(int a, int b) 
    {
        return a + b;
    }

    public static double Add(double a, double b) 
    {
        return a + b;
    }

    public static int Add(int a, int b, int c) 
    {
        return a + b + c;
    }
}

// Usage examples
int sum1 = Calculator.Add(5, 3);           // Calls int version
double sum2 = Calculator.Add(5.5, 3.7);    // Calls double version
int sum3 = Calculator.Add(1, 2, 3);        // Calls three-parameter version
```

### Constraints
- Return type alone cannot differentiate overloaded methods
- Parameters must be distinctly different
- Prevents ambiguity in method calls

## Operator Overloading

Operator overloading enables defining custom behaviors for standard operators with user-defined types.

### Supported Operators
- Arithmetic: `+`, `-`, `*`, `/`
- Comparison: `==`, `!=`, `<`, `>`, `<=`, `>=`
- Logical: `true`, `false`
- Conversion operators

### Example
```csharp
public class Complex 
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    // Overloading + operator
    public static Complex operator +(Complex a, Complex b) 
    {
        return new Complex 
        {
            Real = a.Real + b.Real,
            Imaginary = a.Imaginary + b.Imaginary
        };
    }

    // Overloading == operator
    public static bool operator ==(Complex a, Complex b) 
    {
        return a.Real == b.Real && a.Imaginary == b.Imaginary;
    }

    // Always provide != when == is overloaded
    public static bool operator !=(Complex a, Complex b) 
    {
        return !(a == b);
    }
}
```

### Restrictions
- Cannot redefine precedence of operators
- Cannot create new operators
- Some operators must be overloaded in pairs

## Extension Methods

Extension methods allow adding methods to existing types without modifying their source code.

### Key Characteristics
- Defined in static classes
- First parameter uses `this` modifier
- Appear as instance methods
- Cannot override existing methods

### Example
```csharp
public static class StringExtensions 
{
    // Extension method for string type
    public static bool IsNumeric(this string value) 
    {
        return int.TryParse(value, out _);
    }

    // Extension method with additional parameters
    public static string Repeat(this string input, int count) 
    {
        return string.Concat(Enumerable.Repeat(input, count));
    }
}

// Usage
string text = "Hello";
bool isNumeric = text.IsNumeric();  // False
string repeated = text.Repeat(3);   // "HelloHelloHello"
```

### Relationship to Overloading
While not strictly function overloading, extension methods provide similar flexibility:
- Can add "methods" to existing types
- Support method signatures with different parameters
- Enhance type capabilities without inheritance

### Best Practices
- Use sparingly
- Keep extension methods focused
- Prefer when modification of original type is impractical

## Comparison of Techniques

| Feature           | Function Overloading | Operator Overloading | Extension Methods |
|------------------|---------------------|---------------------|------------------|
| Modifies Original Type | No | Yes | No |
| Requires Source Code Access | Yes | Yes | No |
| Performance Overhead | Minimal | Slight | Minimal |
| Use Case | Multiple Method Signatures | Custom Type Behaviors | Type Enhancement |

## Conclusion
C# provides powerful mechanisms for method and operator customization through overloading and extension methods, enabling more expressive and flexible type definitions.
