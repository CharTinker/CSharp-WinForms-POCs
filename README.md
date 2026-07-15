# 🚀 CSharp-WinForms-POCs

A curated collection of **C# Windows Forms Proof-of-Concept (POC)** projects demonstrating modern programming concepts, software design patterns, architectural principles, and .NET best practices.

The purpose of this repository is to provide **small, focused, and easy-to-understand examples** that demonstrate one concept at a time while following clean coding practices.

Whether you're learning WinForms, preparing for technical interviews, or looking for reference implementations, this repository aims to provide practical, reusable examples.

---

# 🎯 Objectives

* Learn modern C# programming concepts
* Demonstrate clean desktop application architecture
* Explore common software design patterns
* Practice asynchronous and event-driven programming
* Showcase maintainable and testable WinForms applications
* Build a portfolio of reusable C# examples

---

# 📁 Repository Structure

```text
CSharp-WinForms-POCs
│
├── 01-DependencyInjection
├── 02-Events-And-Delegates
├── 04-Async-Await
├── 04-AsyncAwait
├── 05-BackgroundWorker
├── 06-MVP-Pattern
├── 07-Caching
├── 08-RepositoryPattern
└── README.md
```

Each folder is a standalone project that focuses on a single concept.

---

# 📚 Available POCs

| Folder                    | Description                                                                                                   | Concepts                                                          |
| ------------------------- | ------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------- |
| `01-DependencyInjection`  | Demonstrates dependency injection in a WinForms application using `Microsoft.Extensions.DependencyInjection`. | Constructor Injection, Interfaces, Service Lifetimes              |
| `02-Events-And-Delegates` | Demonstrates communication between objects using events and delegates.                                        | Events, Delegates, Event Handlers, Publisher/Subscriber           |
| `04-Async-Await`          | Demonstrates asynchronous operations while keeping the WinForms UI responsive.                                | `Task`, `async`, `await`, UI Thread                               |
| `04-AsyncAwait`           | Provides an additional async/await implementation or example.                                                 | Asynchronous Programming, Exception Handling, UI Updates          |
| `05-BackgroundWorker`     | Demonstrates background processing with progress and completion reporting.                                    | `BackgroundWorker`, Progress Reporting, Cancellation              |
| `06-MVP-Pattern`          | Separates user-interface code from presentation and business logic.                                           | MVP, Interfaces, Testability, Separation of Concerns              |
| `07-Caching`              | Demonstrates caching data to avoid repeated repository or API calls.                                          | Cache-Aside, Expiration, Thread Safety                            |
| `08-RepositoryPattern`    | Abstracts data access from the application’s business logic.                                                  | Repository Pattern, Interfaces, Dependency Injection, Testability |

---

# 💡 Concepts Covered

This repository will include examples covering:

* Dependency Injection (DI)
* Constructor Injection
* Interfaces & Abstraction
* SOLID Principles
* Delegates
* Events
* Callback Pattern
* Async Programming
* Thread-safe UI Programming
* Timers
* BackgroundWorker
* Multithreading
* JSON Serialization / Deserialization
* Design Patterns
* Repository Pattern
* MVP Architecture
* Error Handling
* Logging
* Configuration Management
* Unit Testing


---

# 🏗 Architecture Philosophy

Each project follows a simple layered architecture:

```text
Presentation Layer (WinForms UI)
            │
            ▼
Application Layer (Interfaces / Contracts)
            │
            ▼
Service Layer (Business Logic)
            │
            ▼
Infrastructure / External Resources
```

The goal is to demonstrate clean separation of concerns while keeping each project simple and easy to understand.

---

# 🎓 Intended Audience

This repository is intended for:

* C# developers
* .NET developers
* Students learning WinForms
* Developers preparing for technical interviews
* Anyone interested in desktop application architecture

---

# 🤝 Contributions

Suggestions for additional proof-of-concept projects are welcome.

Feel free to open an issue or submit a pull request if you would like to contribute.

---

# ⭐ Support

If you find this repository helpful, please consider giving it a **⭐ Star** on GitHub.

Happy Coding! 🚀
