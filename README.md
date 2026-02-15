# 🌿 Plants API - DevOps Final Project

[![CI Pipeline](https://github.com/dlamanova/devops-final-project/actions/workflows/ci.yml/badge.svg)](https://github.com/dlamanova/devops-final-project/actions/workflows/ci.yml)
[![CD Pipeline](https://github.com/dlamanova/devops-final-project/actions/workflows/cd.yml/badge.svg)](https://github.com/dlamanova/devops-final-project/actions/workflows/cd.yml)

RESTful API for managing plants built with C# and ASP.NET Core. This project demonstrates modern DevOps practices including CI/CD pipelines, containerization, automated testing, semantic versioning, and cloud deployment.

## 🚀 Live Demo

- **Production URL**: https://plants-api-app.azurewebsites.net/
- **API Documentation**: https://plants-api-app.azurewebsites.net/swagger
- **Docker Image**: ghcr.io/dlamanova/devops-final-project

## 📋 Table of Contents

- [Project Description](#project-description)
- [Features](#features)
- [Technologies](#technologies)
- [API Endpoints](#api-endpoints)
- [Prerequisites](#prerequisites)
- [Running the Application](#running-the-application)
- [CI/CD Pipelines](#cicd-pipelines)
- [Testing](#testing)
- [Deployment](#deployment)
- [Project Structure](#project-structure)
- [Versioning](#versioning)
- [Author](#author)

## 📖 Project Description

Plants API is a Web API application that allows users to manage a collection of plants. The project showcases a complete DevOps workflow from local development to production deployment with automated CI/CD pipelines, containerization, and cloud infrastructure.

## ✨ Features

### Core Functionality

- ✅ RESTful API for plant management
- ✅ In-memory data storage with sample data
- ✅ Interactive Swagger/OpenAPI documentation
- ✅ Landing page with API information
- ✅ Version endpoint with build metadata

### DevOps Features

- ✅ **Automated CI/CD** with GitHub Actions
- ✅ **Containerization** with Docker
- ✅ **Cloud Deployment** on Azure App Service
- ✅ **Semantic Versioning** with GitVersion
- ✅ **Unit Testing** with xUnit and code coverage
- ✅ **Container Registry** with GitHub Container Registry (GHCR)
- ✅ **Multi-platform builds** (linux/amd64)

## 🛠 Technologies

| Category               | Technology                           |
| ---------------------- | ------------------------------------ |
| **Language**           | C# (.NET 9.0)                        |
| **Framework**          | ASP.NET Core Web API (Minimal APIs)  |
| **Documentation**      | Swagger/OpenAPI (Swashbuckle)        |
| **Testing**            | xUnit, WebApplicationFactory         |
| **Containerization**   | Docker, Docker Compose               |
| **CI/CD**              | GitHub Actions                       |
| **Versioning**         | GitVersion                           |
| **Cloud Provider**     | Microsoft Azure                      |
| **Hosting**            | Azure App Service (Linux Containers) |
| **Container Registry** | GitHub Container Registry (GHCR)     |
| **Code Quality**       | .NET Test Coverage, Test Reporter    |

## 🔌 API Endpoints

### Plants

| Method | Endpoint           | Description     | Response                    |
| ------ | ------------------ | --------------- | --------------------------- |
| `GET`  | `/api/plants`      | Get all plants  | `200 OK` with plant array   |
| `GET`  | `/api/plants/{id}` | Get plant by ID | `200 OK` or `404 Not Found` |

### Information

| Method | Endpoint       | Description                    | Response                      |
| ------ | -------------- | ------------------------------ | ----------------------------- |
| `GET`  | `/api/version` | Get API version and build info | `200 OK` with version details |
| `GET`  | `/`            | Landing page                   | HTML home page                |
| `GET`  | `/swagger`     | API documentation              | Swagger UI                    |

### Sample Response

**GET /api/plants/1:**

```json
{
  "id": 1,
  "name": "Monstera",
  "species": "Monstera deliciosa",
  "wateringFrequencyDays": 7,
  "plantedDate": "2024-01-15T00:00:00"
}
```

**GET /api/version:**

```json
{
  "version": "1.0.5",
  "gitCommit": "a1b2c3d4e5f6...",
  "buildDate": "2026-02-15T12:00:00Z",
  "environment": "Production",
  "applicationName": "Plants API"
}
```

## 📦 Prerequisites

### Local Development

- [.NET SDK 9.0](https://dotnet.microsoft.com/download)
- Code editor (VS Code recommended)

### Docker Development

- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- Docker Compose (included with Docker Desktop)

### Cloud Deployment (Optional)

- Azure account
- Azure CLI
- GitHub account (for Actions)

## 🚀 Running the Application

### Option 1: Run Locally with .NET CLI

```bash
# Navigate to project directory
cd PlantsApi

# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run
```

Access the application:

- **Swagger UI**: https://localhost:5212/swagger
- **API**: https://localhost:5212/api/plants

### Option 2: Run with Docker

```bash
# Build Docker image
docker build -t plants-api .

# Run container
docker run -p 8080:8080 plants-api
```

Access the application:

- **Swagger UI**: http://localhost:8080/swagger
- **API**: http://localhost:8080/api/plants

### Option 3: Run with Docker Compose (Recommended)

```bash
# Build and run
docker-compose up --build

# Run in background (detached mode)
docker-compose up -d

# View logs
docker-compose logs -f

# Stop
docker-compose down
```

Access the application:

- **Home Page**: http://localhost:8080/
- **Swagger UI**: http://localhost:8080/swagger
- **API**: http://localhost:8080/api/plants

## 🔄 CI/CD Pipelines

### CI Pipeline (Continuous Integration)

**Trigger:** Push to `main` or `feature/**` branches, Pull Requests to `main`

**Workflow:**

1. ✅ Checkout code (full Git history for GitVersion)
2. ✅ Determine version with GitVersion
3. ✅ Setup .NET 9.0
4. ✅ Restore dependencies
5. ✅ Build project with version metadata
6. ✅ Run unit tests with coverage
7. ✅ Generate test reports (TRX format)
8. ✅ Upload test results as artifacts
9. ✅ Create test summary with visual report
10. ✅ Build Docker image (linux/amd64)

**File:** `.github/workflows/ci.yml`

**Features:**

- Automated testing on every commit
- Code coverage collection
- Visual test reports in PR checks
- Docker build verification
- Fail-fast on test failures

### CD Pipeline (Continuous Deployment)

**Trigger:** Push to `main` branch, Manual workflow dispatch

**Workflow:**

1. ✅ Checkout code
2. ✅ Determine version with GitVersion
3. ✅ Setup .NET and build with version
4. ✅ Run tests
5. ✅ Login to GitHub Container Registry
6. ✅ Build multi-platform Docker image
7. ✅ Tag image with multiple versions:
   - `latest`
   - `{semver}` (e.g., `1.0.5`)
   - `{major}.{minor}` (e.g., `1.0`)
8. ✅ Push to GHCR
9. ✅ Deploy to Azure App Service
10. ✅ Health check

**File:** `.github/workflows/cd.yml`

**Features:**

- Automatic deployment to production on merge to main
- Semantic versioning with GitVersion
- Multi-tag Docker images for flexible deployments
- Zero-downtime deployment on Azure
- Rollback capability (deploy specific version)

## 🧪 Testing

### Running Tests Locally

```bash
# Run all tests
dotnet test

# Run with detailed output
dotnet test --verbosity normal

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run specific test
dotnet test --filter "GetAllPlants_ReturnsAllPlants"
```

### Test Structure

```
PlantsApi.Tests/
├── PlantsApiTests.cs          # Integration tests
└── PlantsApi.Tests.csproj     # Test project configuration
```

### Test Coverage

Current tests include:

- ✅ GET /api/plants - returns all plants
- ✅ GET /api/plants/{id} - returns plant by ID
- ✅ GET /api/plants/{id} - returns 404 for non-existent plant

Tests use **WebApplicationFactory** for integration testing with in-memory test server.

## ☁️ Deployment

### Azure Infrastructure

- **Resource Group**: `rg-dlamanova-plants`
- **App Service Plan**: `asp-dlamanova-plants` (Linux, B1)
- **App Service**: `plants-api-app`
- **Region**: West Europe
- **Runtime**: Container (Linux)

### Deployment Process

1. **Automated (Recommended):**
   - Merge PR to `main` branch
   - CD pipeline automatically deploys to Azure
   - ~5 minutes from merge to production

2. **Manual:**

   ```bash
   # Login to Azure
   az login

   # Deploy specific version
   az webapp config container set \
     --name plants-api-app \
     --resource-group rg-dlamanova-plants \
     --docker-custom-image-name ghcr.io/dlamanova/devops-final-project:1.0.5
   ```

### Environment Configuration

Azure App Service settings:

- `ASPNETCORE_ENVIRONMENT`: `Production`
- `VERSION`: Set via Docker build-args
- `GIT_COMMIT`: Set via Docker build-args
- `BUILD_DATE`: Set via Docker build-args

## 📂 Project Structure

```
devops-final-project/
├── .github/
│   └── workflows/
│       ├── ci.yml                    # CI Pipeline
│       └── cd.yml                    # CD Pipeline
├── PlantsApi/
│   ├── Controllers/
│   │   └── PlantsController.cs      # Plants API controller (legacy)
│   ├── Models/
│   │   └── Plant.cs                 # Plant data model
│   ├── DTOs/
│   │   └── CreatePlantDto.cs        # Data Transfer Objects
│   ├── Properties/
│   │   └── launchSettings.json
│   ├── Program.cs                   # Application entry point (Minimal APIs)
│   ├── PlantsApi.csproj            # Project configuration
│   ├── appsettings.json
│   └── appsettings.Development.json
├── PlantsApi.Tests/
│   ├── PlantsApiTests.cs           # Integration tests
│   └── PlantsApi.Tests.csproj      # Test project
├── docker-compose.yml               # Docker Compose configuration
├── Dockerfile                       # Multi-stage Docker build
├── GitVersion.yml                   # Semantic versioning config
├── .dockerignore                   # Docker ignore rules
├── .gitignore                      # Git ignore rules
└── README.md                       # Project documentation
```

## 📌 Versioning

This project uses **GitVersion** for automated semantic versioning.

### Versioning Strategy

- **Mode**: ContinuousDeployment
- **Base Version**: 1.0.0
- **Increment**: Patch (automatic on `main` commits)

### Version Format

`MAJOR.MINOR.PATCH` (e.g., `1.0.5`)

### How Versions Change

| Action                       | Version Change       | Example           |
| ---------------------------- | -------------------- | ----------------- |
| Commit to `main`             | +0.0.1 (Patch)       | `1.0.0` → `1.0.1` |
| Commit with `+semver: minor` | +0.1.0 (Minor)       | `1.0.5` → `1.1.0` |
| Commit with `+semver: major` | +1.0.0 (Major)       | `1.1.0` → `2.0.0` |
| Feature branch               | `{version}-beta.{n}` | `1.1.0-beta.1`    |

### Check Current Version

```bash
# API endpoint
curl https://plants-api-app.azurewebsites.net/api/version

# Docker image tags
docker pull ghcr.io/dlamanova/devops-final-project:latest
docker pull ghcr.io/dlamanova/devops-final-project:1.0
docker pull ghcr.io/dlamanova/devops-final-project:1.0.5
```

## 🔧 Development Workflow

### Creating a New Feature

1. **Create feature branch:**

   ```bash
   git checkout -b feature/my-new-feature
   ```

2. **Make changes and commit:**

   ```bash
   git add .
   git commit -m "Add new feature"
   git push -u origin feature/my-new-feature
   ```

3. **Create Pull Request on GitHub**

4. **CI Pipeline runs automatically:**
   - Build verification
   - Unit tests
   - Docker build
   - Test reports in PR

5. **Merge to main after approval**

6. **CD Pipeline deploys to production automatically**

### Branch Protection Rules

- ✅ Require PR before merging to `main`
- ✅ Require CI status checks to pass
- ✅ Require code review (recommended)

## 🐛 Troubleshooting

### Application not starting locally

```bash
# Check .NET version
dotnet --version  # Should be 9.0.x

# Clean and rebuild
dotnet clean
dotnet build
```

### Docker build fails

```bash
# Clear Docker cache
docker builder prune

# Rebuild without cache
docker build --no-cache -t plants-api .
```

### Tests failing

```bash
# Run tests with detailed output
dotnet test --logger "console;verbosity=detailed"

# Check test project references
dotnet list PlantsApi.Tests/PlantsApi.Tests.csproj reference
```

### Azure deployment issues

```bash
# Check app logs
az webapp log tail --name plants-api-app --resource-group rg-dlamanova-plants

# Restart app
az webapp restart --name plants-api-app --resource-group rg-dlamanova-plants

# Check container settings
az webapp config container show --name plants-api-app --resource-group rg-dlamanova-plants
```

## 📚 Additional Resources

- [.NET 9 Documentation](https://docs.microsoft.com/dotnet/core/whats-new/dotnet-9)
- [ASP.NET Core Minimal APIs](https://docs.microsoft.com/aspnet/core/fundamentals/minimal-apis)
- [Docker Documentation](https://docs.docker.com/)
- [GitHub Actions Documentation](https://docs.github.com/actions)
- [Azure App Service Documentation](https://docs.microsoft.com/azure/app-service/)
- [GitVersion Documentation](https://gitversion.net/docs/)

## 👤 Author

**dlamanova**

- GitHub: [@dlamanova](https://github.com/dlamanova)
- Project: [devops-final-project](https://github.com/dlamanova/devops-final-project)

## 📄 License

This project is created for educational purposes as part of a DevOps course.

---
