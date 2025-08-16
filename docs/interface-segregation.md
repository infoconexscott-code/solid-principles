# Interface Segregation Principle

Clients should not be forced to depend on methods they do not use.

Bulky interfaces encourage implementations to add empty methods or throw exceptions, making code harder to understand. Splitting
interfaces lets classes depend only on behavior that actually matters to them.

Introduced by [Robert C. Martin](https://en.wikipedia.org/wiki/Robert_C._Martin) (Uncle Bob).

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

## Benefits

- **Focused APIs** – consumers only see operations that are meaningful for them.
- **Fewer side effects** – classes aren't forced to provide meaningless or exception-throwing implementations.
- **Improved flexibility** – interfaces can evolve independently without breaking unrelated clients.

[Back to overview](README.md)
