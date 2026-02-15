# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

ARG VERSION=1.0.0
ARG GIT_COMMIT=unknown
ARG BUILD_DATE=unknown

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

# Set environment variables
ENV VERSION=${VERSION:-1.0.0}
ENV GIT_COMMIT=${GIT_COMMIT:-unknown}
ENV BUILD_DATE=${BUILD_DATE:-unknown}

EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlantsApi.dll"]