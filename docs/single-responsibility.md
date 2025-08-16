# Single Responsibility Principle

A class should have only one reason to change.

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

[Back to overview](README.md)
