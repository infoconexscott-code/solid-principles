# Single Responsibility Principle

A class should have only one reason to change.

Keeping a single focus makes classes easier to read, test, and modify. When responsibilities
are mixed together, even a small requirement change can force unrelated edits and lead to
fragile code.

Introduced by [Robert C. Martin](https://en.wikipedia.org/wiki/Robert_C._Martin) (Uncle Bob).

## Violation

```csharp
public class Report
{
    public string Generate()
    {
        // produce report
        return "report";
    }

    public void SaveToFile(string path)
    {
        File.WriteAllText(path, Generate());
    }
}
```

`Report` both creates content and handles persistence. Changes to either concern force edits to the same class.

## Fix

```csharp
public class Report
{
    public string Generate()
    {
        // produce report
        return "report";
    }
}

public class ReportSaver
{
    public void SaveToFile(Report report, string path)
    {
        File.WriteAllText(path, report.Generate());
    }
}
```

Splitting responsibilities isolates reasons to change: `Report` generates data, while `ReportSaver` persists it.

## Benefits

- **Simpler maintenance** – adjustments to how a report is created or saved do not influence each other.
- **Easier testing** – each class can be exercised in isolation with focused unit tests.
- **Greater reuse** – other components can consume `Report` without bringing in file system concerns.

[Back to overview](README.md)
