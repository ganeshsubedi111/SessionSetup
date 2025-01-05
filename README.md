# ASP.NET Core Session Management with Entity Framework Core

## Overview

This project demonstrates how to implement session management in an ASP.NET Core application using Entity Framework Core (EF Core). The session stores user information such as `UserId` and `Username`, allowing for user authentication and session persistence across multiple requests.

### Features:
- User login and authentication using session management.
- Interaction with a SQL Server database using Entity Framework Core.
- Scaffolded models and `DbContext` for interacting with the database.

---

## Steps to Set Up

### 1. **Configure Session in `Program.cs`**

To enable session management in your ASP.NET Core application:

1. **Add Session Services**: In `Program.cs`, add the session services before the `builder.Build()` call:

    ```csharp
    builder.Services.AddSession();
    or
    builder.Services.AddSession(options =>
{
    
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
    ```

2. **Use Session Middleware**: After building the application, enable session middleware by adding:

    ```csharp
    var app = builder.Build();
    app.UseSession();
    ```

This will enable session state management across the application.

---

### 2. **Install Required NuGet Packages**

To work with Entity Framework Core and SQL Server, install the following NuGet packages using the **Package Manager Console**:

```bash
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Design
---
### 3. **Scaffold DbContext and Models**
Scaffold the DbContext and model classes by running the following command in the Package Manager Console:
Scaffold-DbContext "Server=ServerName;Database=DatabaseName;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

### 4. **Move Connection String to appsettings.json**

```
{
  "ConnectionStrings": {
    "DatabaseConnection": "Server=ServerName;Database=DatabaseName;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```
### 5. **Register DbContext in Program.cs**
add following code in program.cs

 ```csharp
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();

builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("DatabaseConnection")));


```


