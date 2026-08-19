# 💰 Smart Expense Tracker

A web-based **Expense Tracking and Salary Management System** developed using **ASP.NET Core MVC, C#, Entity Framework Core, and Microsoft SQL Server**.

The application helps users manage personal and family expenses, track salary, view transactions, and monitor their overall financial status through a simple dashboard.

## 🚀 Live Demo

🌐 **Website:** https://smart-expense-tracker-reshma.runasp.net/

> The application is hosted on MonsterASP.

---

## 📌 Features

### 🔐 User Authentication

* User Registration
* User Login
* Logout
* Forgot Password
* Remember Me

### 💸 Expense Management

* Add new expenses
* Edit expenses
* View expense details
* Delete expenses
* Categorize expenses
* Track Personal and Family expenses

### 💰 Salary Management

* Add salary details
* Edit salary information
* View salary records
* Track monthly salary

### 📊 Dashboard

* Total Income
* Total Expenses
* Current Balance
* Personal Expenses
* Family Expenses
* Recent Transactions
* Financial overview

### 📋 Transaction Management

* View all transactions
* View income and expense records
* Track recent financial activities

---

## 🛠️ Technologies Used

| Technology            | Purpose                   |
| --------------------- | ------------------------- |
| C#                    | Programming Language      |
| ASP.NET Core MVC      | Web Application Framework |
| .NET 10               | Target Framework          |
| Entity Framework Core | ORM / Database Access     |
| Microsoft SQL Server  | Database                  |
| ASP.NET Core Identity | Authentication            |
| Razor Views           | Frontend                  |
| HTML5                 | Structure                 |
| CSS3                  | Styling                   |
| Bootstrap             | Responsive UI             |
| JavaScript            | Client-side functionality |
| Visual Studio         | Development Environment   |
| Git & GitHub          | Version Control           |
| MonsterASP            | Cloud Hosting             |

---

## 🏗️ Project Structure

```text
Trackexpense
│
├── Areas
│   └── Identity
│       └── Pages
│           └── Account
│
├── Controllers
│   ├── ExpensesController.cs
│   ├── HomeController.cs
│   └── SalaryController.cs
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Migrations
│
├── Models
│   ├── DashboardViewModel.cs
│   ├── ErrorViewModel.cs
│   ├── Expense.cs
│   └── Salary.cs
│
├── Views
│   ├── Expenses
│   ├── Home
│   ├── Salary
│   └── Shared
│
├── wwwroot
│   ├── css
│   ├── js
│   └── images
│
├── appsettings.json
├── Program.cs
└── Trackexpense.csproj
```

---

## 🗄️ Database

The application uses **Microsoft SQL Server** with **Entity Framework Core**.

### Main Database Features

* Expense records
* Salary records
* User authentication
* Transaction tracking
* Entity Framework Core migrations

### Entity Framework Migration

To create/update the database:

```powershell
Update-Database
```

---

## ⚙️ Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/YOUR-USERNAME/Trackexpense.git
```

### 2. Open the Project

Open the project in:

```text
Visual Studio
```

### 3. Restore NuGet Packages

```bash
dotnet restore
```

### 4. Configure Database

Open:

```text
appsettings.json
```

Add your SQL Server connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
  }
}
```

> ⚠️ Do not upload real database passwords or sensitive credentials to GitHub.

### 5. Apply Migrations

Open **Package Manager Console** and run:

```powershell
Update-Database
```

### 6. Run the Application

```bash
dotnet run
```

Or press:

```text
Ctrl + F5
```

in Visual Studio.

---

## 🔑 Authentication

The application uses **ASP.NET Core Identity** for user authentication and account management.

Users can:

* Create an account
* Login
* Logout
* Remember login
* Reset password

---

## 📊 Dashboard Overview

The dashboard provides a quick financial summary including:

```text
Total Income
Total Expense
Balance
Personal Expense
Family Expense
Recent Transactions
```

This allows users to easily understand their current financial situation.

---

## 🌐 Deployment

The application is deployed using **MonsterASP ASP.NET & .NET Cloud Hosting**.

### Deployment Technology

```text
ASP.NET Core
       ↓
WebDeploy
       ↓
MonsterASP
       ↓
SQL Server
```

HTTPS is enabled using a **Let's Encrypt SSL certificate**.

---

## 🔒 Security

The project follows basic security practices including:

* ASP.NET Core Identity authentication
* Password protection
* HTTPS
* Entity Framework Core
* SQL Server
* Secure database connection

> **Important:** Never commit passwords, API keys, connection strings containing credentials, or other secrets to GitHub.

---

## 📱 Responsive Design

The application UI is designed using Bootstrap and responsive web design principles so that it can be accessed from:

* 💻 Desktop
* 💻 Laptop
* 📱 Mobile
* 📟 Tablet

---

## 🎯 Project Objective

The main objective of this project is to develop a simple and user-friendly financial management application that allows users to:

* Manage daily expenses
* Track salary
* Monitor income and expenses
* Separate personal and family expenses
* View financial summaries
* Manage transactions efficiently

---

## 🔮 Future Enhancements

Possible future improvements include:

* 📈 Expense charts and graphs
* 📊 Monthly financial reports
* 📥 Export transactions to Excel/PDF
* 🔔 Expense notifications
* 💳 Budget management
* 🔎 Advanced transaction filtering
* 📱 Progressive Web App support
* ☁️ Cloud database improvements

---

## 👩‍💻 Developer

**Reshma**

Software Specialist | Software Trainer

### Technologies

```text
C# • ASP.NET Core MVC • .NET • Entity Framework Core
SQL Server • HTML • CSS • Bootstrap • JavaScript
```

---

## 📄 License

This project is created for **educational and project development purposes**.
