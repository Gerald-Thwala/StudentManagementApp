# Student Management Application

A command-line application for managing student records, written in **C# (.NET 6)** with a focus on clean architecture, modularity, and best practices. The application supports adding, editing, deleting, and searching student data stored in JSON files.

## Features

- Add new students with mandatory fields like ID, name, age, and curriculum.
- Edit existing student details while retaining existing values if unchanged.
- Delete student records by ID with confirmation.
- Search for students based on criteria or list all students.
- Data stored as JSON in a structured directory for easy file management.

## Technologies Used

- **.NET 6** for application development.
- **Moq** for mocking dependencies during testing.
- **xUnit** for unit testing.
- **Dependency Injection** for managing services and repositories.

## Architecture Overview

The project follows the principles of **Clean Architecture**, ensuring separation of concerns:

1. **Core**: Contains domain models and core abstractions.
2. **Application**: Handles business logic and command handlers.
3. **Infrastructure**: Provides persistence (file-based storage) and other external services.
4. **Presentation**: The entry point (`Program.cs`) and command execution logic.

## File Structure

```plaintext
StudentManagementApp
├── Core
│   ├── Models
│   └── Interfaces
├── Application
│   ├── Commands
│   ├── Factories
│   └── Services
├── Infrastructure
│   └── Persistence
├── Program.cs
StudentManagementApp.Tests
├── Commands
├── Services
├── Repositories
└── ProgramTests.cs
```

# Getting Started with the Student Management Application

This guide will help you set up and run the **Student Management Application** on your local machine.

## Prerequisites

Before you begin, ensure you have the following installed:

1. **.NET SDK 6.0 or higher**
   - Download and install from [here](https://dotnet.microsoft.com/download).
2. A terminal or command-line interface (CLI) for running commands.

## Setup Instructions

### Step 1: Clone the Repository

Clone the project from the repository using the following command:
```bash
git clone https://github.com/Gerald-Thwala/StudentManagementApp.git
cd StudentManagementApp
```
### Step 2: Build the Project

To build the application, run:
```bash
dotnet build
```
This will compile the project and ensure all dependencies are resolved.

### Step 3: Run the Application

Run the application with the required action. Here are some examples:
```bash
dotnet run -- --action=add
```
# Usage

The **Student Management Application** provides a simple command-line interface (CLI) for managing student records. Below are detailed instructions for each supported action.

## Actions

### Add a New Student

To add a new student, run:
```bash
dotnet run -- --action=add
```

# Unit Tests

This project is designed with testability in mind, and a test project is already included. However, **unit tests have not yet been implemented**. Contributions to add unit tests are highly encouraged and welcome!

## Running Tests

Once unit tests are added, you can use the following command to run the test framework:

```bash
dotnet test
```






