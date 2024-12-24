# C# Object-Oriented Programming Guide

## Classes
A class is a blueprint for creating objects that encapsulate data and behavior. Classes are the fundamental building blocks of object-oriented programming in C#.

### Key Characteristics
- Classes support encapsulation through access modifiers (public, private, protected, internal)
- They can contain fields, properties, methods, and events
- A class can be declared as partial, allowing its definition to span multiple files

```csharp
public class Student
{
    private string name;  // Field
    public int Age { get; set; }  // Property
    
    public void Study()  // Method
    {
        Console.WriteLine($"{name} is studying");
    }
}
```

## Inheritance
Inheritance enables a class to include and extend the functionality of another class. C# supports single inheritance, meaning a class can inherit from only one base class.

### Important Points
- The `sealed` keyword prevents a class from being inherited
- Protected members are accessible in derived classes
- All classes implicitly inherit from `Object`
- Constructor chaining uses the `base` keyword

```csharp
public class Person
{
    protected string name;
    public Person(string name)
    {
        this.name = name;
    }
}

public class Teacher : Person
{
    private string subject;
    public Teacher(string name, string subject) : base(name)
    {
        this.subject = subject;
    }
}
```

## Constructors
Constructors are special methods that initialize new instances of a class. They can be overloaded to provide different ways to create objects.

### Types of Constructors
1. Default Constructor (parameterless)
2. Parameterized Constructor
3. Copy Constructor
4. Static Constructor (runs once when class is first used)

```csharp
public class Course
{
    private string courseName;
    private int credits;

    // Default constructor
    public Course()
    {
        courseName = "Undefined";
        credits = 0;
    }

    // Parameterized constructor
    public Course(string name, int credits)
    {
        this.courseName = name;
        this.credits = credits;
    }

    // Copy constructor
    public Course(Course other)
    {
        this.courseName = other.courseName;
        this.credits = other.credits;
    }

    // Static constructor
    static Course()
    {
        // Runs once when class is first used
    }
}
```

## Virtual Functions
Virtual functions enable method overriding in derived classes, allowing for runtime polymorphism.

### Key Points
- Base class methods must be marked with `virtual`
- Derived class methods must use `override`
- `sealed` can prevent further overriding
- Abstract methods are implicitly virtual

```csharp
public class Shape
{
    public virtual double CalculateArea()
    {
        return 0;
    }
}

public class Circle : Shape
{
    private double radius;

    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}
```

## Interfaces
Interfaces define a contract that implementing classes must fulfill. They can contain method signatures, properties, events, and indexers.

### Important Features
- A class can implement multiple interfaces
- Interface members are implicitly public
- Interfaces can inherit from other interfaces
- Starting with C# 8.0, interfaces can have default implementations

```csharp
public interface ITeachable
{
    void Teach();
    int HoursPerWeek { get; set; }
}

public interface IEvaluable
{
    void Grade();
}

public class Professor : ITeachable, IEvaluable
{
    public int HoursPerWeek { get; set; }

    public void Teach()
    {
        Console.WriteLine("Teaching a class");
    }

    public void Grade()
    {
        Console.WriteLine("Grading assignments");
    }
}
```

## Static Functions
Static functions belong to the class itself rather than instances of the class. They are shared across all instances.

### Characteristics
- Called using the class name, not an instance
- Can only access other static members directly
- Often used for utility functions
- Cannot access instance members without an object reference

```csharp
public class MathOperations
{
    public static double CalculateAverage(int[] numbers)
    {
        return numbers.Average();
    }

    public static readonly double PI = 3.14159;
}

// Usage:
double avg = MathOperations.CalculateAverage(new int[] {1, 2, 3});
```

## Structs
Structs are value types that can encapsulate data and related functionality. They are useful for small, data-focused types.

### Key Differences from Classes
- Value type semantics (copied when assigned)
- Cannot inherit from other structs
- Can implement interfaces
- Implicit parameterless constructor
- Cannot have a parameterless constructor
- Fields must be initialized in constructors

```csharp
public struct Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double DistanceFromOrigin()
    {
        return Math.Sqrt(X * X + Y * Y);
    }
}

// Usage:
Point p1 = new Point(3, 4);
Point p2 = p1;  // Creates a copy
```

## Best Practices
1. Choose classes when you need inheritance or reference type semantics
2. Use structs for small, immutable value types
3. Keep interfaces focused and cohesive
4. Override `ToString()` for meaningful string representations
5. Consider implementing IDisposable for resource cleanup
6. Use virtual methods judiciously, as they have performance implications
7. Initialize all fields in constructors
8. Make fields private and expose them through properties when needed