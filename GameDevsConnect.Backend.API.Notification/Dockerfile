# Unter https://aka.ms/customizecontainer erfahren Sie, wie Sie Ihren Debugcontainer anpassen und wie Visual Studio dieses Dockerfile verwendet, um Ihre Images für ein schnelleres Debuggen zu erstellen.

# Diese Stufe wird verwendet, wenn sie von VS im Schnellmodus ausgeführt wird (Standardeinstellung für Debugkonfiguration).
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Diese Stufe wird zum Erstellen des Dienstprojekts verwendet.
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GameDevsConnect.Backend.API.Notification/GameDevsConnect.Backend.API.Notification.csproj", "GameDevsConnect.Backend.API.Notification/"]
COPY ["GameDevsConnect.Backend.API.Notification.Application/GameDevsConnect.Backend.API.Notification.Application.csproj", "GameDevsConnect.Backend.API.Notification.Application/"]
COPY ["GameDevsConnect.Backend.API.Notification.Contract/GameDevsConnect.Backend.API.Notification.Contract.csproj", "GameDevsConnect.Backend.API.Notification.Contract/"]
COPY ["GameDevsConnect.Backend.Shared/GameDevsConnect.Backend.Shared.csproj", "GameDevsConnect.Backend.Shared/"]
COPY ["GameDevsConnect.Backend.ServiceDefaults/GameDevsConnect.Backend.ServiceDefaults.csproj", "GameDevsConnect.Backend.ServiceDefaults/"]
RUN dotnet restore "./GameDevsConnect.Backend.API.Notification/GameDevsConnect.Backend.API.Notification.csproj"
COPY . .
WORKDIR "/src/GameDevsConnect.Backend.API.Notification"
RUN dotnet build "./GameDevsConnect.Backend.API.Notification.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Diese Stufe wird verwendet, um das Dienstprojekt zu veröffentlichen, das in die letzte Phase kopiert werden soll.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GameDevsConnect.Backend.API.Notification.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Diese Stufe wird in der Produktion oder bei Ausführung von VS im regulären Modus verwendet (Standard, wenn die Debugkonfiguration nicht verwendet wird).
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameDevsConnect.Backend.API.Notification.dll"]