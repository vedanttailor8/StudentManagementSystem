# Student Management System

## Project Overview
The Student Management System is a web-based application developed using ASP.NET Core MVC. It helps manage student information through a simple and user-friendly interface.

This project is developed as part of a Web Technology academic project.

## Features
- Add new student records
- View student details
- Edit student information
- Delete student records
- Manage student data
- User-friendly interface
- MySQL database connectivity

## Technologies Used

| Technology | Purpose |
|---|---|
| ASP.NET Core MVC | Web application framework |
| C# | Backend programming |
| HTML | Web page structure |
| CSS | Web page styling |
| Bootstrap | Responsive design |
| Entity Framework Core | Database operations |
| MySQL | Database management |
| Visual Studio / VS Code | Development tools |

## Project Structure

```text
StudentManagementSystem/
│
├── Controllers/
│   ├── HomeController.cs
│   └── StudentsController.cs
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── Models/
│   ├── Student.cs
│   └── ErrorViewModel.cs
│
├── Migrations/
│
├── Views/
│
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── lib/
│
├── appsettings.json
├── Program.cs
└── StudentManagementSystem.csproj
```

## System Requirements
- .NET SDK 10
- MySQL Server
- Visual Studio or Visual Studio Code
- Web browser

## Installation and Setup

### 1. Clone the Repository

```bash
git clone https://github.com/RidhamKotadiya/Web-Technology-Project.git
```

### 2. Open the Project

```bash
cd Web-Technology-Project/StudentManagementSystem
```

### 3. Configure MySQL

Create a MySQL database named:

```sql
CREATE DATABASE student_management;
```

Update the connection string in `appsettings.json` with your MySQL username and password.

### 4. Restore Dependencies

```bash
dotnet restore
```

### 5. Apply Database Migrations

```bash
dotnet ef database update
```

If the Entity Framework command is unavailable, install the EF Core command-line tool and ensure the required design package is available.

### 6. Run the Application

```bash
dotnet run
```

Open the local URL displayed in the terminal.

## Application Usage

1. Open the Student Management System in your browser.
2. Navigate to the student management section.
3. Add student information.
4. View existing student records.
5. Update student details when required.
6. Delete student records when required.

## Database

The application uses MySQL to store student information.

Entity Framework Core is used to perform database operations and manage student records.

## Project Objective

The main objective of this project is to develop a web-based student management application that simplifies student record management and demonstrates practical implementation of web development technologies.

## Future Enhancements
- Student search functionality
- Student authentication
- Attendance management
- Academic performance tracking
- Student report generation
- Improved dashboard

## Conclusion

The Student Management System provides a simple solution for managing student information. This project demonstrates the use of ASP.NET Core MVC, C#, Entity Framework Core, and MySQL in web application development.

## Author

Ridham Kotadiya

GitHub Repository:  
https://github.com/RidhamKotadiya/Web-Technology-Project

---

**Developed for academic and educational purposes.**