# Этап 1: Сборка
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Копируем всё содержимое репозитория
COPY . .

# Переходим в папку с бэкендом
WORKDIR /src/backend/GameDirectoryService

# Публикуем только Api-проект (он автоматически подтянет Domain, Application и Infrastructure)
RUN dotnet publish GameDirectoryService.Api/GameDirectoryService.Api.csproj -c Release -o /app

# Этап 2: Запуск (лёгкий runtime-образ)
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app .

# Указываем порт для ASP.NET Core
EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080

# Запускаем скомпилированную DLL
ENTRYPOINT ["dotnet", "GameDirectoryService.Api.dll"]

