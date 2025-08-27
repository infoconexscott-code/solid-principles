# SOLID Principles

This folder contains deep dives into each of the SOLID principles. The acronym was introduced by [Robert C. Martin](https://en.wikipedia.org/wiki/Robert_C._Martin) (Uncle Bob).

Applying these guidelines promotes loose coupling and clear separation of concerns, resulting in codebases that are easier to
extend and maintain over time.

Each document includes:

- A brief description of the principle.
- A C# example that **violates** the principle.
- A refactored example that **fixes** the violation with an explanation.

Example implementations for each principle live in [`src/SolidLib/BadExamples`](../src/SolidLib/BadExamples).

For details about current test coverage, see the [state of testability](../state-of-testability.md).

## Guides

- [Single Responsibility Principle](single-responsibility.md)
- [Open/Closed Principle](open-closed.md)
- [Liskov Substitution Principle](liskov-substitution.md)
- [Interface Segregation Principle](interface-segregation.md)
- [Dependency Inversion Principle](dependency-inversion.md)

[Back to project README](../README.md)
