# To-Do List Application

A modern, clean architecture To-Do List application built with ASP.NET Core 8.0, implementing Repository and Unit of Work patterns with Entity Framework Core.

## 🚀 Features

- ✅ Add, edit, and delete to-do items
- ✅ Mark items as complete/incomplete
- ✅ Clear all items at once
- ✅ Persistent storage with SQL Server
- ✅ Clean Architecture with separation of concerns
- ✅ Repository and Unit of Work patterns
- ✅ Entity Framework Core with Code First migrations
- ✅ Responsive Bootstrap UI

## 🏗️ Architecture

This application follows Clean Architecture principles with the following project structure:

```
ToDoList/
├── Entities/           # Domain entities (ToDoItem)
├── UseCases/          # Business logic and interfaces
├── Infrastructure/    # Data access, repositories, and Unit of Work
└── ToDoList/         # Web UI (ASP.NET Core MVC)
```

### Design Patterns Used

- **Repository Pattern**: Abstracts data access logic
- **Unit of Work Pattern**: Manages transactions and coordinates repositories
- **Dependency Injection**: Loose coupling between layers
- **Clean Architecture**: Separation of concerns and testability

## 🛠️ Prerequisites

Before running this application, make sure you have:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb) (comes with Visual Studio)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/) for cloning the repository

## 📦 Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/todolist-cleanarchitecture.git
cd todolist-cleanarchitecture
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

The application will be available at:
- HTTPS: `https://localhost:5001`
- HTTP: `http://localhost:5000`

## 🎯 Usage

### Adding a To-Do Item
1. Click the "Add" button on the main page
2. Enter your task description
3. Click "Save"

### Editing a To-Do Item
1. Click the "Edit" button next to any item
2. Modify the text or completion status
3. Click "Save"

### Marking Items Complete
- Click the checkbox next to any item to toggle its completion status
- Completed items will appear with strikethrough text

### Deleting Items
1. Click the "Delete" button next to any item
2. Confirm the deletion in the popup dialog

### Clearing All Items
1. Click the "Clear All Items" button
2. Confirm the action in the popup dialog

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

### Switching to In-Memory Storage

For development or testing, you can switch to in-memory storage by modifying `Program.cs`:

```csharp
// Comment out the SQL Server registration
// builder.Services.AddDbContext<ToDoContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register in-memory repository instead
builder.Services.AddSingleton<IToDoItemRepository, InMemoryToDoItemRepository>();
```

## 🏗️ Project Structure Details

### Entities Project
Contains domain models:
- `ToDoItem`: Core entity representing a to-do item

### UseCases Project
Contains business logic and interfaces:
- `IToDoItemRepository`: Repository interface
- `IRepository<T>`: Generic repository interface
- `IUnitOfWork<T>`: Unit of Work interface
- `ToDoListManager`: Business logic for managing to-do items

### Infrastructure Project
Contains data access implementations:
- `ToDoContext`: Entity Framework DbContext
- `SqlToDoItemRepository`: SQL Server implementation
- `InMemoryToDoItemRepository`: In-memory implementation
- `GenericRepository<T>`: Generic repository implementation
- `UnitOfWork<T>`: Unit of Work implementation
- Database migrations

### ToDoList Project (Web UI)
Contains the ASP.NET Core MVC application:
- `Controllers`: MVC controllers
- `Models`: View models
- `Views`: Razor views
- `wwwroot`: Static files (CSS, JS, libraries)

## 🧪 Testing

### Running Tests

```bash
dotnet test
```

### Manual Testing

1. **Add Item Test**: Create several items with different text
2. **Edit Item Test**: Modify existing items
3. **Complete Item Test**: Toggle completion status
4. **Delete Item Test**: Remove individual items
5. **Clear All Test**: Remove all items at once
6. **Persistence Test**: Restart the application and verify data persists

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🆘 Troubleshooting

### Common Issues

#### Database Connection Issues
- Ensure SQL Server LocalDB is installed and running
- Check the connection string in `appsettings.json`
- Try running `sqllocaldb start mssqllocaldb` in Command Prompt

#### Migration Issues
```bash
# Reset migrations
dotnet ef database drop --startup-project ../ToDoList
dotnet ef migrations remove --startup-project ../ToDoList
dotnet ef migrations add InitialCreate --startup-project ../ToDoList
dotnet ef database update --startup-project ../ToDoList
```

#### Build Issues
```bash
# Clean and rebuild
dotnet clean
dotnet restore
dotnet build
```

### Getting Help

If you encounter any issues:
1. Check the [Issues](https://github.com/yourusername/todolist-cleanarchitecture/issues) page
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

- **Your Name** - *Initial work* - [YourGitHub](https://github.com/yourusername)

## 🙏 Acknowledgments

- ASP.NET Core team for the excellent framework
- Entity Framework Core team for the ORM
- Bootstrap team for the UI framework
- Clean Architecture principles by Robert C. Martin