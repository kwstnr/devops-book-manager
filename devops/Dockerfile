# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY src/BookManager.Graph/*.csproj ./src/BookManager.Graph/
COPY src/BookManager.Data.Postgres/*.csproj ./src/BookManager.Data.Postgres/
COPY src/BookManager.Domain/*.csproj ./src/BookManager.Domain/

# Restore all dependencies
RUN dotnet restore

# Copy everything else and build the application
COPY . ./
RUN dotnet publish src/BookManager.Graph/BookManager.Graph.csproj -c Release -o out

# Build a runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/out .

# Expose the port your application will run on
EXPOSE 80

# Set the environment variables
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Production

# Entry point for the application
ENTRYPOINT ["dotnet", "BookManager.Graph.dll"]