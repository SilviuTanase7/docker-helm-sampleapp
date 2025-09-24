# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy solution and projects
COPY SampleApp.sln ./
COPY SampleApp/*.csproj ./SampleApp/
COPY SampleApp.Tests/*.csproj ./SampleApp.Tests/

# Restore dependencies
RUN dotnet restore

# Copy everything
COPY SampleApp/. ./SampleApp/
COPY SampleApp.Tests/. ./SampleApp.Tests/

# Build & publish
RUN dotnet publish SampleApp/SampleApp.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./
EXPOSE 80
ENTRYPOINT ["dotnet", "SampleApp.dll"]