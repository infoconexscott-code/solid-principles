# Liskov Substitution Principle

Subtypes must be substitutable for their base types without altering correctness.

When a subtype violates expectations set by its base, consumers are forced to perform type checks or face runtime errors. LSP
promotes reliable polymorphism by ensuring derived classes honor the contracts of their parents.

Formulated by [Barbara Liskov](https://en.wikipedia.org/wiki/Barbara_Liskov) and [Jeannette Wing](https://en.wikipedia.org/wiki/Jeannette_Wing).

## Violation

```csharp
public class Bird
{
    public virtual void Fly() { }
}

public class Ostrich : Bird
{
    public override void Fly() => throw new NotSupportedException("Ostriches can't fly");
}
```

Clients expecting a `Bird` that can `Fly` break when given an `Ostrich`.

## Fix

```csharp
public abstract class Bird { }

public interface IFlyingBird
{
    void Fly();
}

public class Sparrow : Bird, IFlyingBird
{
    public void Fly() { /* flying */ }
}

public class Ostrich : Bird { }
```

Now only birds that can truly fly implement `IFlyingBird`, preserving substitutability.

## Benefits

- **Reliable polymorphism** – callers using the base type won't encounter unexpected exceptions.
- **Clearer contracts** – base types specify exactly what behaviors are guaranteed.
- **Easier refactoring** – subclasses can change internally as long as they keep promises made by the base.

[Back to overview](README.md)
