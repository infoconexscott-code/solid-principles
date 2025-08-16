# Dependency Inversion Principle

High-level modules should not depend on low-level modules; both should depend on abstractions.

Depending on concrete implementations couples policy to detail. By flipping the dependency so both layers rely on an abstraction,
low-level concerns can change without affecting high-level logic.

Introduced by [Robert C. Martin](https://en.wikipedia.org/wiki/Robert_C._Martin) (Uncle Bob).

## Violation

```csharp
public class FileLogger
{
    public void Log(string message) =>
        File.AppendAllText("log.txt", message);
}

public class UserService
{
    private readonly FileLogger _logger = new();

    public void CreateUser(string name)
    {
        // create user
        _logger.Log($"User {name} created");
    }
}
```

`UserService` depends directly on `FileLogger`, making it hard to change logging mechanisms or test the class.

## Fix

```csharp
public interface ILogger
{
    void Log(string message);
}

public class FileLogger : ILogger
{
    public void Log(string message) =>
        File.AppendAllText("log.txt", message);
}

public class UserService
{
    private readonly ILogger _logger;

    public UserService(ILogger logger)
    {
        _logger = logger;
    }

    public void CreateUser(string name)
    {
        // create user
        _logger.Log($"User {name} created");
    }
}
```

`UserService` now relies on the `ILogger` abstraction, allowing different logging implementations to be injected.

## Benefits

- **Easier testing** – supply a fake or in-memory logger during unit tests.
- **Greater flexibility** – swap logging mechanisms without modifying high-level code.
- **Decoupled architecture** – high-level policies remain independent of low-level details.

[Back to overview](README.md)
