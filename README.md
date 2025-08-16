# Solid Principles Playground

This solution contains three .NET 8 projects used to explore the SOLID principles.
At this stage, the code intentionally includes multiple violations of these principles so that it can be refactored later.

## Projects

Projects are organized into two top-level folders:

- `src/`
  - **SolidConsole** – Console application that generates a sample report.
  - **SolidLib** – Class library with a `ReportGenerator` that mixes responsibilities, uses conditionals, and depends on concrete implementations.
- `test/`
  - **SolidTests** – MSTest project with basic tests for the console app and the library.

## Goal

The starting point violates several SOLID principles. The intention is to refactor this code in the future to adhere to SOLID best practices.
