# Student Task & Study Planner

A basic C# Windows Forms desktop application for managing academic tasks and study activities.

## Project Overview

The **Student Task & Study Planner** helps students organize assignments, quizzes, projects, and study activities in one simple application.

The project uses a **3-layer architecture**:

1. **Presentation Layer** — Windows Forms GUI and user interaction.
2. **Business Logic Layer** — task operations and algorithms.
3. **Data Layer** — JSON file storage.

The project is intentionally kept simple so that the architecture and algorithms are easy to understand and demonstrate.

## Objectives

- Manage academic tasks in one application.
- Add, view, search, sort, complete, and delete tasks.
- Track total, pending, and completed tasks.
- Maintain a simple study schedule.
- Demonstrate Linear Search and Bubble Sort.
- Apply 3-layer architecture in a C# desktop project.

## Technologies Used

- **Language:** C#
- **Framework:** .NET 10
- **GUI:** Windows Forms
- **IDE:** Visual Studio Code
- **Storage:** JSON
- **Version Control:** Git / GitHub

## Main Features

### Dashboard
- Total task count
- Pending task count
- Completed task count
- Completion percentage
- Recent task list

### Task Management
- Add new task
- View tasks
- Search tasks
- Sort tasks by due date
- Mark task as completed
- Delete task
- Task priority: High, Medium, Low
- Task status: Pending, Completed

### Study Schedule
Provides a simple interface for organizing study-related activities.

## Architecture

```text
                 Student Task & Study Planner
                            |
                +-----------+-----------+
                |                       |
        Presentation Layer       User Interface
                |
                v
        Business Logic Layer
           TaskManager
                |
                v
             Data Layer
         TaskRepository
                |
                v
        DataFiles/tasks.json
```

### Layer Responsibilities

| Layer | Responsibility |
|---|---|
| Presentation | Forms, buttons, input, tables, and user interaction |
| Business Logic | Add, complete, delete, search, and sort operations |
| Data | Load and save task data |
| Models | Task data structure |

## Algorithms

### 1. Linear Search

Linear Search is used to search for a task by title.

The algorithm checks tasks one by one until a matching task is found.

**Time Complexity:** `O(n)`

### 2. Bubble Sort

Bubble Sort is used to arrange tasks by due date.

Adjacent tasks are compared and swapped when they are in the wrong order.

**Worst-case Time Complexity:** `O(n²)`

## Project Structure

```text
StudentTaskPlanner
│
├── BusinessLogic
│   └── TaskManager.cs
│
├── Data
│   └── TaskRepository.cs
│
├── DataFiles
│   └── tasks.json
│
├── Models
│   └── Task.cs
│
├── Presentation
│   └── MainForm.cs
│
├── Program.cs
└── StudentTaskPlanner.csproj
```

## How to Run

### Requirements

- Windows
- .NET 10 SDK
- Visual Studio Code
- C# Dev Kit extension

### Steps

1. Open the project folder in Visual Studio Code.
2. Open the terminal.
3. Check the installed .NET version:

```powershell
dotnet --version
```

4. Build the project:

```powershell
dotnet build
```

5. Run the application:

```powershell
dotnet run
```

## Data Storage

Task information is stored locally in:

```text
DataFiles/tasks.json
```

The application automatically loads saved tasks when it starts and saves changes when task operations are performed.

## Testing

The following functionality was tested:

- Application startup
- Dashboard
- Add Task
- View Tasks
- Search
- Sort
- Complete Task
- Delete Task
- Study Schedule
- Data loading and saving
- Dashboard statistics

## Learning Outcome

This project demonstrates practical use of:

- C# programming
- Windows Forms GUI development
- Object-oriented programming
- 3-layer architecture
- File handling
- JSON serialization
- Linear Search
- Bubble Sort
- Basic software organization
- GitHub project management

## Author

**Student Task & Study Planner**  
Developed as a student-level Software Designing & Algorithms project.
