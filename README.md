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

## SOLID Principles Overview

SOLID is an acronym coined by [Robert C. Martin](https://en.wikipedia.org/wiki/Robert_C._Martin) (Uncle Bob) for five design principles intended to make object-oriented designs more understandable, flexible, and maintainable:

- **S**ingle Responsibility Principle
- **O**pen/Closed Principle
- **L**iskov Substitution Principle
- **I**nterface Segregation Principle
- **D**ependency Inversion Principle

The acronym and the Single Responsibility, Interface Segregation, and Dependency Inversion principles were introduced by [Robert C. Martin](https://en.wikipedia.org/wiki/Robert_C._Martin) (Uncle Bob). The Open/Closed Principle was first described by [Bertrand Meyer](https://en.wikipedia.org/wiki/Bertrand_Meyer), and the Liskov Substitution Principle by [Barbara Liskov](https://en.wikipedia.org/wiki/Barbara_Liskov) and [Jeannette Wing](https://en.wikipedia.org/wiki/Jeannette_Wing).

For detailed explanations and code examples, see the [documentation](docs/README.md).
