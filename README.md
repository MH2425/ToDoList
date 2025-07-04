# To-Do List Application

A modern, clean architecture To-Do List application built with ASP.NET Core 8.0, implementing Repository and Unit of Work patterns with Entity Framework Core.

## 🚀 Features

- ✅ Add, edit, and delete to-do items
- ✅ Mark items as complete/incomplete
- ✅ Clear all items at once
- ✅ Persistent storage with SQL Server
- ✅ Entity Framework Core with Code First migrations
- ✅ Responsive Bootstrap UI


### Design Patterns Used

- **Repository Pattern**: Abstracts data access logic
- **Unit of Work Pattern**: Manages transactions and coordinates repositories

## 🛠️ Prerequisites

Before running this application, make sure you have:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) 
- [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) with any extensions needed.
- [Git](https://git-scm.com/) for cloning the repository

## 📦 Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/MH2425/ToDoList.git
cd ToDoList
```

### 2. Restore NuGet Packages

```bash
dotnet restore
```

### 3. Database Setup

The application uses SQL Server LocalDB by default. The connection string is configured in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ToDoListDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

#### Database Migration

The application automatically runs migrations on startup. However, you can manually run migrations using:

```bash
# Navigate to the Infrastructure project
cd Infrastructure

# Add a new migration (if needed)
dotnet ef migrations add InitialCreate --startup-project ../ToDoList

# Update database
dotnet ef database update --startup-project ../ToDoList
```

### 4. Run the Application

```bash
# From the solution root directory
cd ToDoList
dotnet run
```

Or press `F5` in Visual Studio.


## 🔧 Configuration

### Database Configuration

To use a different database, update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your-Connection-String-Here"
  }
}
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request



### Getting Help

If you encounter any issues:
1. Check the [Issues](https://github.com/MH2425/ToDoList/issues) page
2. Create a new issue with detailed error information
3. Include your environment details (.NET version, OS, etc.)

## 🚀 Future Enhancements

- [ ] Add user authentication and authorization
- [ ] Implement categories/tags for items
- [ ] Add due dates and priorities
- [ ] Export/import functionality
- [ ] REST API for mobile apps
- [ ] Real-time updates with SignalR
- [ ] Search and filtering capabilities
- [ ] Unit and integration tests

## 👥 Authors

- **Hoang C.N.M** - [MH2425](https://github.com/MH2425)
