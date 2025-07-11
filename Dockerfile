# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY ServiceDefaults/ServiceDefaults.csproj ./ServiceDefaults/
COPY DataAccess/DataAccess.csproj ./DataAccess/
COPY BusinessLogic/BusinessLogic.csproj ./BusinessLogic/
COPY ProductAPI/ProductAPI.csproj ./ProductAPI/

# Restore dependencies
RUN dotnet restore ProductAPI/ProductAPI.csproj

# Copy source code
COPY . .

# Build and publish
WORKDIR /src/ProductAPI
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080 \
    DOTNET_RUNNING_IN_CONTAINER=true \
    ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "ProductAPI.dll"] 