# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY TaskManager.API/TaskManager.API.csproj TaskManager.API/

RUN dotnet restore TaskManager.API/TaskManager.API.csproj

COPY TaskManager.API/ TaskManager.API/

WORKDIR /src/TaskManager.API

RUN dotnet publish TaskManager.API.csproj -c Release -o /app/publish

# Etapa de execução
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "TaskManager.API.dll"]