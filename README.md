# WinFormsDemoPOCs

A collection of WinForms proof-of-concept (POC) projects demonstrating design patterns, architectural concepts, and modern .NET practices.

Each folder in this repository represents an isolated POC focused on a specific concept.

---

## 📁 Available POCs

### 🔁 CallbackPOC
Demonstrates the Callback Pattern using delegates (`Action`, `Func`) in a WinForms application.

#### Concepts Covered:
- Callback pattern implementation
- Async service execution
- UI thread marshaling (BeginInvoke)
- Spinner/loading animation using Timer
- JSON API integration using HttpClient
- Execution time measurement (Stopwatch)
- Basic service abstraction (IUserService)

#### Features:
- Loading animation during API call
- Real-time status updates
- JSON response display
- Record count display
- Execution time summary

---

## 🧠 Architecture Overview

Each POC follows a simple layered structure:
