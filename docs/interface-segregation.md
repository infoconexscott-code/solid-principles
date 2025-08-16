# Interface Segregation Principle

Clients should not be forced to depend on methods they do not use.

## Violation

```csharp
public interface IWorker
{
    void Work();
    void Eat();
}

public class Robot : IWorker
{
    public void Work() { /* ... */ }
    public void Eat() => throw new NotImplementedException();
}
```

`Robot` must implement `Eat` even though it doesn't make sense.

## Fix

```csharp
public interface IWorkable
{
    void Work();
}

public interface IFeedable
{
    void Eat();
}

public class Human : IWorkable, IFeedable
{
    public void Work() { /* ... */ }
    public void Eat() { /* ... */ }
}

public class Robot : IWorkable
{
    public void Work() { /* ... */ }
}
```

Interfaces are split so implementations only depend on relevant members.

[Back to overview](README.md)
