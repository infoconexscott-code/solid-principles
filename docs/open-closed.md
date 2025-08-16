# Open/Closed Principle

Software entities should be open for extension but closed for modification.

The idea is to design modules so that new behavior can be added by extending existing code, not by editing stable classes. This
reduces the chance of introducing bugs into battle-tested components.

Described by [Bertrand Meyer](https://en.wikipedia.org/wiki/Bertrand_Meyer).

## Violation

```csharp
public class AreaCalculator
{
    public double Area(object shape)
    {
        switch (shape)
        {
            case Rectangle r:
                return r.Width * r.Height;
            case Circle c:
                return Math.PI * c.Radius * c.Radius;
            default:
                throw new ArgumentException("Unknown shape");
        }
    }
}
```

Adding a new shape requires modifying `AreaCalculator`, risking regressions.

## Fix

```csharp
public interface IShape
{
    double Area();
}

public class Rectangle : IShape
{
    public double Width { get; }
    public double Height { get; }
    public double Area() => Width * Height;
}

public class Circle : IShape
{
    public double Radius { get; }
    public double Area() => Math.PI * Radius * Radius;
}

public class AreaCalculator
{
    public double TotalArea(IEnumerable<IShape> shapes) =>
        shapes.Sum(s => s.Area());
}
```

`AreaCalculator` no longer changes when new shapes are introduced; instead, shapes implement `IShape` and extend behavior.

## Benefits

- **Reduced regression risk** – tested classes stay untouched when new functionality is added.
- **Encourages plug-in designs** – features can be extended through inheritance or composition.
- **Enables parallel work** – developers can create new shapes independently without merge conflicts.

[Back to overview](README.md)
