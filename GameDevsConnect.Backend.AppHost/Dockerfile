# # Verwende das offizielle .NET SDK Image als Basis für den Build-Prozess
# FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# WORKDIR /src
# COPY . .

# # Stelle die Projektdateien wieder her
# RUN dotnet restore "GameDevsConnect.Backend.AppHost/GameDevsConnect.Backend.AppHost.csproj"
# # Veröffentliche die Anwendung im Release-Modus
# RUN dotnet publish "GameDevsConnect.Backend.AppHost/GameDevsConnect.Backend.AppHost.csproj" -c Release -o /app/publish

# # Verwende das offizielle .NET Runtime Image als Basis für das finale Image
# FROM ubuntu/dotnet-runtime:candidate AS final
# WORKDIR /app
# # Kopiere die veröffentlichte Anwendung aus dem Build-Image
# COPY --from=build /app/publish .
# # Lege den Entry Point für den Container fest
# ENTRYPOINT ["dotnet", "GameDevsConnect.Backend.AppHost.dll"]


# FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# WORKDIR /src

# COPY "GameDevsConnect.Backend.AppHost/GameDevsConnect.Backend.AppHost.csproj" "GameDevsConnect.Backend.AppHost/"
# COPY ["GameDevsConnect.Backend.API.User/GameDevsConnect.Backend.API.User.csproj", "GameDevsConnect.Backend.API.User/"]
# COPY ["GameDevsConnect.Backend.API.Tag/GameDevsConnect.Backend.API.Tag.csproj", "GameDevsConnect.Backend.API.Tag/"]
# COPY ["GameDevsConnect.Backend.API.Request/GameDevsConnect.Backend.API.Request.csproj", "GameDevsConnect.Backend.API.Request/"]
# COPY ["GameDevsConnect.Backend.API.Project/GameDevsConnect.Backend.API.Project.csproj", "GameDevsConnect.Backend.API.Project/"]
# COPY ["GameDevsConnect.Backend.API.Profile/GameDevsConnect.Backend.API.Profile.csproj", "GameDevsConnect.Backend.API.Profile/"]
# COPY ["GameDevsConnect.Backend.API.Notification/GameDevsConnect.Backend.API.Notification.csproj", "GameDevsConnect.Backend.API.Notification/"]
# COPY ["GameDevsConnect.Backend.API.Gateway/GameDevsConnect.Backend.API.Gateway.csproj", "GameDevsConnect.Backend.API.Gateway/"]
# COPY ["GameDevsConnect.Backend.API.File/GameDevsConnect.Backend.API.File.csproj", "GameDevsConnect.Backend.API.File/"]
# COPY ["GameDevsConnect.Backend.API.Comment/GameDevsConnect.Backend.API.Comment.csproj", "GameDevsConnect.Backend.API.Comment/"]
# COPY ["GameDevsConnect.Backend.API.Azure/GameDevsConnect.Backend.API.Azure.csproj", "GameDevsConnect.Backend.API.Azure/"]

# COPY ["GameDevsConnect.Backend.ServiceDefaults/GameDevsConnect.Backend.ServiceDefaults.csproj", "GameDevsConnect.Backend.ServiceDefaults/"]
# COPY ["GameDevsConnect.Backend.Shared/GameDevsConnect.Backend.Shared.csproj", "GameDevsConnect.Backend.Shared/"]
# RUN dotnet publish "GameDevsConnect.Backend.AppHost/GameDevsConnect.Backend.AppHost.csproj" -c Release -o /publish

# # Runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:9.0
# WORKDIR /app
# COPY --from=build /publish .
# ENTRYPOINT ["dotnet", "GameDevsConnect.Backend.AppHost.dll"]


# --- Build stage ---
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj files
COPY ["GameDevsConnect.Backend.AppHost/GameDevsConnect.Backend.AppHost.csproj", "GameDevsConnect.Backend.AppHost/"]
COPY ["GameDevsConnect.Backend.API.User/GameDevsConnect.Backend.API.User.csproj", "GameDevsConnect.Backend.API.User/"]
COPY ["GameDevsConnect.Backend.API.Tag/GameDevsConnect.Backend.API.Tag.csproj", "GameDevsConnect.Backend.API.Tag/"]
COPY ["GameDevsConnect.Backend.API.Request/GameDevsConnect.Backend.API.Request.csproj", "GameDevsConnect.Backend.API.Request/"]
COPY ["GameDevsConnect.Backend.API.Project/GameDevsConnect.Backend.API.Project.csproj", "GameDevsConnect.Backend.API.Project/"]
COPY ["GameDevsConnect.Backend.API.Profile/GameDevsConnect.Backend.API.Profile.csproj", "GameDevsConnect.Backend.API.Profile/"]
COPY ["GameDevsConnect.Backend.API.Notification/GameDevsConnect.Backend.API.Notification.csproj", "GameDevsConnect.Backend.API.Notification/"]
COPY ["GameDevsConnect.Backend.API.Gateway/GameDevsConnect.Backend.API.Gateway.csproj", "GameDevsConnect.Backend.API.Gateway/"]
COPY ["GameDevsConnect.Backend.API.File/GameDevsConnect.Backend.API.File.csproj", "GameDevsConnect.Backend.API.File/"]
COPY ["GameDevsConnect.Backend.API.Comment/GameDevsConnect.Backend.API.Comment.csproj", "GameDevsConnect.Backend.API.Comment/"]
COPY ["GameDevsConnect.Backend.API.Azure/GameDevsConnect.Backend.API.Azure.csproj", "GameDevsConnect.Backend.API.Azure/"]
COPY ["GameDevsConnect.Backend.ServiceDefaults/GameDevsConnect.Backend.ServiceDefaults.csproj", "GameDevsConnect.Backend.ServiceDefaults/"]
COPY ["GameDevsConnect.Backend.Shared/GameDevsConnect.Backend.Shared.csproj", "GameDevsConnect.Backend.Shared/"]

# Copy the rest of the source code
COPY . .

# Publish
# RUN dotnet publish "GameDevsConnect.Backend.AppHost/GameDevsConnect.Backend.AppHost.csproj" -c Release -o /publish /p:UseAppHost=false

RUN dotnet publish "GameDevsConnect.Backend.AppHost/GameDevsConnect.Backend.AppHost.csproj" -c Release -o /app/publish /p:UseAppHost=false && echo "Published files:" && ls -la /app/publish

# --- Runtime stage ---
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /publish .

ENTRYPOINT ["dotnet", "GameDevsConnect.Backend.AppHost.dll"]
