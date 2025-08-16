# Liskov Substitution Principle

Subtypes must be substitutable for their base types without altering correctness.

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

[Back to overview](README.md)
