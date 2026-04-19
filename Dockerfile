# 1. Use the official .NET 8 runtime as the base environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

# 2. Use the .NET 8 SDK to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files to restore dependencies
COPY ["CatalogService.API/CatalogService.API.csproj", "CatalogService.API/"]
COPY ["CatalogService.Application/CatalogService.Application.csproj", "CatalogService.Application/"]
COPY ["CatalogService.Core/CatalogService.Core.csproj", "CatalogService.Core/"]
COPY ["CatalogService.Infrastructure/CatalogService.Infrastructure.csproj", "CatalogService.Infrastructure/"]
RUN dotnet restore "./CatalogService.API/CatalogService.API.csproj"

# Copy the rest of the code and build it
COPY . .
WORKDIR "/src/CatalogService.API"
RUN dotnet build "./CatalogService.API.csproj" -c Release -o /app/build

# 3. Publish the optimized application
FROM build AS publish
RUN dotnet publish "./CatalogService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 4. Run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CatalogService.API.dll"]