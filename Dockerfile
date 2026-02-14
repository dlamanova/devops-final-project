# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY PlantsApi/PlantsApi.csproj PlantsApi/
RUN dotnet restore PlantsApi/PlantsApi.csproj

# Copy all files and build
COPY PlantsApi/ PlantsApi/
WORKDIR /src/PlantsApi
RUN dotnet build PlantsApi.csproj -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish PlantsApi.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlantsApi.dll"]