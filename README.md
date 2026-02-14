# Plants API - DevOps Final Project

RESTful API for managing plants built with C# and ASP.NET Core. This project demonstrates modern DevOps practices including CI/CD pipelines, containerization, automated testing, and cloud deployment.

## Project Description

Plants API is a Web API application that allows users to manage a collection of plants. The application is currently in active development with a structured DevOps workflow.

### Current Features

- ASP.NET Core Web API project structure
- Swagger/OpenAPI documentation
- Plant model with in-memory data storage
- PlantsController structure
- Docker containerization
- Docker Compose configuration

## Technologies

- **Language**: C# (.NET 9.0)
- **Framework**: ASP.NET Core Web API
- **Documentation**: Swagger/OpenAPI
- **Containerization**: Docker & Docker Compose

## Prerequisites

### Local Development

- [.NET SDK 9.0](https://dotnet.microsoft.com/download)
- Code editor (VS Code recommended)

### Docker Development

- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- Docker Compose (included with Docker Desktop)

## Running the Application

### Option 1: Run Locally with .NET CLI

1. **Navigate to project directory:**

   ```bash
   cd PlantsApi
   ```

2. **Restore dependencies:**

   ```bash
   dotnet restore
   ```

3. **Build the project:**

   ```bash
   dotnet build
   ```

4. **Run the application:**

   ```bash
   dotnet run
   ```

5. **Access Swagger UI:**
   ```
   https://localhost:5001/swagger
   ```

### Option 2: Run with Docker Compose (Recommended)

1. **Build and run the container:**

   ```bash
   docker-compose up --build
   ```

2. **Run in background (detached mode):**

   ```bash
   docker-compose up -d
   ```

3. **View logs:**

   ```bash
   docker-compose logs -f
   ```

4. **Stop the application:**

   ```bash
   docker-compose down
   ```

5. **Access Swagger UI:**
   ```
   http://localhost:8080/swagger
   ```

## 📂 Project Structure

```
devops-final-project/
├── PlantsApi/
│   ├── Controllers/
│   │   └── PlantsController.cs    # Plants API controller
│   ├── Models/
│   │   └── Plant.cs               # Plant data model
│   ├── Properties/
│   │   └── launchSettings.json
│   ├── Program.cs                 # Application entry point
│   ├── PlantsApi.csproj          # Project configuration
│   ├── appsettings.json
│   └── appsettings.Development.json
├── docker-compose.yml             # Docker Compose configuration
├── Dockerfile                     # Docker image definition
├── .dockerignore                  # Docker ignore rules
├── .gitignore                    # Git ignore rules
└── README.md                     # Project documentation
```

## Data Model

### Plant

```csharp
public class Plant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public int WateringFrequencyDays { get; set; }
    public DateTime PlantedDate { get; set; }
}
```

**Sample data** (3 plants available in-memory):

- Monstera (Monstera deliciosa)
- Snake Plant (Sansevieria trifasciata)
- Pothos (Epipremnum aureum)

## Author

**dlamanova**

## License

This project is created for educational purposes as part of a DevOps course.
