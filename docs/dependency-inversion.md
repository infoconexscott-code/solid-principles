# Dependency Inversion Principle

High-level modules should not depend on low-level modules; both should depend on abstractions.

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

[Back to overview](README.md)
