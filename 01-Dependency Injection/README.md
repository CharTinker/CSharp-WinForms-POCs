# 📌 01 - Dependency Injection

## Overview

This Proof of Concept (POC) demonstrates how to implement **Dependency Injection (DI)** in a Windows Forms application using **Microsoft.Extensions.DependencyInjection**.

The application retrieves user data asynchronously through a service abstraction while keeping the user interface responsive using callback-based programming.

Instead of creating dependencies directly within the form, services are registered once at application startup and injected into the form through constructor injection.

---

# 🎯 Concepts Demonstrated

* Dependency Injection (DI)
* Inversion of Control (IoC)
* Constructor Injection
* Interface-based Programming
* Callback Pattern
* Delegates (`Action`)
* Asynchronous Service Execution
* Thread-safe UI Updates (`BeginInvoke`)
* Timer-based Loading Animation
* JSON Deserialization (`System.Text.Json`)
* Exception Handling
* Performance Measurement (`Stopwatch`)
* Separation of Concerns

---

# 🏗 Architecture

```text
                   User Clicks "Load Data"
                              │
                              ▼
                    DependencyIn (WinForms UI)
                              │
                              ▼
                      IUserService Interface
                              │
                              ▼
                     UserService Implementation
                              │
                              ▼
                        REST API (HttpClient)
                              │
                              ▼
                         JSON Response
                              │
                              ▼
                   Callback → Update UI Thread
```

---

# 📂 Project Structure

```text
01-DependencyInjection
│
├── Models
│   └── User.cs
│
├── Interfaces
│   └── IUserService.cs
│
├── Services
│   └── UserService.cs
│
├── Program.cs
├── DependencyIn.cs
├── DependencyIn.Designer.cs
└── README.md
```

---

# 🔄 Execution Flow

```text
Application Starts
        │
        ▼
Register Services
        │
        ▼
Build Service Provider
        │
        ▼
Create DependencyIn Form
        │
        ▼
Constructor Injection
        │
        ▼
User Clicks "Load Data"
        │
        ▼
LoadUsers()
        │
        ▼
Background HTTP Request
        │
        ▼
Success / Error Callback
        │
        ▼
BeginInvoke()
        │
        ▼
Update WinForms Controls
```

---

# 🛠 Technologies Used

* C#
* .NET
* Windows Forms (WinForms)
* Microsoft.Extensions.DependencyInjection
* HttpClient
* System.Text.Json
* Delegates
* Timers
* Stopwatch

---

# 💡 Key Learning Points

### Dependency Injection

* Register services once during application startup.
* Depend on interfaces rather than concrete implementations.
* Improve maintainability and testability.

### Callback Pattern

The service performs asynchronous work and invokes callback delegates when the operation completes instead of blocking the UI thread.

### Thread-safe UI Programming

Background threads cannot update WinForms controls directly.

The project safely marshals execution back to the UI thread using `BeginInvoke()`.

### Responsive User Experience

The application provides:

* Animated loading indicator
* Responsive UI
* Progress updates
* Execution time measurement
* Graceful error handling

---

# 📚 Skills Demonstrated

* C#
* WinForms
* Dependency Injection
* Constructor Injection
* Interfaces
* SOLID Principles
* Callback Pattern
* Delegates
* Lambda Expressions
* JSON Processing
* Thread-safe Programming
* Exception Handling
* Clean Architecture

---

# 🎓 Interview Topics

This project is useful for discussing:

* What is Dependency Injection?
* Why use interfaces?
* Singleton vs Transient lifetimes
* Constructor Injection
* Callback Pattern
* Delegates (`Action`)
* BeginInvoke vs Invoke
* Thread-safe WinForms programming
* Separation of Concerns
* SOLID Principles

---

# 🚀 Possible Enhancements

* Async/Await implementation
* CancellationToken support
* Progress reporting
* Logging with `ILogger`
* Unit tests with mocked services
* Configuration using `appsettings.json`
* Generic service abstraction
* Repository pattern integration

---

# 📖 Related Concepts

This POC pairs well with future examples covering:

* Events & Delegates
* Async/Await
* Multithreading
* BackgroundWorker
* Repository Pattern
* Factory Pattern
* Observer Pattern
* MVP Architecture

---

## License

This project is part of the **WinFormsDemoPOCs** repository and is intended for learning, interview preparation, and demonstrating modern C# desktop application development practices.
