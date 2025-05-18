# FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# WORKDIR /app
# COPY . .

# FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
# WORKDIR /app
# EXPOSE 8000

# # Verwende das offizielle .NET SDK Image als Basis für den Build-Prozess
# # FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# WORKDIR /src
# COPY . .

# # Stelle die Projektdateien wieder her
# RUN dotnet restore "GameDevsConnect.Backend.AppHost/GameDevsConnect.Backend.AppHost.csproj"

# # Veröffentliche die Anwendung im Release-Modus
# RUN dotnet build "GameDevsConnect.Backend.AppHost/GameDevsConnect.Backend.AppHost.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "GameDevsConnect.Backend.AppHost/GameDevsConnect.Backend.AppHost.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "run"]