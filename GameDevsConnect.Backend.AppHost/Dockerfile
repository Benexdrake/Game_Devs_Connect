# Verwende das offizielle .NET SDK Image als Basis für den Build-Prozess
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .

# Stelle die Projektdateien wieder her
RUN dotnet restore "GameDevsConnect.Backend.AppHost.csproj"
# Veröffentliche die Anwendung im Release-Modus
RUN dotnet publish "GameDevsConnect.Backend.AppHost.csproj" -c Release -o /app/publish

# Verwende das offizielle .NET Runtime Image als Basis für das finale Image
FROM ubuntu/dotnet-runtime:candidate AS final
WORKDIR /app
# Kopiere die veröffentlichte Anwendung aus dem Build-Image
COPY --from=build /app/publish .
# Lege den Entry Point für den Container fest
ENTRYPOINT ["dotnet", "GameDevsConnect.Backend.AppHost.dll"]